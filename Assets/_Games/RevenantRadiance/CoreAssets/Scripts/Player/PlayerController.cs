using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
	public float jumpForce;

	float horizontalInput;

	public PlayerGroundCheck groundCheck;
	public bool isKeyPresent;
	bool isJumping;
	Rigidbody2D playerRigidBody;

	private void Awake()
	{
		isKeyPresent = false;
		this.gameObject.SetActive(true);
	}

	private void Start()
	{
		playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");

		if (Input.GetKey(KeyCode.Space) && groundCheck.isGrounded == true)
			isJumping = true;
		else
			isJumping = false;

	}

	private void FixedUpdate()
	{
		HorizontalCharacterMovement(horizontalInput);
		PlayerJump();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Key"))
		{
			Destroy(collision.gameObject);
			isKeyPresent = true;
		}
	}

	private void HorizontalCharacterMovement(float _horizontalInput)
	{
		float tempSpeed;
		if(horizontalInput == 0)
		{ 
			tempSpeed = 0;
		}
		else
		{
			tempSpeed = speed;
		}
		playerRigidBody.velocity = new Vector2(tempSpeed * _horizontalInput, playerRigidBody.velocity.y);
	}

	private void PlayerJump()
	{
		if(isJumping)
		{
			playerRigidBody.velocity = Vector2.zero;
			playerRigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
		}
	}
}
