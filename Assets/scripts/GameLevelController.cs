using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLevelController : MonoBehaviour {

	public Player Player;
	public int currentLevel;
	public Image LevelFinished;

	private GameLevel[] gameLevels;


	public void OnEnable()
	{
		Player.gameObject.SetActive (true);
		gameLevels = GetComponentsInChildren<GameLevel>(true);

		for( var index = 0; index < gameLevels.Length; ++index )
		{
			var gameLevel = gameLevels[index];
			gameLevel.OnLevelFinished += HandleLevelFinished;
			//gameLevel.OnPlayerDied += HandlePlayerDied;
		}

		startLevel();
	}

	private void startLevel()
	{
		gameLevels[currentLevel].gameObject.SetActive (true);
		Player.Interactable = true;
	}

	private void HandlePlayerDied()
	{
		StartCoroutine (PerformLostLevel ());
	}

	private IEnumerator PerformLostLevel ()
	{
		yield return null;
	}

	private void HandleLevelFinished()
	{
		StartCoroutine (PerformWonLevel ());
	}

	private IEnumerator PerformWonLevel ()
	{
		Player.Interactable = false;
		LevelFinished.gameObject.SetActive (true);
		Debug.Log ("Level Finished");

		yield return new WaitForSeconds (1);
		LevelFinished.gameObject.SetActive (false);
		gameLevels[currentLevel].gameObject.SetActive (false);

		currentLevel++;

		if (currentLevel >= gameLevels.Length)
			currentLevel = 0;

		startLevel ();
	}
}