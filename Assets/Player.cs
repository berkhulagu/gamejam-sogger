using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private float moveUpAmount;

	void Update () 
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.localPosition += new Vector3(-0.1f, 0, 0 );
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.localPosition += new Vector3(0.1f, 0, 0 );
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (IsApproximately(moveUpAmount,0)) 
			{
				moveUpAmount = 1.0f;
				StartCoroutine (moveUpInY ());
			}
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			if (IsApproximately(moveUpAmount,0))
			{
				moveUpAmount = -1.0f;
				StartCoroutine (moveDownInY ());
			}
		}
	}

	void OnTriggerEnter(Collider collider ) 
	{
		Debug.Log ("Collided with " + collider.name );
	}

	IEnumerator moveUpInY()
	{

		while (!IsApproximately(moveUpAmount,0)) 
		{
			transform.localPosition += new Vector3 (0, 0.1f, 0);
			moveUpAmount -= 0.1f;
			yield return null;
		}
	}

	IEnumerator moveDownInY()
	{
		while (!IsApproximately(moveUpAmount,0)) 
		{
			transform.localPosition += new Vector3 (0, -0.1f, 0);
			moveUpAmount += 0.1f;
			yield return null;
		}
	}

	bool IsApproximately(float a, float b)
	{
		return Mathf.Abs(a - b) < 0.01f;
	}
}
