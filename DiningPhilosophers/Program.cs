
public class Program
{
    private const int philosophersCount = 5;

    public static void Main(string[] args)
    {
        var philosophers = CreatePhilosophers();

        var threads = new List<Thread>();
        foreach (var philosopher in philosophers)
        {
            var thread = new Thread(new ThreadStart(philosopher.Dine));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("Program completed successfully.");

    }

    private static List<Philosopher> CreatePhilosophers()
    {

        var philosophers = new List<Philosopher>(philosophersCount);
        for (int i = 0; i < philosophersCount; i++)
        {
            philosophers.Add(new Philosopher(philosophers, i));
        }

        foreach (var philosopher in philosophers)
        {
            philosopher.LeftFork = philosopher.LeftPhilosopher.RightFork ?? new Fork();
            philosopher.RightFork = philosopher.RightPhilosopher.LeftFork ?? new Fork();
        }

        return philosophers;
    }
}
