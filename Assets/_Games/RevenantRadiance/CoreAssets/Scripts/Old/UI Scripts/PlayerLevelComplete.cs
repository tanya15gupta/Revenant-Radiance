using System.Collections;
using RevenantRadiance.Player;
using UnityEngine;

public class PlayerLevelComplete : MonoBehaviour
{
    Animator doorAnimation;
	public GameObject gameWinPanel;
	public float waitTime = 5;
	[SerializeField]
	private PlayerController playerController;
	private void Start()
	{
		gameWinPanel.SetActive(false);
		doorAnimation = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<PlayerController>())
		{
			if(playerController.isKeyPresent)
			{
				doorAnimation.SetBool("Door", true);
				StartCoroutine(SetPanelActive());
			}
		}
	}

	IEnumerator SetPanelActive()
	{
		yield return new WaitForSeconds(waitTime);
		gameWinPanel.SetActive(true);
	}
}
