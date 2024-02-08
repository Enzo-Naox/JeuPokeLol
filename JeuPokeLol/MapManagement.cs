using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8600 
#pragma warning disable CS8618


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
        Random rand = new();
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

        for (int i = 0; i < 1; i++) // Placez deux 'D' pour cet exemple
        {
            int randomX = rand.Next(1, width - 1);
            int randomY = rand.Next(1, height - 1);

            // Vérifiez si la case est vide (".") avant de placer le 'D'
            if (map[randomY, randomX] == ".")
            {
                map[randomY, randomX] = "C";
            }
        }
    }

    public static void DrawMap(Player player)
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (x == player.Position_x && y == player.Position_y)
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
        if (map[player.Position_y, player.Position_x] == "D")
        {
            
            map[player.Position_y, player.Position_x] = ".";

            Random rand = new();
            int newX, newY;
            do
            {
                newX = rand.Next(1, map.GetLength(1) - 1);
                newY = rand.Next(1, map.GetLength(0) - 1);
            } while (map[newY, newX] != ".");

            // Place 'D' at the new position
            map[newY, newX] = "D";


            CombatManagement.ChoixPokemon(player, ennemy);
        }
    }

    public static void CentrePokemon(Player player)
    {
        // Check if the player is on a 'C' tile
        if (map[player.Position_y, player.Position_x] == "C")
        {
            foreach (var member in player.Team.Members)
            {
                if (member.Name == "Pikaren")
                {
                    member.Stats.Vie = 233 + (15 * member.Level);
                    member.Stats.Defense = 147 + (3 * member.Level);
                    member.Stats.Attaque = 183 + (5 * member.Level);
                    member.Stats.Vitesse = 151;
                    
                }
                if (member.Name == "Ectoplari")
                {
                    member.Stats.Vie = 213 + (15 * member.Level);
                    member.Stats.Defense = 142 + (3 * member.Level);
                    member.Stats.Attaque = 162 + (5 * member.Level);
                    member.Stats.Vitesse = 182; 
                }
                if (member.Name == "Swainquaza")
                {
                    member.Stats.Vie = 212 + (15 * member.Level);
                    member.Stats.Defense = 142 + (3 * member.Level);
                    member.Stats.Attaque = 202 + (5 * member.Level);
                    member.Stats.Vitesse = 147; 
                }
                if (member.Name == "Ahram")
                {
                    member.Stats.Vie = 207 + (15 * member.Level);
                    member.Stats.Defense = 152 + (3 * member.Level);
                    member.Stats.Attaque = 137 + (5 * member.Level);
                    member.Stats.Vitesse = 187;
                }
            }
            Console.WriteLine("les pokemons ont été soignés");
            Thread.Sleep(00);
        }
    }

    public static void CheckPokemonCombat(Player player, Player pokelol)
    {
        // Check if the player is on a 'D' tile
        if (map[player.Position_y, player.Position_x] == "S")
        {

            map[player.Position_y, player.Position_x] = ".";

            Random rand = new();
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


            Random random_pokelol = new();
            int rand_pokelol = random_pokelol.Next(0, 3);
            CombatManagement.CombatPokemon(player, pokelol, player.Team.Members[result], pokelol.Team.Members[rand_pokelol], result, rand_pokelol);
            
        }
    } 

    public static void MovePlayer(Player player,Player ennemy, Player pokelol, ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (player.Position_y - 1 >= 0 && map[player.Position_y - 1, player.Position_x] != "#")
                    player.Position_y--;
                break;

            case ConsoleKey.DownArrow:
                if (player.Position_y + 1 < map.GetLength(0) && map[player.Position_y + 1, player.Position_x] != "#")
                    player.Position_y++;
                break;

            case ConsoleKey.LeftArrow:
                if (player.Position_x - 1 >= 0 && map[player.Position_y, player.Position_x - 1] != "#")
                    player.Position_x--;
                break;

            case ConsoleKey.RightArrow:
                if (player.Position_x + 1 < map.GetLength(1) && map[player.Position_y, player.Position_x + 1] != "#")
                    player.Position_x++;
                break;
        }

        CheckDresseurCombat(player, ennemy);
        CheckPokemonCombat(player, pokelol);
        CentrePokemon(player);


    }
}
