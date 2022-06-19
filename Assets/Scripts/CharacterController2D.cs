using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float walkSpeed = 40f; 
	[SerializeField] private float jumpForce = 400f;     
	[Range(0, 1)] [SerializeField] private float slowMultiplier = .36f; 
	[Range(1, 3)][SerializeField] private float runMultiplier = 2f; 
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; 
	[SerializeField] private LayerMask whatIsGround;				
	[SerializeField] private Transform groundCheck;		
	const float groundedRadius = .2f; 
	private bool isGrounded;         
	private bool isSlowedDown;         
	private Rigidbody2D rigidbody2D;  
	private PlayerCombat playerCombat; 
	private bool facingRight = true;  
	private Vector3 velocity = Vector3.zero; 

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>(); 
		playerCombat = GetComponent<PlayerCombat>();
	}

	private void FixedUpdate() 
	{
		bool wasGrounded = isGrounded;  
		isGrounded = false; 

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround); 
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)  
			{
				isGrounded = true;
			}
		}
	}


	public void Move(float move, bool sprint, bool jump) 
	{
		move *= walkSpeed * Time.fixedDeltaTime; 

		if (isGrounded) 
		{

			if (sprint && playerCombat.currentHealth > Mathf.Abs(move)) 
			{
				move *= runMultiplier; 
			}

			if (isSlowedDown) 
			{
				move *= slowMultiplier;
			}

			Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y); 
			rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing); 

			if (move > 0 && !facingRight) 
			{
				Flip();
			}
			else if (move < 0 && facingRight)
			{
				Flip();
			}
		}
		if (isGrounded && jump && playerCombat.currentHealth > playerCombat.jumpCost) 
		{
			isGrounded = false; 
			playerCombat.TakeDamage(playerCombat.jumpCost); 
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}


	private void Flip() 
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale; 
		theScale.x *= -1; 
		transform.localScale = theScale; 
	}
}
