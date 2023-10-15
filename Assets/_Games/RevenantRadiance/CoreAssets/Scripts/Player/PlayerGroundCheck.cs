using RevenantRadiance.Player;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public bool isGrounded;
	public GameObject player;
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(!collision.GetComponent<PlayerController>())
			isGrounded = true;

		if (collision.gameObject.CompareTag("Platform"))
			player.transform.parent = collision.gameObject.transform;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (!collision.GetComponent<PlayerController>())
			isGrounded = false;

		if (collision.gameObject.CompareTag("Platform"))
			player.transform.parent = null;
	}
}
