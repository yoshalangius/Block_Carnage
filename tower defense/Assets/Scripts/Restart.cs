using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Restart : MonoBehaviour {

	Text restartTekst;
	public bool restart = false;
	
	// Update is called once per frame
	void Update () 
	{
		if(health.dead == true)
		{
			restart = true;
			restartTekst = GetComponent <Text> ();
			restartTekst.text = "PRESS R TO RESTART";
		}

		if (restart == true)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

	}
}
