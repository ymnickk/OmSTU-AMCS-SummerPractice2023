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
}