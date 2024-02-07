using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public string Name { get; set; }
    public int position_x { get; set; }
    public int position_y { get; set; }
    public int Level { get; set; }
    public float Experience_Acquis { get; set; }
    public float Experience_Necessaire { get; set; }

    public Inventory Inventory { get; set; }
    public Team Team { get; set; }


    public Player(string name)
    {
        Name = name;

        position_x = 1;
        position_y = 1;
        Level = 1;
        Experience_Acquis = 0;
        Experience_Necessaire = 100;

        Inventory = new Inventory();
        Team = new Team();
    }


}