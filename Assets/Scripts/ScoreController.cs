using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
	private TextMeshProUGUI scoreText;
	private TextMeshProUGUI gemText;
	private int score = 0;
	int gem = 0;

	private void Awake()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
		gemText = GetComponent<TextMeshProUGUI>();
	}

	private void Start()
	{
		RefreshCoinUI();
		RefreshGemUI();
	}
	public void IncreaseScore(int increment)
	{
		score += increment;
		RefreshCoinUI();
	}

	public void GemCount()
	{
		gem++;
		RefreshGemUI();
	}

	private void RefreshCoinUI()
	{
		scoreText.text = score + " :";
	}

	private void RefreshGemUI()
	{
		gemText.text = ": " + gem;
	}
}