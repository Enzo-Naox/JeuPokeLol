using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Numerics;
#pragma warning disable CS8600 
#pragma warning disable IDE0060
#pragma warning disable CA1050

public static class CombatManagement
{
    //FONCTION DE COMBAT CONTRE UN DRESSEUR
    public static string CombatDresseur(Player player,Player ennemy, Pokelol joueur1, Pokelol joueur2, int index, int index_dresseur)
    {
        string vainqueur = "";
        Console.Clear();
        if (joueur1.Stats.Vitesse > joueur2.Stats.Vitesse)
        {

            while (joueur1.Stats.Vie > 0 && joueur2.Stats.Vie > 0 || FuiteReussie())
            {
                if (player.Position_x == 1 && player.Position_y == 1)
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
                    player.Team.Members[index].Experience_Acquis += 50;
                    player.Team.Members[index].MonterDeNiveau();
                    ennemy.Team.Members[index_dresseur].IsAlive = false;
                    ChoixPokemon(player, ennemy);
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
                if (player.Position_x == 1 && player.Position_y == 1)
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
                    player.Team.Members[index].Experience_Acquis += 50;
                    player.Team.Members[index].MonterDeNiveau();
                    ennemy.Team.Members[index_dresseur].IsAlive = false;
                    ChoixPokemon(player, ennemy);
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

    //FONCTION DE COMBAT CONTRE UN POKEMON SAUVAGE
    public static string CombatPokemon(Player player, Player ennemy, Pokelol joueur1, Pokelol joueur2, int index, int index_pokelol)
    {
        string vainqueur = "";
        Console.Clear();
        if (joueur1.Stats.Vitesse > joueur2.Stats.Vitesse)
        {

            while (joueur1.Stats.Vie > 0 && joueur2.Stats.Vie > 0)
            {
                if (player.Capture)
                {
                    vainqueur = "";
                    player.Capture = false;
                    Thread.Sleep(3000); // Pause pendant 3 secondes
                    return vainqueur;
                }

                if (player.Position_x == 1 && player.Position_y == 1)
                {
                    Console.WriteLine("Vous avez réussi à fuir ! Combat terminé.");
                    vainqueur = "Ennemi";
                    Console.WriteLine($"Le vainqueur est : {vainqueur}");
                    Thread.Sleep(3000); // Pause pendant 5 secondes
                    return vainqueur;
                }
                TourJoueurPokemon(player, ennemy, joueur1, joueur2,index_pokelol);
                TourEnnemi(player, joueur1, joueur2);
                if (joueur2.Stats.Vie <= 0)
                {
                    vainqueur = "Joueur";
                    player.Team.Members[index].Experience_Acquis += 50;
                    player.Team.Members[index].MonterDeNiveau();
                    if (joueur2.Name == "Pikaren")
                    {
                        joueur2.DefinirStatistiques(233, 183, 147, 151);
                    }
                    if (joueur2.Name == "Ectoplari")
                    {
                        joueur2.DefinirStatistiques(213, 162, 142, 182);
                    }
                    if (joueur2.Name == "Swainquaza")
                    {
                        joueur2.DefinirStatistiques(212, 202, 142, 147);
                    }
                    if (joueur2.Name == "Ahram")
                    {
                        joueur2.DefinirStatistiques(207, 137, 152, 187);
                    }
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
            while (joueur1.Stats.Vie > 0 && joueur2.Stats.Vie > 0)
            {
                if (player.Capture)
                {
                    vainqueur = "";
                    player.Capture = false;
                    Thread.Sleep(3000); // Pause pendant 3 secondes
                    return vainqueur;
                }

                if (player.Position_x == 1 && player.Position_y == 1)
                {
                    Console.WriteLine("Vous avez réussi à fuir ! Combat terminé.");
                    vainqueur = "Ennemi";
                    Console.WriteLine($"Le vainqueur est : {vainqueur}");
                    Thread.Sleep(3000); // Pause pendant 5 secondes
                    return vainqueur;
                }

                TourEnnemi(player, joueur1, joueur2);
                TourJoueurPokemon(player, ennemy, joueur1, joueur2,index_pokelol);
                if (joueur2.Stats.Vie <= 0)
                {
                    vainqueur = "Joueur";
                    player.Team.Members[index].Experience_Acquis += 50;
                    player.Team.Members[index].MonterDeNiveau();
                    if (joueur2.Name == "Pikaren")
                    {
                        joueur2.DefinirStatistiques(233, 183, 147, 151);
                    }
                    if (joueur2.Name == "Ectoplari")
                    {
                        joueur2.DefinirStatistiques(213, 162, 142, 182);
                    }
                    if (joueur2.Name == "Swainquaza")
                    {
                        joueur2.DefinirStatistiques(212, 202, 142, 147);
                    }
                    if (joueur2.Name == "Ahram")
                    {
                        joueur2.DefinirStatistiques(207, 137, 152, 187);
                    }
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
        Thread.Sleep(3000); // Pause pendant 3 secondes
        return vainqueur;
    }

    
    //CHOIX DU POKEMON JOUEUR ET DEFINTION DU PREMIER POKEMON DRESSEUR/POKEMON SAUVAGE
    public static void ChoixPokemon(Player player, Player ennemy)
    {
        player.Team.ShowTeam();
        Console.WriteLine("choisi un pokemon pour combattre");
        string choix_equipe = Console.ReadLine();
        int result = Convert.ToInt32(choix_equipe) - 1;

        Random rand_dresseur = new();
        int random_dresseur = rand_dresseur.Next(0, 3);
        CombatManagement.CombatDresseur(player,ennemy, player.Team.Members[result], ennemy.Team.Members[random_dresseur], result, random_dresseur);
    }

    
    //TOUR DU JOUEUR CONTRE UN POKEMON
    private static void TourJoueurPokemon(Player player, Player ennemy, Pokelol joueur1, Pokelol joueur2,int index_pokelol)
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
                Afficher_stats(joueur1, joueur2);
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
                            Console.WriteLine($"{joueur2.Name} a été attrapé !!");
                            Console.WriteLine($"{joueur2.Name} a rejoint votre équipe");
                            player.Team.AddMember(ennemy.Team.Members[index_pokelol]);
                            Thread.Sleep(1500); // Pause pendant 1.5 secondes
                            player.Capture = true;
                        }

                        else
                        {
                            Console.WriteLine($"{joueur2.Name} est sortie de la pokéball");
                        }
                        break;
                }
                    
                break;
            case "3":
                if (FuiteReussie())
                {
                    player.Position_x = 1;
                    player.Position_y = 1;
                }
                else
                {
                    Console.WriteLine("La fuite a échoué ! Tour de l'ennemi.");
                }
                break;
                
        }
    }

    //TOUR DU JOUEUR CONTRE UN DRESSEUR
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
                Afficher_stats(joueur1, joueur2);
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
                    player.Position_x = 1;
                    player.Position_y = 1;
                }
                else
                {
                    Console.WriteLine("La fuite a échoué ! Tour de l'ennemi.");
                }
                break;

        }
    }

    //IA DE L'ENNEMI
    private static void TourEnnemi(Player player, Pokelol joueur1, Pokelol joueur2)
    {
        Console.WriteLine("TOUR DE L'ENNEMI");
        Random random = new();
        int randomAbility = random.Next(0, 2);
        AppliquerEffetCapacite(joueur2, joueur1, randomAbility);
        Afficher_stats(joueur1, joueur2);
    }

    //FONCTION PERMETTANT DE GERER LES CHANGEMENTS DE STATS
    private static void AppliquerEffetCapacite(Pokelol Attaquant, Pokelol Defenseur, int res)
    {
        switch (Attaquant.Capacites[res].Type_capacite)
        {
            case "Degat":
                Defenseur.Stats.Vie -= Calcul_degat(Attaquant, Defenseur, res);
                Console.WriteLine(Defenseur.Name + " perd " + Calcul_degat(Attaquant, Defenseur, res) + "point de vie");
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

    //FONCTION AFFICHAGE DE STATS
    private static void Afficher_stats(Pokelol Joueur, Pokelol Ennemi)
    {
        Console.WriteLine(Joueur.Name + " Vie: " + Joueur.Stats.Vie + " || Attaque: " + Joueur.Stats.Attaque + " || Defense: " + Joueur.Stats.Defense + " || Speed: " + Joueur.Stats.Vitesse + "\n");

        Console.WriteLine(Ennemi.Name + " Vie: " + Ennemi.Stats.Vie + " || Attaque: " + Ennemi.Stats.Attaque + " || Defense: " + Ennemi.Stats.Defense + " || Speed: " + Ennemi.Stats.Vitesse + "\n");
    }


    //FONCTION DE CALCUL DES DEGATS
    private static float Calcul_degat(Pokelol Attanquant, Pokelol Defenseur, int i)
    {

        Random random = new();
        int randomValue = random.Next(0, 100);
        float coup_critique = 1.0f;

        if (randomValue <= 33)
        {
            Console.WriteLine("Coup critique");
            coup_critique = 1.5f;
        }

        float pv_perdu = (((Attanquant.Stats.Attaque * Attanquant.Capacites[i].Stats_capacite) / (Defenseur.Stats.Defense * 8 + 2)) * coup_critique);
        return pv_perdu;
    }


    //CREATION DE LA FONCTION DE CAPTURE 
    private static bool Capture()
    {
        Random random = new();
        return random.Next(0, 3) == 0; //30% DE CHANCE DE CAPTURE
        
    }


    //CREATION DE LA FONCTION FUITE
    private static bool FuiteReussie()
    {
        Random random = new();
        return random.Next(0, 1) == 0; //100% DE CHANCE DE FUITE
    }
        
}


