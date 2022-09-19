using UnityEngine;

public class PlayerLevelComplete : MonoBehaviour
{
    Animator doorAnimation;
	public GameObject gameWinPanel; 

	private void Start()
	{
		gameWinPanel.SetActive(false);
		doorAnimation = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<PlayerController>())
		{
			doorAnimation.SetBool("Door", true);
			gameWinPanel.SetActive(true);
		}

	}
}
