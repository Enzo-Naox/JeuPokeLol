using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;



Pokelol Joueur = new("Pikachu", 1, 1, 1, 1);
Pokelol Ennemi = new("Pikachu", 1, 1, 1, 1);


Pokelol Pikaren = new("Pikaren", 233, 183, 147, 151);
Pokelol Ectoplari = new("Ectoplari", 213, 162, 142, 182);
Pokelol Swainquaza = new("Swainquaza", 212, 202, 142, 147);
Pokelol Ahram = new("Ahram", 207, 137, 152, 187);


//Creation de Capacités

//Pikaren
Pokelol.Capacite Pikaren_capacite1 = new("Elekdemacia = ", " Inflige des degats (80 puissance)",80, "Degat");
Pokelol.Capacite Pikaren_capacite2 = new("Pikarush = ", "Augmente la vitesse de 15%", 1.15f, "Speed+");
Pokelol.Capacite Pikaren_capacite3 = new("Gabri = ", "Augmente la defense de 30%", 1.3f, "Defense+");
//Ectoplari
Pokelol.Capacite Ectoplari_capacite1 = new("LaserOmbre = " , "Inflige des degats(110 puissance)", 110, "Degat");
Pokelol.Capacite Ectoplari_capacite2 = new("Exploplasma = " , "Inflige des degats(90 puissance)", 90, "Degat");
Pokelol.Capacite Ectoplari_capacite3 = new("Taclebas = ", "Baisse la vitesse de l'ennemi de 20% ", 0.8f, "Speed-");
//Swainquaza
Pokelol.Capacite Swainquaza_capacite1 = new("CorbeauMeteore = ", "Inflige des degats(150 puissance)", 150, "Degat");
Pokelol.Capacite Swainquaza_capacite2 = new("GriffeAscension = ", "Inflige des degats(110 puissance)", 110, "Degat");
Pokelol.Capacite Swainquaza_capacite3 = new("OeilViolent = ", "Inflige des degats(90 puissance)", 90, "Degat");
//Ahram
Pokelol.Capacite Ahram_capacite1 = new("FlammeCharme = ", " Baisse l'attaque de l'adversaire de 30% ", 0.7f, "Attaque-");
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

Joueur = Ectoplari;
Ennemi = Swainquaza;

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

    float pv_perdu = (((Attanquant.Attaque * Attanquant.Capacites[i].Stats_capacite)/(Defenseur.Defense * 50 + 2 )) * coup_critique);
    return pv_perdu;
}

void AppliquerEffetCapacite(Pokelol Attaquant, Pokelol Defenseur, int res)
{
    switch (Attaquant.Capacites[res].Type_capacite)
    {
        case "Degat":
            Defenseur.Vie -= calcul_degat(Attaquant, Defenseur, res);
            Console.WriteLine("Le defenseur perd "+ calcul_degat(Attaquant, Defenseur, res) + "point de vie");
            Console.WriteLine();
            break;
        case "Attaque-":
            Defenseur.Attaque -= Attaquant.Capacites[res].Stats_capacite;
            Console.WriteLine("Le defense perd " + Attaquant.Capacites[res].Stats_capacite + "de degat");
            Console.WriteLine();
            break;
        case "Speed+":
            Attaquant.Speed *= Attaquant.Capacites[res].Stats_capacite;
            Console.WriteLine("L'attaquant multiplie sa vitesse par " + Attaquant.Capacites[res].Stats_capacite);
            Console.WriteLine();
            break;
        case "Speed-":
            Defenseur.Speed *= Attaquant.Capacites[res].Stats_capacite;
            Console.WriteLine("Le defenseur perd de la vitesse par " + Attaquant.Capacites[res].Stats_capacite);
            Console.WriteLine();
            break;
        case "Defense+":
            Attaquant.Defense *= Attaquant.Capacites[res].Stats_capacite;
            Console.WriteLine("L'attaquant multiplie sa defense par " + Attaquant.Capacites[res].Stats_capacite);
            Console.WriteLine();
            break;
        default:
            Console.WriteLine("Type de capacité inconnu");
            break;
    }
}

void afficher_stats(Pokelol Joueur, Pokelol Ennemi)
{
    Console.WriteLine(Joueur.Name+ "Vie: " + Joueur.Vie+ " Attaque: " + Joueur.Attaque+ " Defense: " + Joueur.Defense+ " Speed: " + Joueur.Speed + "\n");

    Console.WriteLine(Ennemi.Name+ "Vie: " + Ennemi.Vie + " Attaque: " + Ennemi.Attaque + " Defense: " + Ennemi.Defense + " Speed: " + Ennemi.Speed);
}

while (Joueur.Vie >=0 & Ennemi.Vie >=0)
{

    if (Joueur.Speed > Ennemi.Speed)
    {
        Console.WriteLine();
        Console.WriteLine("C'est à vous, que souhaitez-vous faire ?");
        Console.WriteLine("1- Attaques\n2- Objets\n3- Fuite\n");
        string choix = Console.ReadLine();
        switch (choix)
        {
            case ("1"):
                Console.WriteLine("Choisir parmi les compétences\n");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(Joueur.Capacites[i].Name_capacite +  Joueur.Capacites[i].Description);
                }
                
                string value = Console.ReadLine();
                int res = Convert.ToInt32(value) - 1;
                Console.Clear();
                Console.WriteLine("Tour du Joueur");
                AppliquerEffetCapacite(Joueur, Ennemi, res);


                Console.WriteLine("Tour de l'Ennemi");
                Random random = new Random();
                int randomability = random.Next(0,2);
                AppliquerEffetCapacite(Ennemi, Joueur, res);
                Console.WriteLine();

                afficher_stats(Joueur, Ennemi);

                break;
            case "2":
                break;
            case "3":
                break;
        }
    }
    
}

public class Pokelol
{
    public string Name { get; set; }
    public float Vie { get; set; }
    public float Attaque { get; set; }
    public float Defense { get; set; }
    public float Speed { get; set; }
    public List<Capacite> Capacites { get; set; }

    public Pokelol(string name, float vie, float attaque, float defense, float speed)
    {
        Name = name;
        Vie = vie;
        Attaque = attaque;
        Defense = defense;
        Speed = speed;
        Capacites = new List<Capacite> { };
    }

    public void AddCapacite(Capacite capacite)
    {
        Capacites.Add(capacite);
    }

    

    public class Capacite
    {
        public string Name_capacite { get; set; }
        public string Description { get; set; }

        public float Stats_capacite { get; set; }
        public string Type_capacite { get; set; }

        public Capacite(string name_capacite, string description,float stats_capacite, string type_capacite)
        {
            Name_capacite = name_capacite;
            Description = description;
            Stats_capacite = stats_capacite;
            Type_capacite = type_capacite;
        }
    }
}




