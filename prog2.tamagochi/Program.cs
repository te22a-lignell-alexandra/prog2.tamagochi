using System.Xml.Serialization;

Tamagotchi tamagotchi = new();

while (tamagotchi.Name.Length == 0)
{
    tamagotchi.Name = Console.ReadLine();
}

Console.WriteLine("Interact!");
Console.WriteLine("1. Chat \n2. Teach new word \n3. Feed \n4. Do Nothing");
string choice = Console.ReadLine();

while (choice.Length == 0 || choice.Length > 1)
{
    Console.WriteLine("Write 1, 2, 3 or 4");
    choice = Console.ReadLine();
}

if (choice == "1") tamagotchi.Hi();
else if (choice == "2") tamagotchi.TeachWord();
Console.ReadLine();