using UnityEngine;

public class InventoryUI : MonoBehaviour
{   
    public Transform itemsParent;  

    Inventory inventory; 

    InventorySlot[] slots; 
    void Start()
    {
        inventory = Inventory.instance; 
        inventory.onItemChangedCallback += UpdateUI;
        
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 
    }

    void UpdateUI() 
    {
        int i = 0;
        foreach (var elem in inventory.items) 
        {
            slots[i].AddItem(elem.Key, elem.Value); 
            i++;
        }
        if (i < slots.Length) 
        for (; i < slots.Length; i++)
        {
            slots[i].ClearSlot(); 
        }
    }

    public Item GetItemInSlot(int num) 
    {
        return slots[num].GetItemInSlot(); 
    }
}
