using RevenantRadiance.Player;
using UnityEngine;

namespace RevenantRadiance.Player
{
	public class PlayerController : MonoBehaviour
	{
		private PlayerData playerData;
		private PlayerView playerView;


		public PlayerGroundCheck groundCheck;
		public bool isKeyPresent;
		private bool isJumping;
		private Rigidbody2D playerRigidBody;

		public PlayerController(PlayerData _playerData, PlayerView _playerView)
		{
			playerData = _playerData;
			playerView = _playerView;
			playerView.SetController(this);
		}
		
		// private void Awake()
		// {
		// 	isKeyPresent = false;
		// 	this.gameObject.SetActive(true);
		// }

		private void Start()
		{
			playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
		}

		

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.CompareTag("Key"))
			{
				Destroy(collision.gameObject);
				isKeyPresent = true;
			}
		}

		// private void HorizontalCharacterMovement(float _horizontalInput)
		// {
		// 	float tempSpeed;
		// 	if (horizontalInput == 0)
		// 	{
		// 		tempSpeed = 0;
		// 	}
		// 	else
		// 	{
		// 		tempSpeed = playerData.speed;
		// 	}
		//
		// 	playerRigidBody.velocity = new Vector2(tempSpeed * _horizontalInput, playerRigidBody.velocity.y);
		// }

		private void PlayerJump()
		{
			if (isJumping)
			{
				playerRigidBody.velocity = Vector2.zero;
				playerRigidBody.AddForce(new Vector2(0f, playerData.jumpHeightMax), ForceMode2D.Force);
			}
		}
	}
}
