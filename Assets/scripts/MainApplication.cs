using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainApplication : MonoBehaviour {

	public bool SkipInitialScreens;

	public Image SplashScreen;
	public Image MainScreen;
	public GameLevelController GameLevelController;
	
	void OnEnable()
	{
		if(SkipInitialScreens)
		{
			ShowGameplay();
		}
		else
		{
			StartCoroutine ( ShowInitialScreens ());
		}
	}

	private IEnumerator ShowInitialScreens()
	{
		SplashScreen.gameObject.SetActive (true);
		 
		yield return new WaitForSeconds (2);
		SplashScreen.gameObject.SetActive (false);
		MainScreen.gameObject.SetActive (true);
	}

	public void ShowGameplay()
	{
		MainScreen.gameObject.SetActive (false);

		GameLevelController.gameObject.SetActive(true);
	}
}
