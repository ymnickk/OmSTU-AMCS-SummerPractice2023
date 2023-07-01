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
        private double[] total = new double[2];

        public Перемещение_шатла(ScenarioContext scenarioContext)
        {
            scenario_Context = scenarioContext;
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
            total = SpaceShip.Move(isCanMove, isKnowSpeed,
            isKnowPosition, speed, start);
            }
            catch{}
        }


        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void космический_корабль_перемещается_в_точку_пространства_с_координатами
        (double p0, double p1)
        {
            double[] expected = {p0, p1};
            Assert.Equal(expected, total);
        }

        [Then(@"возникает ошибка Exception")]
        public void возникает_ошибка_Exception ()
        {
            Assert.Throws<Exception>(() => SpaceShip.Move(isCanMove, isKnowSpeed,
            isKnowPosition, speed, start));
        }



    }
}