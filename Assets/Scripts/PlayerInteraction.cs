using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public gameProgress controller; 
    public gameProgLvl2 controller2;
    public Transform point; 
    public float range = 0.5f; 
    public LayerMask layers; 
    public InteractInfo info; 

   
    void Update()
    {
        Collider2D[] interactables = Physics2D.OverlapCircleAll(point.position, range, layers); 

        int i = interactables.Length; 
        while (i > 0)
        {
            i--;
            if (interactables[i].GetComponent<Interactable>()) 
            {
                info.Show(); 

                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    interactables[i].GetComponent<Interactable>().Interact(); 
                }
                return;
            }
        }
        info.Hide(); 
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (controller && collision.gameObject.tag == "BearTrigger")
        {
            controller.SpawnBear();
        }
        if (controller2 && collision.gameObject.tag == "JakuzaTrigger")
        {
            controller2.SpawnJakuza();
        }
        if (controller && collision.gameObject.tag == "WinTrigger")
        {
            controller.YouWin();
        }
        if (controller2 && collision.gameObject.tag == "WinTrigger")
        {
            controller2.YouWin();
        }
    }
}