using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class help : MonoBehaviour {
	
	Text howToPlay;
	public bool Help = true;
	
	// Update is called once per frame
	void Update () 
	{

			
		howToPlay = GetComponent <Text> ();


		
		if (Help == true)
		{
			if (Input.GetKeyDown (KeyCode.H))
			{


			}
		}
		
	}
}
