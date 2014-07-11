using UnityEngine;
using System.Collections;
using System;

public class GameLevel : MonoBehaviour 
{
	public Camera Camera;
	public Player Player;
	public bool FollowPlayer;
	private Lane lastLane;

	public Action OnLevelFinished = delegate {}; 

	public GameObject Start;
	public GameObject End;

	private bool dispatchedLevelFinished;

	void OnEnable()
	{
		Player.transform.localPosition = Start.transform.localPosition;
		dispatchedLevelFinished = false;

		lastLane = GetComponentsInChildren<Lane> ()[GetComponentsInChildren<Lane> ().Length-1];
		Camera.transform.localPosition = new Vector3 (0, Player.transform.localPosition.y + 3f, -1);
	}

	void Update () 
	{
		if ( Player.transform.localPosition.y + 2 < lastLane.transform.localPosition.y && Player.transform.localPosition.y > 0f) 
		{
			Camera.transform.localPosition = new Vector3 (0, Player.transform.localPosition.y, -1);
		}


		if (!dispatchedLevelFinished && Player.transform.localPosition.y > End.transform.localPosition.y) 
		{
			OnLevelFinished();
			dispatchedLevelFinished = true;
		}
	}
}
