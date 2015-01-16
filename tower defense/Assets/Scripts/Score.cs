using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Score : MonoBehaviour 
{
	

	public static int count;
	Text text;
	
	void start()
	{
		

		//SetCountText ();
	}
	
	void Awake ()
	{
		text = GetComponent <Text> ();

		count = 0;
		count = count + 15;
	}

	void Update()
	{

		text.text = "Parts: " + count;
	}
	
	
	


	/*void SetCountText()
	{
		parts.text = "Parts:" + count.ToString ();
	}*/
}
