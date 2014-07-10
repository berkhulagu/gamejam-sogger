using UnityEngine;
using System.Collections;

public class GameLevel : MonoBehaviour 
{
	public Camera Camera;
	public Player Player;
	public bool FollowPlayer;

	void Update () 
	{
		if (FollowPlayer) 
		{
			Camera.transform.localPosition = new Vector3 (0, Player.transform.localPosition.y + 3f, -1);
		}
	}
}
