using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance; 

    private void Awake() 
    {
        if (instance != null) 
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this; 
    }

    public delegate void OnItemChanged();  
    public OnItemChanged onItemChangedCallback; 
    
    public Dictionary<Item, int> items = new Dictionary<Item, int>(); 

    public void Add(Item item) 
    {
        if (items.ContainsKey(item)) 
            items[item]++;
        else
            items.Add(item, 1); 
        if(onItemChangedCallback != null) 
            onItemChangedCallback.Invoke();
    }

    public void Remove(Item item) 
    {
        if (items[item] > 1)
            items[item]--;
        else
            items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
