using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; 
    public Animator animator; 
    private float horizontalMove = 0f; 
    bool jump = false; 
    bool sprint = false;
 
    
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal"); 
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 
        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            sprint = true; 
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            sprint = false;  
        }
    }

    private void FixedUpdate() 
    {
        controller.Move(horizontalMove, sprint, jump);
        jump = false; 
    }
}
