using RevenantRadiance.Player;
using UnityEngine;

public class LightMovement : PropsMovement
{
	public GameObject playerDeadPanel;

	private void Awake()
	{
		playerDeadPanel.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out PlayerController player))
		{
			playerDeadPanel.SetActive(true);
			player.gameObject.SetActive(false);
		}
	}
}
