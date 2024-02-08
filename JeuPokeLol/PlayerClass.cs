using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CA1050

public class Player
{
    public string Name { get; set; }

    public int Position_x { get; set; }
    public int Position_y { get; set; }

    public bool Capture { get; set; }
    
    public Inventory Inventory { get; set; }
    public Team Team { get; set; }


    public Player(string name)
    {
        Name = name;

        Position_x = 1;
        Position_y = 1;

        Capture = false;
        
        Inventory = new Inventory();
        Team = new Team();
    }

}