namespace spacebattle;

public class SpaceShip
{
    public static double [] Move (bool isCanMove, bool isKnowSpeed,
    bool isKnowPosition, double [] Speed, double [] Position){
        if (!isCanMove || !isKnowSpeed || !isKnowPosition){
            throw new Exception();
        }
        double[] total = {Position[0] + Speed[0], Position[1] + Speed[1]};
        return total;
    }
 
    public static double Fuel (double fuel, double change_fuel){
        if (fuel < change_fuel){
            throw new Exception();
        }
        double total = fuel - change_fuel;
        return total;
    }


    public static double Turn (double corner, double change_angle,
     bool isKnowCorner, bool isKnowChangeAngle, bool isCanChangeAngle){
        if (!isKnowCorner || !isKnowChangeAngle || !isCanChangeAngle){
            throw new Exception();
        }
        double total = corner + change_angle;
        return total;
    }
}