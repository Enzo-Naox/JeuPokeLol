using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;

float calcul_degat(Pokelol Attanquant, Pokelol Defenseur, int i)
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

void AppliquerEffetCapacite(Pokelol Attaquant, Pokelol Defenseur, int res)
{
    switch (Attaquant.Capacites[res].Type_capacite)
    {
        case "Degat":
            Defenseur.Stats.Vie -= calcul_degat(Attaquant, Defenseur, res);
            Console.WriteLine(Defenseur.Name+ " perd " + calcul_degat(Attaquant, Defenseur, res) + "point de vie");
            Console.WriteLine();
            break;
        case "Attaque-":
            Defenseur.Stats.Attaque *= Attaquant.Capacites[res].Stats_capacite;
            Console.WriteLine(Defenseur.Name + " perd " +  (100-100*Attaquant.Capacites[res].Stats_capacite) + "% d'attaque");
            Console.WriteLine();
            break;
        case "Speed+":
            Attaquant.Stats.Vitesse *= Attaquant.Capacites[res].Stats_capacite;
            Console.WriteLine(Attaquant.Name + " augmente sa vitesse de " + (100*Attaquant.Capacites[res].Stats_capacite-100) + "%");
            Console.WriteLine();
            break;
        case "Speed-":
            Defenseur.Stats.Vitesse *= Attaquant.Capacites[res].Stats_capacite;
            Console.WriteLine(Defenseur.Name + " perd " + (100-100*Attaquant.Capacites[res].Stats_capacite) + "% de vitesse");
            Console.WriteLine();
            break;
        case "Defense+":
            Attaquant.Stats.Defense *= Attaquant.Capacites[res].Stats_capacite;
            Console.WriteLine(Attaquant.Name + " augmente sa defense de " + (100*Attaquant.Capacites[res].Stats_capacite-100) + "%");
            Console.WriteLine();
            break;
        default:
            Console.WriteLine("Type de capacité inconnu");
            break;
    }
}


void afficher_stats(Pokelol Joueur, Pokelol Ennemi)
{
    Console.WriteLine(Joueur.Name+ " Vie: " + Joueur.Stats.Vie + " || Attaque: " + Joueur.Stats.Attaque + " || Defense: " + Joueur.Stats.Defense + " || Speed: " + Joueur.Stats.Vitesse + "\n");

    Console.WriteLine(Ennemi.Name+ " Vie: " + Ennemi.Stats.Vie + " || Attaque: " + Ennemi.Stats.Attaque + " || Defense: " + Ennemi.Stats.Defense + " || Speed: " + Ennemi.Stats.Vitesse + "\n");
}


void Combat(Pokelol joueur1, Pokelol joueur2)
{
    while (joueur1.Stats.Vie > 0 && joueur2.Stats.Vie > 0)
    {
        TourJoueur(joueur1, joueur2);
        if (joueur2.Stats.Vie <= 0)
            break;
        TourEnnemi(joueur1, joueur2);
    }
}

void TourJoueur(Pokelol joueur1, Pokelol joueur2)
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
            // Gérer l'utilisation d'objets
            break;
        case "3":
            // Gérer la fuite
            break;
    }
}

void TourEnnemi(Pokelol joueur1, Pokelol joueur2)
{
    Console.WriteLine("TOUR DE L'ENNEMI");
    Random random = new Random();
    int randomAbility = random.Next(0, 2);
    AppliquerEffetCapacite(joueur2, joueur1, randomAbility);
    afficher_stats(joueur1, joueur2);
}

class Programme
{



    static void Main()
    {
        //CREATION D'UN NOUVEAU JOUEUR
        Player player = new Player("Player");

        //DEFINITION DES POKELOL ET DE LEURS STATISTIQUES
        Pokelol Pikaren = new("Pikaren");
        Pikaren.DefinirStatistiques(233, 183, 147, 151);
        Pokelol Ectoplari = new("Ectoplari");
        Ectoplari.DefinirStatistiques(213, 162, 142, 182);
        Pokelol Swainquaza = new("Swainquaza");
        Swainquaza.DefinirStatistiques(212, 202, 142, 147);
        Pokelol Ahram = new("Ahram");
        Ahram.DefinirStatistiques(207, 137, 152, 187);

        //CAPACITE DE PIKAREN
        Pokelol.Capacite Pikaren_capacite1 = new("Elekdemacia = ", " Inflige des degats (80 puissance)", 80, "Degat");
        Pokelol.Capacite Pikaren_capacite2 = new("Pikarush = ", "Augmente la vitesse de 15%", 1.15f, "Speed+");
        Pokelol.Capacite Pikaren_capacite3 = new("Gabri = ", "Augmente la defense de 30%", 1.3f, "Defense+");

        //CAPACITE DE ECTOPLARI
        Pokelol.Capacite Ectoplari_capacite1 = new("LaserOmbre = ", "Inflige des degats(110 puissance)", 110, "Degat");
        Pokelol.Capacite Ectoplari_capacite2 = new("Exploplasma = ", "Inflige des degats(90 puissance)", 90, "Degat");
        Pokelol.Capacite Ectoplari_capacite3 = new("Taclebas = ", "Baisse la vitesse de l'ennemi de 20% ", 0.8f, "Speed-");

        //CAPACITE DE SWAINQUAZA
        Pokelol.Capacite Swainquaza_capacite1 = new("CorbeauMeteore = ", "Inflige des degats(150 puissance)", 150, "Degat");
        Pokelol.Capacite Swainquaza_capacite2 = new("GriffeAscension = ", "Inflige des degats(110 puissance)", 110, "Degat");
        Pokelol.Capacite Swainquaza_capacite3 = new("OeilViolent = ", "Inflige des degats(90 puissance)", 90, "Degat");

        //CAPACITE DE AHRAM
        Pokelol.Capacite Ahram_capacite1 = new("FlammeCharme = ", " Baisse l'attaque de l'adversaire de 30% ", 0.85f, "Attaque-");
        Pokelol.Capacite Ahram_capacite2 = new("Dracoboule = ", "Inflige des degats(85 puissance)", 85, "Degat");
        Pokelol.Capacite Ahram_capacite3 = new("Kitsucharge = ", "Augmente la vitesse de 30% ", 1.3f, "Speed+");

        Pikaren.AddCapacite(Pikaren_capacite1);
        Pikaren.AddCapacite(Pikaren_capacite2);
        Pikaren.AddCapacite(Pikaren_capacite3);

        Ectoplari.AddCapacite(Ectoplari_capacite1);
        Ectoplari.AddCapacite(Ectoplari_capacite2);
        Ectoplari.AddCapacite(Ectoplari_capacite3);

        Swainquaza.AddCapacite(Swainquaza_capacite1);
        Swainquaza.AddCapacite(Swainquaza_capacite2);
        Swainquaza.AddCapacite(Swainquaza_capacite3);

        Ahram.AddCapacite(Ahram_capacite1);
        Ahram.AddCapacite(Ahram_capacite2);
        Ahram.AddCapacite(Ahram_capacite3);


        player.Team.AddMember(Pikaren);
        player.Team.AddMember(Swainquaza);

        Item potion1 = new Item { Name = "Healing Potion" };
        Item potion2 = new Item { Name = "Mana Potion" };

        player.Inventory.AddItem(potion1);
        player.Inventory.AddItem(potion2);
        player.Team.Members[0];

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

                case "q":
                    Console.WriteLine("Goodbye!");
                    return;

                case "w":
                    player.Team.ShowTeam();
                    Console.WriteLine("choisi un pokemon pour combattre");
                    string choix_equipe = Console.ReadLine();
                    int result = Convert.ToInt32(choix_equipe) - 1;
                    Combat(player.Team.Members[result], Ahram);
                    return;

                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;

            }

            Console.ReadLine();
        }
    }
}




