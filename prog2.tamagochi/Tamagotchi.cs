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
        string text = "\nYou: Hi!";
        Type(text);

        if (words.Count == 0) 
        {
            text = $"{Name}: .....\n({Name} stares at you in betrayal and boredom. How could you mock them this way? You fowl person. They can't talk yet!)";
            Type(text);
            boredom += 3;
        }
        else
        { 
            int i = generator.Next(words.Count);
            text = $"{Name}: " + words[i] + ".";
            Type(text);
        }

        ReduceBoredom();
    }
    public void TeachWord()
    {
        Console.Clear();
        string text = $"Which word do you want to teach {Name}";
        Type(text);
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
        string text = $"\n{Name}'s current stats:";
        Type(text);
        text = $"hunger: {hunger}";
        Type(text);
        text = $"boredom: {boredom}";
        Type(text);
        text = "vocabulary: ";
        Type(text);
        for (int i = 0; i < words.Count; i++)
        {
            text = i+1 + ". " + words[i];
            Type(text);
        }

        if (isAlive == true) 
        {
            text = $"{Name} is alive";
            Type(text);
        }
        else 
        {
            text = $"{Name} is dead";
            Type(text);
        }
    }
    public void Warning()
    {
        if (hunger > 7 || boredom > 7)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string text = "";

            if (hunger > 7)
            {
                text = "Your tamagotchi dies if hunger reaches 10";
                Type(text);
            }
            if (boredom > 7)
            {
                text = "Your tamagotchi dies if boredom reaches 10";
                Type(text);
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
        string text = "What is your tamagotchi called?";
        Type(text);
        while (Name.Length == 0)
        {
        Name = Console.ReadLine();
        }
        Console.ReadLine();
        Console.Clear();
    }
    public void Interact()
    {
        string text = "Interact!";
        Type(text);
        text = $"1. Chat with {Name} \n2. Teach {Name} a new word \n3. Feed {Name} \n4. Do Nothing";
        Type(text);
        string choice = Console.ReadLine();

    while (choice!="1" && choice!="2" && choice!="3" && choice!="4")
    // Borde gå att göra bättre på något sätt
    {
        text = "Write 1, 2, 3 or 4";
        Type(text);
        choice = Console.ReadLine();
    }

    if (choice == "1") Hi();
    else if (choice == "2") TeachWord();
    else if (choice == "3") Feed();
    else if (choice == "4") 
    {
        text = "......uuuh okay then. Moving on.";
        Type(text);
    }
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
        string text = $"{Name} has tragically past away...because of you. Do you feel bad?......... Well you should. Game Over.";
        Type(text);
    }

    private void Type(string text) /*Typing effect on text parts*/
    {
        foreach (char i in text)
        {
            Console.Write(i);
            Thread.Sleep(generator.Next(30, 80));
        }
        Console.Write("\n");
    }
}
