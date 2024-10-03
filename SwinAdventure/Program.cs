using System;
using System.Text.RegularExpressions;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Swin Adventure!");
            Console.WriteLine();

            Console.WriteLine("Please enter player name: ");
            string playerName = Console.ReadLine();

            Console.WriteLine("Please enter player description: ");
            string playerDescription = Console.ReadLine();



            Player player = new Player(playerName, playerDescription);

            Item diamondSword = new Item(new string[] { "sword" }, "a diamond sword", "A sharp Diamond Sword");
            Item silverShovel = new Item(new string[] { "shovel" }, "a silver shovel", "A strong Silver Shovel");

            player.Inventory.Put(diamondSword);
            player.Inventory.Put(silverShovel);


            Bag bag = new Bag(new string[] { "bag", "leather" }, "brown bag", "A brown leather bag");

            player.Inventory.Put(bag);

            Item redGem = new Item(new string[] { "gem" }, "a red gem", "A powerful gem that glows with power");

            bag.Inventory.Put(redGem);


            Command lookCommand = new LookCommand();

            string userInput;

            Console.WriteLine();
            Console.WriteLine("Please enter your command(s)");
            Console.WriteLine("Note:Please enter 'quit' to exit");

            Console.WriteLine();

            while (true)
            {
                Console.Write("Command -> ");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "quit")
                {
                    Console.WriteLine("Bye.");
                    break;
                }
                else
                {
                    Console.WriteLine(lookCommand.Execute(player, userInput.Split(" "))); 
                }

            }
        }
    }
}




