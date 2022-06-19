using UnityEngine;
public class Enemy : Interactable {
    public Animator animator; 
    private Transform _target; 
    public int maxHealh = 100; 
    private int currentHealth; 
    public float speed = 3f;  
    public float catchDistance = 2f; 
    private bool isTalks = false; 
    public bool isHunt = false; 
    public gameProgress controller; 
    public gameProgLvl2 controller2; 

    void Start()
    {
        currentHealth = maxHealh; 
    }


    void FixedUpdate()
    {
        Move(); 
    }

    public void Move()
    {
        if (Mathf.Abs(transform.position.x - _target.transform.position.x) > catchDistance) 
        {
            animator.SetBool("isMove", true); 
            Vector3 enemyMove = Vector3.Scale(_target.transform.position - transform.position, Vector3.right).normalized; 
            transform.position += enemyMove * Time.deltaTime * speed; 
            transform.localScale = new Vector3(enemyMove.x * -1, 1, 1); 
        }
        else
        {
            animator.SetBool("isMove", false); 
            CatchPlayer(); 
        }
    } 

    public override void Interact() 
    {
        base.Interact();
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        
    }

    public void SetTarget(Transform target) 
    {
        _target = target;
    }

    public void CatchPlayer() 
    {
        if (controller) 
        {
            if (isTalks && isHunt) 
            {
                controller.GameOver(gameObject.name); 
            }
            else if (!isTalks)  
            {
                controller.Talk(gameObject.name); 
                isTalks = true; 
            }
        }
        if (controller2) 
        {
            if (isTalks && isHunt)
            {
                controller2.GameOver(gameObject.name);
            }
            else if (!isTalks)
            {
                controller2.Talk(gameObject.name);
                isTalks = true;
            }
        }
    }
}
