using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator; 
    public InventoryUI inventoryUI; 

    public float energySpeed = 0; 
    public float jumpCost = 10; 
    public float maxHealth = 100; 
    public float currentHealth; 

    public LayerMask enemyLayers; 

    public delegate void OnHealthChanged(); 
    public OnHealthChanged onHealthChangedCallback; 

    private void Start()
    {
        currentHealth = maxHealth; 
        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            energySpeed = 2f;  
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            energySpeed = 0f;
        }
        TakeDamage(energySpeed * Mathf.Abs(Input.GetAxis("Horizontal")) * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Item item = inventoryUI.GetItemInSlot(0);
            if (item != null)
            {
                Inventory.instance.Remove(item);
                TakeDamage(-item.heal);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Item item = inventoryUI.GetItemInSlot(1);
            if (item != null)
            {
                Inventory.instance.Remove(item);
                TakeDamage(-item.heal);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Item item = inventoryUI.GetItemInSlot(2);
            if (item != null)
            {
                Inventory.instance.Remove(item);
                TakeDamage(-item.heal);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Item item = inventoryUI.GetItemInSlot(3);
            if (item != null)
            {
                Inventory.instance.Remove(item);
                TakeDamage(-item.heal);
            }
        }
    }

    public void TakeDamage(float damage)  
    {
        if (currentHealth > damage)
        {
            currentHealth -= damage;
            if (onHealthChangedCallback != null) 
                onHealthChangedCallback.Invoke();
        }
    }
}
