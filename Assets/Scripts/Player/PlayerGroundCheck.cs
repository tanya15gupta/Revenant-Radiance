using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public bool isGrounded;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(!collision.GetComponent<LightMovement>())
			isGrounded = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (!collision.GetComponent<LightMovement>())
			isGrounded = false;
	}
}
