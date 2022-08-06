using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public CollectibleType type;
        public int count;
        public int max;

        public Slot()
        {
            type = CollectibleType.NONE;
            count = 0;
            max = 99;
        }

        public bool CanAddItem()
        {
            return count < max;
        }

        public void AddItem(CollectibleType type)
        {
            this.type = type;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(CollectibleType type)
    {
        foreach (Slot slot in slots)
        {
            if (slot.type == type && slot.CanAddItem())
            {
                slot.AddItem(type);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.type == CollectibleType.NONE)
            {
                slot.AddItem(type);
                return;
            }
        }
    }
}
