using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;


class Programme
{



    static void Main()
    {
        //CREATION D'UN NOUVEAU JOUEUR
        Player player = new("Player");
        Player ennemy = new("Ennemy");
        Player pokelol = new("Pokelol");


        //DEFINITION DES POKELOL ET DE LEURS STATISTIQUES
        Pokelol Test = new("Test");
        Test.DefinirStatistiques(100000, 100000, 100000, 100000);
        Pokelol Pikaren = new("Pikaren");
        Pikaren.DefinirStatistiques(233, 183, 147, 151);
        Pokelol Ectoplari = new("Ectoplari");
        Ectoplari.DefinirStatistiques(213, 162, 142, 182);
        Pokelol Swainquaza = new("Swainquaza");
        Swainquaza.DefinirStatistiques(212, 202, 142, 147);
        Pokelol Ahram = new("Ahram");
        Ahram.DefinirStatistiques(207, 137, 152, 187);


        Pokelol.Capacite Test_capacite1 = new("Test1 = ", "Inflige des degats(150 puissance)", 200, "Degat");
        Pokelol.Capacite Test_capacite2 = new("Test2 = ", "Inflige des degats(110 puissance)", 200, "Degat");
        Pokelol.Capacite Test_capacite3 = new("Tets3 = ", "Inflige des degats(90 puissance)", 200, "Degat");

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

        Test.AddCapacite(Test_capacite1);
        Test.AddCapacite(Test_capacite2);
        Test.AddCapacite(Test_capacite3);

        Ectoplari.AddCapacite(Ectoplari_capacite1);
        Ectoplari.AddCapacite(Ectoplari_capacite2);
        Ectoplari.AddCapacite(Ectoplari_capacite3);

        Swainquaza.AddCapacite(Swainquaza_capacite1);
        Swainquaza.AddCapacite(Swainquaza_capacite2);
        Swainquaza.AddCapacite(Swainquaza_capacite3);

        Ahram.AddCapacite(Ahram_capacite1);
        Ahram.AddCapacite(Ahram_capacite2);
        Ahram.AddCapacite(Ahram_capacite3);

        player.Team.AddMember(Test);
        player.Team.AddMember(Pikaren);
        

        ennemy.Team.AddMember(Pikaren);
        ennemy.Team.AddMember(Swainquaza);
        ennemy.Team.AddMember(Ectoplari);
        ennemy.Team.AddMember(Ahram);

        
        pokelol.Team.AddMember(Swainquaza);
        pokelol.Team.AddMember(Ectoplari);
        pokelol.Team.AddMember(Ahram);

        Item item1 = new("Healing Potion");
        Item item2 = new("Pokeball");

        player.Inventory.AddItem(item1);
        player.Inventory.AddItem(item2);

        ConsoleKeyInfo keyInfo;
        
        MapManagement.GenerateMap(15, 15);
        do
        {
            
            Console.Clear();
            MapManagement.DrawMap(player);
            keyInfo = Console.ReadKey();
            MapManagement.MovePlayer(player, ennemy, pokelol, keyInfo.Key);

        } while (keyInfo.Key != ConsoleKey.Escape);

        MenuManager.Menu(player);
    }
}




