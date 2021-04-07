using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWall : MonoBehaviour
{
	public delegate void PointScoredEvent(char letter);
	public static event PointScoredEvent onPointScored;
	
	private void OnTriggerEnter2D(Collider2D coll)
	{
		//Debug.Log("vertWall detects: " + coll);

		if (coll.CompareTag("Ball"))
		{
			onPointScored(this.name[this.name.Length - 1]);
		}

	}
}
