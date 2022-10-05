using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public int slots = 8;

    private Slot[] inventory;

    public Inventory()
    {
        inventory = new Slot[slots];
        for (int i = 0; i < slots; i++)
        {
            inventory[i] = new Slot();
        }
    }

    public bool AddItem (Block item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (inventory[i].isEmpty())
            {
                inventory[i].Add(item);
            }
        }

        return false;
    }

    public Block GetItem(int slot)
    {
        Block item = null;

        if (!inventory[slot].isEmpty())
        {
            item = inventory[slot].item;
            inventory[slot].Remove();
        }

        return item;
    }

    private class Slot
    {
        public Block item;
        private int itemsPerSlot = 64;
        private int numberOfItems = 0;

        public void Add(Block item)
        {
            if (item == null)
            {

            }
            numberOfItems++;
        }

        public void Remove()
        {
            numberOfItems--;
        }

        public bool isEmpty()
        {
            return numberOfItems <= 0;
        }

        public bool isFull()
        {
            return numberOfItems <= itemsPerSlot;
        }
    }
}
