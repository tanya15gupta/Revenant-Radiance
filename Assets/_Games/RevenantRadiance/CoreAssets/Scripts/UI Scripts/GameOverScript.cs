using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
	[SerializeField]
	private GameObject gameOverPanel;
	private void Awake()
	{
		gameOverPanel.gameObject.SetActive(false);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
		{
			playerController.gameObject.SetActive(false);
			gameOverPanel.gameObject.SetActive(true);
		}
	}
}
