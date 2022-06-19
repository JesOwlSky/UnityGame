using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;  
    Item item; 
    public Text amount; 

    public void AddItem(Item newItem, int num) 
    {
        item = newItem; 

        icon.sprite = item.icon;
        icon.enabled = true;
        amount.text = num.ToString(); 
    }

    public void ClearSlot() 
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        amount.text = "";
    }

    public Item GetItemInSlot() 
    {
        return item;
    }
}
