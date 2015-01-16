using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DisplayHealth : MonoBehaviour 
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
		
		count = 5;
	}
	
	void Update()
	{
		text.text = "Health: " + count;
	}
	
	
	
}