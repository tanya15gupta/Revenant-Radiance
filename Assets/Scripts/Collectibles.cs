using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
	public ScoreController gemControl;
	public ScoreController coinControl;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Coin")
		{
			Destroy(collision.gameObject);
			coinControl.IncreaseScore(1);
		}

		if(collision.tag == "Gem")
		{
			Destroy(collision.gameObject);
			gemControl.GemCount();
		}
	}
}
