namespace SpaceShip;

public class Space_ship
{
    public int hp = 100;
    public int damage = 15;

    public void Get_Damage(int damage)
    {
        hp -= damage;
    }

    public void Reset_Values()
    {
        hp = 100;
        damage = 15;
    }
}


public class Pool<SHpool> where SHpool : new()
{
    Queue<SHpool> Ships = new Queue<SHpool>();
    int count;

    public Pool(int count)
    {
        this.count = count;

        for (int i = 0; i < count; i++)
        {
            Ships.Enqueue(new SHpool());
        }
    }

    public SHpool Get_Object()
    {
        return Ships.Dequeue();
    }

    public void Release_Object(SHpool ship)
    {
        if(Ships.Count == count)
            throw new InvalidOperationException("пул заполнен");
        else
        {
            Ships.Enqueue(ship);
        }
    }
}



public class PoolGuard<SHpool> : IDisposable where SHpool : new()
{
    Pool<SHpool> pool;
    SHpool ship;
    public PoolGuard(Pool<SHpool> pool)
    {
        ship = pool.Get_Object();
        this.pool = pool;
    }

    public void Dispose()
    {
        pool.Release_Object(ship);
    }

    public SHpool Get_Object()
    {
        return ship;
    }
}