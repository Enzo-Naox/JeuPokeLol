using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CA1050

public class Pokelol
{
    public string Name { get; set; }
    public bool IsAlive { get; set; }
    public int Level { get; set; }
    public float Experience_Acquis { get; set; }
    public float Experience_Necessaire { get; set; }
    public Statistiques Stats { get; set; }
    public List<Capacite> Capacites { get; set; }

    public Pokelol(string name)
    {
        Name = name;

        IsAlive = true;

        Level = 0;
        Experience_Acquis = 0;
        Experience_Necessaire = 100;
        Stats = new Statistiques();

        Capacites = new List<Capacite> { };
    }

    public void DefinirStatistiques(float vie, float attaque, float defense, float vitesse)
    {
        Stats.Vie = vie;
        Stats.Attaque = attaque;
        Stats.Defense = defense;
        Stats.Vitesse = vitesse;
    }

    public void MonterDeNiveau()
    {
        if (Experience_Acquis >= Experience_Necessaire)
        {
            Level++;
            Experience_Acquis -= Experience_Necessaire;
            Experience_Necessaire *= 1.05f;
            Stats.Attaque += 5;
            Stats.Defense += 3;
            Stats.Vie += 15;
            Console.WriteLine("Votre pokemon a passer un niveau");
        }
        else
        {
            Console.WriteLine("vous navez pas assez d'xp pour levelup");
        }
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

        public Capacite(string name_capacite, string description, float stats_capacite, string type_capacite)
        {
            Name_capacite = name_capacite;
            Description = description;
            Stats_capacite = stats_capacite;
            Type_capacite = type_capacite;
        }
    }
}