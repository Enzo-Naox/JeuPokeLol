using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.ComponentModel;
using System.Numerics;

public static class CombatManager
{
    public static string CombatDresseur(Player player,Player ennemy, Pokelol joueur1, Pokelol joueur2, int index)
    {
        string vainqueur = "";
        Console.Clear();
        if (joueur1.Stats.Vitesse > joueur2.Stats.Vitesse)
        {

            while (joueur1.Stats.Vie > 0 && joueur2.Stats.Vie > 0 || FuiteReussie())
            {
                if (player.position_x == 1 && player.position_y == 1)
                {
                    Console.WriteLine("Vous avez réussi à fuir ! Combat terminé.");
                    vainqueur = "Ennemi";
                    Console.WriteLine($"Le vainqueur est : {vainqueur}");
                    Thread.Sleep(3000); // Pause pendant 5 secondes
                    return vainqueur;
                }
                TourJoueurDresseur(player, joueur1, joueur2, index);
                TourEnnemi(player, joueur1, joueur2);
                if (joueur2.Stats.Vie <= 0)
                {
                    vainqueur = "Joueur";
                    break; 
                }
                if (joueur1.Stats.Vie <= 0)
                {
                    vainqueur = "Ennemi";
                    player.Team.Members[index].IsAlive = false;
                    ChoixPokemon(player, ennemy);
                    break;
                }
                
                
            }

        }
        else
        {
            while (joueur1.Stats.Vie > 0 && joueur2.Stats.Vie > 0 || FuiteReussie())
            {
                if (player.position_x == 1 && player.position_y == 1)
                {
                    Console.WriteLine("Vous avez réussi à fuir ! Combat terminé.");
                    vainqueur = "Ennemi";
                    Console.WriteLine($"Le vainqueur est : {vainqueur}");
                    Thread.Sleep(3000); // Pause pendant 5 secondes
                    return vainqueur;
                }
                TourEnnemi(player, joueur1, joueur2);
                TourJoueurDresseur(player, joueur1, joueur2, index);
                if (joueur2.Stats.Vie <= 0)
                {

                    vainqueur = "Joueur";
                    break;
                }
                if (joueur1.Stats.Vie <= 0)
                {
                    vainqueur = "Ennemi";
                    player.Team.Members[index].IsAlive = false;
                    ChoixPokemon(player, ennemy);
                    break;
                }
            }
        }
        

        Console.WriteLine($"Le vainqueur est : {vainqueur}");
        Thread.Sleep(3000); // Pause pendant 5 secondes
        return vainqueur;
    }
    public static string CombatPokemon(Player player, Player ennemy, Pokelol joueur1, Pokelol joueur2, int index, int index_pokelol)
    {
        string vainqueur = "";
        Console.Clear();
        if (joueur1.Stats.Vitesse > joueur2.Stats.Vitesse)
        {

            while (joueur1.Stats.Vie > 0 && joueur2.Stats.Vie > 0 || FuiteReussie())
            {
                if (player.position_x == 1 && player.position_y == 1)
                {
                    Console.WriteLine("Vous avez réussi à fuir ! Combat terminé.");
                    vainqueur = "Ennemi";
                    Console.WriteLine($"Le vainqueur est : {vainqueur}");
                    Thread.Sleep(3000); // Pause pendant 5 secondes
                    return vainqueur;
                }
                TourJoueurPokemon(player, ennemy, joueur1, joueur2, index, index_pokelol);
                TourEnnemi(player, joueur1, joueur2);
                if (joueur2.Stats.Vie <= 0)
                {
                    vainqueur = "Joueur";
                    break;
                }
                if (joueur1.Stats.Vie <= 0)
                {
                    vainqueur = "Ennemi";
                    player.Team.Members[index].IsAlive = false;
                    ChoixPokemon(player, ennemy);
                    break;
                }


            }

        }
        else
        {
            while (joueur1.Stats.Vie > 0 && joueur2.Stats.Vie > 0 || FuiteReussie())
            {
                if (player.position_x == 1 && player.position_y == 1)
                {
                    Console.WriteLine("Vous avez réussi à fuir ! Combat terminé.");
                    vainqueur = "Ennemi";
                    Console.WriteLine($"Le vainqueur est : {vainqueur}");
                    Thread.Sleep(3000); // Pause pendant 5 secondes
                    return vainqueur;
                }
                TourEnnemi(player, joueur1, joueur2);
                TourJoueurPokemon(player, ennemy, joueur1, joueur2, index, index_pokelol);
                if (joueur2.Stats.Vie <= 0)
                {

                    vainqueur = "Joueur";
                    break;
                }
                if (joueur1.Stats.Vie <= 0)
                {
                    vainqueur = "Ennemi";
                    player.Team.Members[index].IsAlive = false;
                    ChoixPokemon(player, ennemy);
                    break;
                }
            }
        }


        Console.WriteLine($"Le vainqueur est : {vainqueur}");
        Thread.Sleep(3000); // Pause pendant 5 secondes
        return vainqueur;
    }

    private static bool FuiteReussie()
    {
        // Implémentez la logique pour déterminer si la fuite est réussie
        Random random = new Random();
        return random.Next(0, 2) == 0; // Exemple simple : 50% de chance de réussir à fuir
    }

    public static void ChoixPokemon(Player player, Player ennemy)
    {
        player.Team.ShowTeam();
        Console.WriteLine("choisi un pokemon pour combattre");
        string choix_equipe = Console.ReadLine();
        int result = Convert.ToInt32(choix_equipe) - 1;

        Random rand_dresseur = new Random();
        int random_dresseur = rand_dresseur.Next(0, 3);
        CombatManager.CombatDresseur(player,ennemy, player.Team.Members[result], ennemy.Team.Members[random_dresseur], result);
    }

    private static bool Capture()
    {
        // Implémentez la logique pour déterminer si la fuite est réussie
        Random random = new Random();
        return random.Next(0, 3) == 0; // Exemple simple : 30% de chance de réussir à fuir
    }

    private static void TourJoueurPokemon(Player player, Player ennemy, Pokelol joueur1, Pokelol joueur2, int index, int index_pokelol)
    {
        Console.WriteLine();
        Console.WriteLine("C'est à vous, que souhaitez-vous faire ?");
        Console.WriteLine("1- Attaques\n2- Objets\n3- Fuite\n");
        string choix = Console.ReadLine();
        switch (choix)
        {
            case "1":
                Console.WriteLine("Choisir parmi les compétences\n");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(joueur1.Capacites[i].Name_capacite + joueur1.Capacites[i].Description);
                }

                string value = Console.ReadLine();
                int res = Convert.ToInt32(value) - 1;
                Console.Clear();
                Console.WriteLine("TOUR DU JOUEUR");
                AppliquerEffetCapacite(joueur1, joueur2, res);
                afficher_stats(joueur1, joueur2);
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Selectionner l'objet à utilisé");
                player.Inventory.ShowInventory();
                string itemchoix = Console.ReadLine();
                switch (itemchoix)
                {
                    case "1":

                    case "2":
                        Console.WriteLine("Vous lancez une pokéball !!");
                        if (Capture())  
                        {
                            Console.WriteLine("Vous avez réussi à fuir ! Combat terminé.");
                            player.Team.AddMember(ennemy.Team.Members[index_pokelol]);
                            Thread.Sleep(3000); // Pause pendant 5 secondes
                            return;
                        }

                        else
                        {

                        }
                        break;
                }
                    
                break;
            case "3":
                if (FuiteReussie())
                {
                    player.position_x = 1;
                    player.position_y = 1;
                }
                else
                {
                    Console.WriteLine("La fuite a échoué ! Tour de l'ennemi.");
                }
                break;
                
        }
    }

    private static void TourJoueurDresseur(Player player, Pokelol joueur1, Pokelol joueur2, int index)
    {
        Console.WriteLine();
        Console.WriteLine("C'est à vous, que souhaitez-vous faire ?");
        Console.WriteLine("1- Attaques\n2- Objets\n3- Fuite\n");
        string choix = Console.ReadLine();
        switch (choix)
        {
            case "1":
                Console.WriteLine("Choisir parmi les compétences\n");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(joueur1.Capacites[i].Name_capacite + joueur1.Capacites[i].Description);
                }

                string value = Console.ReadLine();
                int res = Convert.ToInt32(value) - 1;
                Console.Clear();
                Console.WriteLine("TOUR DU JOUEUR");
                AppliquerEffetCapacite(joueur1, joueur2, res);
                afficher_stats(joueur1, joueur2);
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Selectionner l'objet à utilisé");
                player.Inventory.ShowInventory();
                string itemchoix = Console.ReadLine();
                switch (itemchoix)
                {
                    case "1":

                    case "2":
                        break;
                }

                break;
            case "3":
                if (FuiteReussie())
                {
                    player.position_x = 1;
                    player.position_y = 1;
                }
                else
                {
                    Console.WriteLine("La fuite a échoué ! Tour de l'ennemi.");
                }
                break;

        }
    }

    private static void TourEnnemi(Player player, Pokelol joueur1, Pokelol joueur2)
    {
        Console.WriteLine("TOUR DE L'ENNEMI");
        Random random = new Random();
        int randomAbility = random.Next(0, 2);
        AppliquerEffetCapacite(joueur2, joueur1, randomAbility);
        afficher_stats(joueur1, joueur2);
    }


    private static float calcul_degat(Pokelol Attanquant, Pokelol Defenseur, int i)
    {

        Random random = new Random();
        // Générer un nombre aléatoire entre 0 et 99 inclus
        int randomValue = random.Next(0, 100);
        float coup_critique = 1.0f;

        if (randomValue <= 33)
        {
            coup_critique = 1.5f;
        }

        float pv_perdu = (((Attanquant.Stats.Attaque * Attanquant.Capacites[i].Stats_capacite) / (Defenseur.Stats.Defense * 50 + 2)) * coup_critique);
        return pv_perdu;
    }

    private static void AppliquerEffetCapacite(Pokelol Attaquant, Pokelol Defenseur, int res)
    {
        switch (Attaquant.Capacites[res].Type_capacite)
        {
            case "Degat":
                Defenseur.Stats.Vie -= calcul_degat(Attaquant, Defenseur, res);
                Console.WriteLine(Defenseur.Name + " perd " + calcul_degat(Attaquant, Defenseur, res) + "point de vie");
                Console.WriteLine();
                break;
            case "Attaque-":
                Defenseur.Stats.Attaque *= Attaquant.Capacites[res].Stats_capacite;
                Console.WriteLine(Defenseur.Name + " perd " + (100 - 100 * Attaquant.Capacites[res].Stats_capacite) + "% d'attaque");
                Console.WriteLine();
                break;
            case "Speed+":
                Attaquant.Stats.Vitesse *= Attaquant.Capacites[res].Stats_capacite;
                Console.WriteLine(Attaquant.Name + " augmente sa vitesse de " + (100 * Attaquant.Capacites[res].Stats_capacite - 100) + "%");
                Console.WriteLine();
                break;
            case "Speed-":
                Defenseur.Stats.Vitesse *= Attaquant.Capacites[res].Stats_capacite;
                Console.WriteLine(Defenseur.Name + " perd " + (100 - 100 * Attaquant.Capacites[res].Stats_capacite) + "% de vitesse");
                Console.WriteLine();
                break;
            case "Defense+":
                Attaquant.Stats.Defense *= Attaquant.Capacites[res].Stats_capacite;
                Console.WriteLine(Attaquant.Name + " augmente sa defense de " + (100 * Attaquant.Capacites[res].Stats_capacite - 100) + "%");
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Type de capacité inconnu");
                break;
        }
    }

    private static void afficher_stats(Pokelol Joueur, Pokelol Ennemi)
    {
        Console.WriteLine(Joueur.Name + " Vie: " + Joueur.Stats.Vie + " || Attaque: " + Joueur.Stats.Attaque + " || Defense: " + Joueur.Stats.Defense + " || Speed: " + Joueur.Stats.Vitesse + "\n");

        Console.WriteLine(Ennemi.Name + " Vie: " + Ennemi.Stats.Vie + " || Attaque: " + Ennemi.Stats.Attaque + " || Defense: " + Ennemi.Stats.Defense + " || Speed: " + Ennemi.Stats.Vitesse + "\n");
    }
}


