using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemUIPrefab;
    public Transform contentParent;

    private Dictionary<string, GameObject> itemUIs = new();

    public void RefreshUI(List<InventorySlot> slots)
    {
        foreach (var slot in slots)
        {
            if (itemUIs.ContainsKey(slot.itemData.id))
            {
                var text = itemUIs[slot.itemData.id].GetComponentInChildren<Text>();
                text.text = $"{slot.itemData.title} x{slot.count}";
            }
            else
            {
                var go = Instantiate(itemUIPrefab, contentParent);
                var text = go.GetComponentInChildren<Text>();
                var img = go.GetComponentInChildren<Image>();

                text.text = $"{slot.itemData.title} x{slot.count}";
                img.sprite = slot.itemData.icon;

                itemUIs.Add(slot.itemData.id, go);
            }
        }
    }
}
