using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	Text gameOver;

	void Update () 
	{
		if(health.dead == true)
		{
			gameOver = GetComponent <Text> ();
			gameOver.text = "GAME OVER";
		}
	}
}
