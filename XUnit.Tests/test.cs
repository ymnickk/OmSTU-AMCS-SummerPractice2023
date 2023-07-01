using SquareEquationLib;
using TechTalk.SpecFlow;
namespace XUnit.Tests
{
    [Binding]
    public class Нахождение_корней
    {
        private readonly ScenarioContext scenario_Context;
        private double a, b, c;
        private double[] result = new double[2];
        public Нахождение_корней(ScenarioContext scenarioContext)
        {
            scenario_Context = scenarioContext;
        }

        [When(@"вычисляются корни квадратного уравнения")]
        public void вычисляются_корни_квадратного_уравнения()
        {
            try{
            result = SquareEquation.Solve(a, b, c);
            }
            catch{}
        }
       [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void квадратное_уравнение_имеет_два_корня_кратности_один(double p0, double p1)
        {
            double[] expected = {p0, p1};
            Array.Sort(expected);
            Array.Sort(result);
            Assert.Equal(expected, result);
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
         public void квадратное_уравнение_имеет_один_корень_кратности_два(double p0)
         {
            double[] expected = {p0};
            Assert.Equal(expected, result);
         }

         [Then(@"множество корней квадратного уравнения пустое")]
         public void множество_корней_квадратного_уравнения_пустое()
         {
            double[] expected = {};
            Assert.Equal(expected, result);
         }


        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
         public void пусть_квадратное_уравнение_с_норм_коэффициентами (double p0,double p1, double p2 )
         {
             a = p0;
             b = p1;
             c = p2;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
         public void пусть_квадратное_уравнение_с_неопределенностью_А (double p0, double p1)
         {
             a = double.NaN;
             b = p0;
             c = p1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
         public void пусть_квадратное_уравнение_с_неопределенностью_Б (double p0, double p1)
         {
             a = p0;
             b = double.NaN;
             c = p1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
         public void пусть_квадратное_уравнение_с_неопределенностью_С (double p0, double p1)
         {
             a = p0;
             b = p1;
             c = double.NaN;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
         public void пусть_квадратное_уравнение_с_отриц_беск_А(int p0, int p1)
         {
             a = double.NegativeInfinity;
             b = p0;
             c = p1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
         public void пусть_квадратное_уравнение_с_отриц_беск_Б(int p0, int p1)
         {
             a = p0;
             b = double.NegativeInfinity;
             c = p1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
         public void пусть_квадратное_уравнение_с_отриц_беск_С(int p0, int p1)
         {
             a = p0;
             b = p1;
             c = double.NegativeInfinity;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
         public void пусть_квадратное_уравнение_с_полож_беск_А(int p0, int p1)
         {
             a = double.PositiveInfinity;
             b = p0;
             c = p1;
         }
         
         [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
         public void пусть_квадратное_уравнение_с_полож_беск_Б(int p0, int p1)
         {
             a = p0;
             b = double.PositiveInfinity;
             c = p1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
         public void пусть_квадратное_уравнение_с_полож_беск_С(int p0, int p1)
         {
             a = p0;
             b = p1;
             c = double.PositiveInfinity;
         }

         [Then(@"выбрасывается исключение ArgumentException")]
         public void выбрасывается_исключение_ArgumentException()
         {
            var Exception= new ArgumentException();

            try
            {
                var result = SquareEquation.Solve(a,b,c);
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.GetType(), Exception.GetType());
            }
         }
    }
}