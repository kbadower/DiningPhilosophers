
public class Philosopher
{
    private readonly int _id;
    private const int _timesToEat = 5;
    private int _timesEaten = 0;
    private readonly List<Philosopher> _allPhilosophers;

    public Philosopher(List<Philosopher> allPhilosophers, int id)
    {
        _allPhilosophers = allPhilosophers;
        _id = id;
    }

    public Fork LeftFork { get; set; }
    public Fork RightFork { get; set; }

    public Philosopher LeftPhilosopher
    {
        get
        {
            return _allPhilosophers[(_id - 1 + _allPhilosophers.Count) % _allPhilosophers.Count];
        }
    }

    public Philosopher RightPhilosopher
    {
        get
        {
            return _allPhilosophers[(_id + 1) % _allPhilosophers.Count];
        }
    }

    public void Dine()
    {
        while (_timesEaten < _timesToEat)
        {
            Think();
            if (PickUpForks())
            {
                Eat();
                PutDownLeftFork();
                PutDownRightFork();
            }
        }
    }

    private void Think()
    {
        Random random = new Random();
        var thinkDuration = random.Next(500, 1000);
        Console.WriteLine($"Philosopher {_id} is thinking for {thinkDuration}ms.");
        Thread.Sleep(thinkDuration);
    }

    private bool PickUpForks()
    {
        if (Monitor.TryEnter(LeftFork))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Philosopher {_id} picks up left fork.");
            Console.ForegroundColor = ConsoleColor.White;

            if (Monitor.TryEnter(RightFork))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Philosopher {_id} picks up right fork.");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                PutDownLeftFork();
            }
        }

        return false;
    }

    private void Eat()
    {
        _timesEaten++;
        Console.WriteLine($"Philosopher {_id} eats.");
        Thread.Sleep(1000);

    }

    private void PutDownLeftFork()
    {
        Monitor.Exit(LeftFork);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Philosopher {_id} puts down left fork.");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void PutDownRightFork()
    {
        Monitor.Exit(RightFork);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Philosopher {_id} puts down right fork.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
