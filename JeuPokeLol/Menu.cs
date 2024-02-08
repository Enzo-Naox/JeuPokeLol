using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8600 
#pragma warning disable CA1050

public static class MenuManager
{

    public static void Menu(Player player)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("E. Team");
            Console.WriteLine("I. Inventory");
            Console.WriteLine("W. Combat");
            Console.WriteLine("Q. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "e":
                    Console.Clear();
                    player.Team.ShowTeam();
                    break;

                case "i":
                    Console.Clear();
                    player.Inventory.ShowInventory();
                    break;

                case "p":

                    break;
                case "q":
                    Console.WriteLine("Goodbye!");
                    return;



                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;

            }

            Console.ReadLine();
        }
    }
}
    
