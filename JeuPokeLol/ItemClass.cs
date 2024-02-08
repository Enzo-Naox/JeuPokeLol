using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CA1050

public class Item
{
    public string Name { get; set; }

    public Item(string name)
    {
        Name = name;

    }
}