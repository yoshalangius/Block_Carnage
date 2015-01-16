using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class start : MonoBehaviour {
	
	Text startTekst;
	public bool pressStart = false;
	
	// Update is called once per frame
	void Update () 
	{

			
			startTekst = GetComponent <Text> ();
			startTekst.text = "PRESS P TO START";


			if (Input.GetKeyDown (KeyCode.P))
			{
				Application.LoadLevel ("test");
			}

		
	}
}
