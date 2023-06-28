namespace SquareEquationLib;
public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] answer;
        double x1, x2;
        double eps = 1e-9;
        if ((-eps < a && a < eps)||
            double.IsInfinity(a) || double.IsInfinity(b) ||
            double.IsInfinity(c) || double.IsNaN(a) ||
            double.IsNaN(b) || double.IsNaN(c))                                                 
        {
            throw new System.ArgumentException();
        }
        b = b/a;
        c = c/a;
        double discriminant = Math.Pow(b, 2) - 4 * c;
        if (discriminant <= -eps)
        {
            answer = new double [0];
            return answer;
        }
        else if (Math.Abs(discriminant)<eps)
        {
            answer = new double [1] { -b / 2 };
            return answer;
        }
        else
        {
            x1 = -(b + Math.Sign(b) * Math.Sqrt(discriminant)) / 2;
            x2 = c / x1;
            answer = new double [2] { x1, x2 };
            return answer;
        }
    }
}