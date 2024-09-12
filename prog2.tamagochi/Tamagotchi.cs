using System.ComponentModel;

public class Tamagotchi
{
    public string Name = "";

    private int hunger = 0;
    private int boredom = 0;
    private List<string> words = new();
    private bool isAlive = true;
    private Random generator = new();

    public void Feed()
    {
        if (hunger > 0) hunger -= 2;
        else hunger --;
    }
    public void Hi()
    {
        int i = generator.Next(words.Count);
        Console.WriteLine(words[i]);

        ReduceBoredom();
    }
    public void TeachWord()
    {
        Console.Clear();
        Console.WriteLine($"Which word do you want to teach {Name}");
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
    public void Warning()
    {
        if (hunger > 7 || boredom > 7)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
            if (hunger > 7)
            {
                Console.WriteLine("Your tamagotchi dies if hunger reaches 10");
            }
            if (boredom > 7)
            {
                Console.WriteLine("Your tamagotchi dies if boredom reaches 10");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    public bool GetAlive()
    {
        return isAlive;
    }
    private void ReduceBoredom()
    {
        if (boredom > 0) boredom -= 2;
        else boredom--;
    }

    public void NameYourFriend()
    {
        Console.WriteLine("What is your tamagotchi called?");
        while (Name.Length == 0)
        {
        Name = Console.ReadLine();
        }
        Console.ReadLine();
        Console.Clear();
    }
    public void Interact()
    {
        Console.WriteLine("Interact!");
        Console.WriteLine($"1. Chat with {Name} \n2. Teach {Name} a new word \n3. Feed {Name} \n4. Do Nothing");
        string choice = Console.ReadLine();

    while (choice!="1" && choice!="2" && choice!="3" && choice!="4")
    // Borde gå att göra bättre på något sätt
    {
        Console.WriteLine("Write 1, 2, 3 or 4");
        choice = Console.ReadLine();
    }

    if (choice == "1") Hi();
    else if (choice == "2") TeachWord();
    else if (choice == "3") Feed();
    else if (choice == "4") Console.WriteLine("Really? K then.");
    }

    public void InteractEnd()
    {
        Tick();
        PrintStats();
        Console.ReadLine();
        Console.Clear();
    }

    public void EndScene()
    {
        Console.Clear();
        Console.WriteLine($"{Name} has ");
    }
}

// foreach (char i in STRING)
// {console.write(i)    thread.sleep(nån tid);}