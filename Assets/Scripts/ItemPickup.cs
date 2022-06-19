using UnityEngine;

public class ItemPickup : Interactable 
{
    public Item item;
    public override void Interact() 
    {
        PickUp();
    }

    void PickUp()
    {
        Inventory.instance.Add(item); 
        Destroy(gameObject); 
    }
}
