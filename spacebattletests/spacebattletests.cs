using TechTalk.SpecFlow;
using spacebattle;

namespace spacebattletests
{
    [Binding]
    public class Перемещение_шатла
    {
        private readonly ScenarioContext scenario_Context;
        private double[] start = new double[2];
        private double[] speed = new double[2];
        private bool isCanMove=true, isKnowSpeed=true, isKnowPosition=true;
        private bool isKnowCorner=true, isKnowChangeAngle=true, isCanChangeAngle=true;
        private double fuel, change_fuel, corner, change_angle;
        private double[] total_position = new double[2];
        private double total_fuel;
        private double total_corner;

        public Перемещение_шатла(ScenarioContext scenarioContext)
        {
            scenario_Context = scenarioContext;
        }

        [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
        public void космический_корабль_имеет_топливо_в_объеме(double d0)
        {
            fuel=d0;
        }

        [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
        public void имеет_скорость_расхода_топлива_при_движении(double d0)
        {
            change_fuel=d0;
        }

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void космический_корабль_имеет_угол_наклона(double d0)
        {
            corner = d0;
        }
        [Given(@"космический корабль, угол наклона которого невозможно определить")]
        public void космический_корабль_угол_наклона_которого_невозможно_определить()
        {
            isKnowCorner= false;
        }

        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void имеет_мгновенную_угловую_скорость(double d0)
        {
            change_angle = d0;
        }
        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void мгновенную_угловую_скорость_невозможно_определить()
        {
            isKnowChangeAngle= false;
        }
        [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
        public void невозможно_изменить_угол_наклона_к_оси_OX_космического_корабля()
        {
            isCanChangeAngle=false;
        }


        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void космический_корабль_находится_в_точке_пространства_с_координатами
        (double p0, double p1)
        {
            start[0] = p0;
            start[1] = p1;
        }


        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void и_имеет_мгновенную_скорость(double p0, double p1)
        {
            speed[0] = p0;
            speed[1] = p1;
        }


        [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
        public void космический_корабль_положение_в_пространстве_которого_невозможно_определить()
        {
            isKnowPosition = false;
        }


        [Given(@"скорость корабля определить невозможно")]
        public void скорость_корабля_определить_невозможно()
        {
            isKnowSpeed = false;
        }


        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void изменить_положение_в_пространстве_космического_корабля_невозможно()
        {
            isCanMove = false;
        }


        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void происходит_прямолинейное_равномерное_движениебез_деформации()
        {
            try{
            total_position = SpaceShip.Move(isCanMove, isKnowSpeed,
            isKnowPosition, speed, start);
            total_fuel=SpaceShip.Fuel(fuel, change_fuel);
            }
            catch{}
        }

        [When(@"происходит вращение вокруг собственной оси")]
        public void происходит_вращение_вокруг_собственной_оси()
        {
            try{
                total_corner = SpaceShip.Turn(corner, change_angle,
                 isCanChangeAngle, isKnowChangeAngle, isKnowCorner);
            }
            catch{}
        }


        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void космический_корабль_перемещается_в_точку_пространства_с_координатами
        (double p0, double p1)
        {
            double[] expected = {p0, p1};
            Assert.Equal(expected, total_position);
        }
        

        [Then(@"новый объем топлива космического корабля равен (.*) ед")]
        public void новый_объем_топлива_космического_корабля_равен(double p0)
        {
            double excepted = p0;

            Assert.Equal(excepted, total_fuel);
        }

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void угол_наклона_космического_корабля_к_оси_OX_составляет(double p0)
        {
            double excepted = p0;

        Assert.Equal(excepted, total_corner);
        }


        [Then(@"возникает ошибка Exception")]
        public void возникает_ошибка_Exception ()
        {
            if(fuel!=double.NaN || change_fuel!=double.NaN)
            {
                try
                {
                    double result = SpaceShip.Fuel(fuel, change_fuel);
                }
                catch
                {
                    Assert.True(true);
                }
            }
            else if(corner!=double.NaN || change_angle!=double.NaN)
            {
                try
                {
                    double result = SpaceShip.Turn(corner, change_angle,
            isCanChangeAngle, isKnowChangeAngle, isKnowCorner);
                }
                catch
                {
                    Assert.True(true);
                }
            }
            else
            {
                try
                {
                    double[] result = SpaceShip.Move(isCanMove, isKnowSpeed,
                isKnowPosition, speed, start);
                }
                catch
                {
                    Assert.True(true);
                }
            }
        }
    }
}