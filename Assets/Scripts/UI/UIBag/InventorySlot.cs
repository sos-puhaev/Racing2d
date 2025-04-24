[System.Serializable]
public class InventorySlot
{
    public InventoryItemData itemData;
    public int count;

    public InventorySlot(InventoryItemData item)
    {
        itemData = item;
        count = 1;
    }

    public void AddOne()
    {
        count++;
    }
}
