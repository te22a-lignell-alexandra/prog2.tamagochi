using System.ComponentModel;

public class Tamagotchi
{
    public string Name;

    private int hunger = 0;
    private int boredom = 0;
    private List<string> words = new();
    private bool isAlive = true;
    private Random generator = new();

    public void Feed()
    {
        hunger--;
    }
    public void Hi()
    {
        int i = generator.Next(words.Count);
        Console.WriteLine(words[i]);

        ReduceBoredom();
    }
    public void TeachWord()
    {
        string newWord = "";
        while (newWord.Length == 0)
        {
            newWord = Console.ReadLine();
        }

        words.Add(newWord);

        ReduceBoredom();
    }
    public void Tick()
    {
        hunger++;
        boredom++;

        if (hunger == 10 || boredom == 10) 
        {
            isAlive = false;
        }
    }
    public void PrintStats()
    {
        Console.WriteLine($"hunger: {hunger}");
        Console.WriteLine($"boredom: {boredom}");
        if (isAlive == true) Console.WriteLine($"Is alive");
        else Console.WriteLine("Is dead");
    }
    public bool GetAlive()
    {
        return isAlive;
    }
    private void ReduceBoredom()
    {
        boredom--;
    }
}