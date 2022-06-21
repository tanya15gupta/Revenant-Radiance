using UnityEngine.SceneManagement;
using UnityEngine;

public class UIScripts : MonoBehaviour
{
	
	public void ApplicationQuit()
	{
		Application.Quit();
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}
	
	public void MainMenu()
	{
		SceneManager.LoadScene(1);

	}
}
