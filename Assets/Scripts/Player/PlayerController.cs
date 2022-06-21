using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
	public float jumpForce;

	float horizontalInput;

	public PlayerGroundCheck groundCheck;

	bool isJumping;
	Rigidbody2D playerRigidBody;

	private void Start()
	{
		playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded == true)
			isJumping = true;
		else
			isJumping = false;

	}

	private void FixedUpdate()
	{
		HorizontalCharacterMovement(horizontalInput);
		PlayerJump();
	}

	private void HorizontalCharacterMovement(float _horizontalInput)
	{
		playerRigidBody.velocity = new Vector2(speed * _horizontalInput, playerRigidBody.velocity.y);
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
