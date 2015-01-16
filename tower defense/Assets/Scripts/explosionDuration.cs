using UnityEngine;
using System.Collections;

public class explosionDuration : MonoBehaviour {

	public float Sec = 0.2f;
	public float burn = 2;
	private float fireDuration;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{


			
		fireDuration += Time.deltaTime * Sec;

		if (fireDuration >= burn)
			Destroy (gameObject);
	}
}
