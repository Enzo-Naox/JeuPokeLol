using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CA1050

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
            if (member.IsAlive)
            {
                Console.WriteLine($"Name: {member.Name}, HP: {member.Stats.Vie}, Attack: {member.Stats.Attaque}, Defense: {member.Stats.Defense}, Speed: {member.Stats.Vitesse}");
            }
        }
    }

    public void TeamIsAlive()
    {
        Console.WriteLine("Membres de l'équipe en vie :");

        foreach (var member in Members)
        {
            if (member.Stats.Vie > 0)
            {
                Console.WriteLine($"Name: {member.Name}, HP: {member.Stats.Vie}, Attack: {member.Stats.Attaque}, Defense: {member.Stats.Defense}, Speed: {member.Stats.Vitesse}");
            }
        }
    }
}   