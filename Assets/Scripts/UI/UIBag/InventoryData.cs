using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public List<InventorySlot> slots = new();

    public void AddItem(InventoryItemData newItem)
    {
        var slot = slots.Find(s => s.itemData.id == newItem.id);
        if (slot != null)
        {
            slot.AddOne();
        }
        else
        {
            slots.Add(new InventorySlot(newItem));
        }
    }
}
