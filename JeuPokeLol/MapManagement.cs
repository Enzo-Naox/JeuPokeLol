using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class MapManagement
{
    static string[,] map;

    public static void GenerateMap(int width, int height)
    {
        map = new string[height, width];

        // Remplir les bords de la carte avec des '#'
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y == 0 || y == height - 1 || x == 0 || x == width - 1)
                {
                    map[y, x] = "#";
                }
                else
                {
                    map[y, x] = ".";
                }
            }
        }

        // Placer aléatoirement des 'D' sur la carte (à l'intérieur des bords)
        Random rand = new Random();
        for (int i = 0; i < 3; i++) // Placez deux 'D' pour cet exemple
        {
            int randomX = rand.Next(1, width - 1);
            int randomY = rand.Next(1, height - 1);

            // Vérifiez si la case est vide (".") avant de placer le 'D'
            if (map[randomY, randomX] == ".")
            {
                map[randomY, randomX] = "D";
            }
        }

        for (int i = 0; i < 5; i++) // Placez deux 'D' pour cet exemple
        {
            int randomX = rand.Next(1, width - 1);
            int randomY = rand.Next(1, height - 1);

            // Vérifiez si la case est vide (".") avant de placer le 'D'
            if (map[randomY, randomX] == ".")
            {
                map[randomY, randomX] = "S";
            }
        }
    }

    public static void DrawMap(Player player)
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (x == player.position_x && y == player.position_y)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Couleur du joueur
                    Console.Write('P');
                }
                else
                {
                    Console.Write(map[y, x]);
                }

                Console.Write(' ');
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    public static void CheckDresseurCombat(Player player, Player ennemy)
    {
        // Check if the player is on a 'D' tile
        if (map[player.position_y, player.position_x] == "D")
        {

            map[player.position_y, player.position_x] = ".";

            Random rand = new Random();
            int newX, newY;
            do
            {
                newX = rand.Next(1, map.GetLength(1) - 1);
                newY = rand.Next(1, map.GetLength(0) - 1);
            } while (map[newY, newX] != ".");

            // Place 'D' at the new position
            map[newY, newX] = "D";


            CombatManager.ChoixPokemon(player, ennemy);
        }
    }

    public static void CheckPokemonCombat(Player player, Player pokelol)
    {
        // Check if the player is on a 'D' tile
        if (map[player.position_y, player.position_x] == "S")
        {

            map[player.position_y, player.position_x] = ".";

            Random rand = new Random();
            int newX, newY;
            do
            {
                newX = rand.Next(1, map.GetLength(1) - 1);
                newY = rand.Next(1, map.GetLength(0) - 1);
            } while (map[newY, newX] != ".");

            // Place 'D' at the new position
            map[newY, newX] = "S";


            player.Team.ShowTeam();
            Console.WriteLine("choisi un pokemon pour combattre");
            string choix_equipe = Console.ReadLine();
            int result = Convert.ToInt32(choix_equipe) - 1;


            Random random_pokelol = new Random();
            int rand_pokelol = random_pokelol.Next(0, 3);
            CombatManager.CombatPokemon(player, pokelol, player.Team.Members[result], pokelol.Team.Members[rand_pokelol], result, rand_pokelol);
            
        }
    } 

    public static void MovePlayer(Player player,Player ennemy, Player pokelol, ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (player.position_y - 1 >= 0 && map[player.position_y - 1, player.position_x] != "#")
                    player.position_y--;
                break;

            case ConsoleKey.DownArrow:
                if (player.position_y + 1 < map.GetLength(0) && map[player.position_y + 1, player.position_x] != "#")
                    player.position_y++;
                break;

            case ConsoleKey.LeftArrow:
                if (player.position_x - 1 >= 0 && map[player.position_y, player.position_x - 1] != "#")
                    player.position_x--;
                break;

            case ConsoleKey.RightArrow:
                if (player.position_x + 1 < map.GetLength(1) && map[player.position_y, player.position_x + 1] != "#")
                    player.position_x++;
                break;
        }

        CheckDresseurCombat(player, ennemy);
        CheckPokemonCombat(player, pokelol);
    }
}

