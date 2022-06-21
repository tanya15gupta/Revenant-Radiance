using UnityEngine;

public class LightMovement : MonoBehaviour
{
    CircleCollider2D lightCollider;

	private bool isTouchingLight;

	[SerializeField] float leftOffset = 0;
	[SerializeField] float rightOffset = 0;
	[SerializeField] float moveSpeed = 1;

	[SerializeField] bool isRight = false;
	[SerializeField] bool isLeft = false;

	Vector3 startPosition = Vector3.zero;

	private void Awake()
	{
		startPosition = transform.position;
	}


	private void FixedUpdate()
	{
		if (!isRight)
		{
			if (transform.position.x < startPosition.x + rightOffset)
			{
				MoveLight(rightOffset);
			}
			else if (transform.position.x >= startPosition.x + rightOffset)
			{
				isRight = true;
				isLeft = false;
			}
		}
		else if (!isLeft)
		{
			if (transform.position.x > startPosition.x + leftOffset)
			{
				MoveLight(leftOffset);
			}
			else if (transform.position.x <= startPosition.x + leftOffset)
			{
				isRight = false;
				isLeft = true;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out PlayerController player))
		{
			IsPlayerTouchingLight(true);
			Debug.Log( "Player Dead");
		}
	}

	public bool IsPlayerTouchingLight(bool _isTouchingLight)
	{
		isTouchingLight = _isTouchingLight;
		return isTouchingLight;
	}

	void MoveLight(float offset)
	{
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x + offset, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
	}
}
