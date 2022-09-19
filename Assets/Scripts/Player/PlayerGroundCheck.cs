using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public bool isGrounded;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(!collision.GetComponent<PlayerController>())
			isGrounded = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (!collision.GetComponent<PlayerController>())
			isGrounded = false;
	}
}
