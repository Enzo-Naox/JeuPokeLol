using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Statistiques
{
    public float Vie { get; set; }
    public float Attaque { get; set; }
    public float Defense { get; set; }
    public float Vitesse { get; set; }
}


public class Pokelol
{
    public string Name { get; set; }
    public int Level { get; set; }
    public float Experience_Acquis { get; set; }
    public float Experience_Necessaire { get; set; }
    public Statistiques Stats { get; set; }
    public List<Capacite> Capacites { get; set; }

    public Pokelol(string name)
    {
        Name = name;

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
            Experience_Necessaire *= 1.05f;
            Stats.Attaque += 5;
            Stats.Defense += 3;
            Stats.Vie += 15;
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



public class Player
{
    public string Name { get; set; }

    public int Level { get; set; }
    public float Experience_Acquis { get; set; }
    public float Experience_Necessaire { get; set; }

    public Inventory Inventory { get; set; }
    public Team Team { get; set; }


    public Player(string name)
    {
        Name = name;

        Level = 1;
        Experience_Acquis = 0;
        Experience_Necessaire = 100;

        Inventory = new Inventory();
        Team = new Team();
    }


}

public class Inventory
{
    public List<Item> Items { get; set; } = new List<Item>();

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }

    public void ShowInventory()
    {
        Console.WriteLine("Inventory Contents:");
        foreach (var item in Items)
        {
            Console.WriteLine($"Name: {item.Name}");
        }
    }

}
    
public class Item
{
    public string Name { get; set; }
}

public class Team
{
    public List<Pokelol> Members { get; set; } = new List<Pokelol>();

    public void AddMember(Pokelol Name)
    {
        Members.Add(Name);
    }

    public void ShowTeam()
    {
        Console.WriteLine("Team Members:");
        foreach (var member in Members)
        {
            Console.WriteLine($"Name: {member.Name}, HP: {member.Stats.Vie}, Attack: {member.Stats.Attaque}, Defense: {member.Stats.Defense}, Speed: {member.Stats.Vitesse}");
        }
    }
}