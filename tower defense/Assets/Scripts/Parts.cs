using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Parts : MonoBehaviour 
{
	//is actually the score script. i mixed them up excedently.
	
	public static int score;
	Text Score;
	
	void start()
	{
		
		
		//SetCountText ();
	}
	
	void Awake ()
	{
		Score = GetComponent <Text> ();
		
		score = 0;

	}
	
	void Update()
	{
		Score.text = "Score: " + score;
	}
	
	
	
	
	
	/*void SetCountText()
	{
		parts.text = "Parts:" + count.ToString ();
	}*/
}
