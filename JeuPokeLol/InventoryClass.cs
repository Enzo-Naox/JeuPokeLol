using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CA1050

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