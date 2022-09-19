using UnityEngine;

public class LightMovement : MonoBehaviour
{
	private bool isTouchingLight;

	[SerializeField] float leftOffset = 0;
	[SerializeField] float rightOffset = 0;
	[SerializeField] float moveSpeed = 1;

	[SerializeField] bool isRight = false;
	[SerializeField] bool isLeft = false;


	public GameObject playerDeadPanel;

	Vector3 startPosition = Vector3.zero;

	private void Awake()
	{
		startPosition = transform.position;
		playerDeadPanel.SetActive(false);
	}

	private void FixedUpdate()
	{
		MoveLight();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out PlayerController player))
		{
			IsPlayerTouchingLight(true);
			playerDeadPanel.SetActive(true);
			collision.gameObject.SetActive(false);
		}
	}

	private void MoveLight()
	{
		if (!isRight)
		{
			if (transform.position.x < startPosition.x + rightOffset)
				MoveLight(rightOffset);
			else if (transform.position.x >= startPosition.x + rightOffset)
				SetDirection(true, false);
		}
		else if (!isLeft)
		{
			if (transform.position.x > startPosition.x + leftOffset)
				MoveLight(leftOffset);
			else if (transform.position.x <= startPosition.x + leftOffset)
				SetDirection(false, true);
		}
	}

	public void IsPlayerTouchingLight(bool _isTouchingLight) => isTouchingLight = _isTouchingLight;

	void MoveLight(float offset) => transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x + offset, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);

	void SetDirection(bool right, bool left)
	{
		isRight = right;
		isLeft = left;
	}
}
