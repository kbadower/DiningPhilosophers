
public class Fork
{
    private static int _index = 1;
    public string Name { get; private set; }

    public Fork()
    {
        Name = "Fork " + _index++;
    }
}