using System.Xml.Serialization;
Tamagotchi tamagotchi = new();
tamagotchi.NameYourFriend();

  
while (tamagotchi.GetAlive() == true)
{
    tamagotchi.Warning();
    tamagotchi.Interact();
    tamagotchi.InteractEnd();    
}