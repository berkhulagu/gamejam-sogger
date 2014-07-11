using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lane : MonoBehaviour 
{
	public float cycleInSeconds;
	public bool leftToRight;

	private Vehicle[] Vehicles;
	private float cycleWidth;
	private bool isRendererInitialized;
	private int xCoefficient;
	private float maximumWidth;

	public void OnEnable()
	{
		cycleWidth = 11;
		isRendererInitialized = false;

		xCoefficient = leftToRight ? 1 : -1;

		Vehicles = GetComponentsInChildren<Vehicle> ();

		for (var index = 0; index < Vehicles.Length; index++) 
		{
			var vehicle = Vehicles[index];

			maximumWidth = vehicle.transform.localScale.x > maximumWidth ? vehicle.transform.localScale.x : maximumWidth;
		}
	}

	public void FixedUpdate()
	{
		var deltaX = xCoefficient*(Time.deltaTime/cycleInSeconds)*cycleWidth;	

		for( var index = 0; index < Vehicles.Length; index++)
		{
			bool move = false;
			var vehicle = Vehicles[index];
			vehicle.transform.localPosition += new Vector3( deltaX, 0 , 0);

			if( leftToRight )
			{
				var lastVisible = vehicle.transform.localPosition.x - vehicle.transform.localScale.x/2f;

				if(lastVisible > 5.5f )
				{
					move = true;
				}
			}

			else
			{
				var lastVisible = vehicle.transform.localPosition.x + vehicle.transform.localScale.x/2f;

				if(lastVisible < -5.5f )
				{
					move = true;
				}
			}

			if( move )
			{
				vehicle.transform.localPosition += new Vector3( -1*xCoefficient*( cycleWidth + maximumWidth ), 0 , 0);
			}
		}
	}
}
