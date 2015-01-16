using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class crossAirContreller : MonoBehaviour {

	public GameObject cannon;
	public GameObject autoTurret;
	public GameObject rocketTurret;
	public GameObject rocketPod;
	public GameObject selectedTurret;
	public GameObject buyEffect;
	public Transform buildspot;
	public GameObject sellEffect;

	public static float turretPrice;


	public GameObject crossAir;
	public float speed = 0.1f;


	void Update () 
	{
		if(health.dead == false)
		{

			KeyDown ();
			transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * speed);
			transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * speed);
		}
	}
	

	private void KeyDown()
	{
		if(Input.GetKeyDown("1"))
		{
			selectedTurret = cannon;
			Turret.buildPrice = 3;
			Debug.Log("i work one");
		}
		else if(Input.GetKeyDown("2"))
		{
			selectedTurret = autoTurret;
			Turret.buildPrice = 20;
			Debug.Log("i work two");
		}
		else if(Input.GetKeyDown("3"))
		{
			selectedTurret = rocketTurret;
			Turret.buildPrice = 10;
			Debug.Log("i work three");
		}
		else if(Input.GetKeyDown("4"))
		{
			selectedTurret = rocketPod;
			Turret.buildPrice = 50;
			Debug.Log("i work four");
		}
		else if(Input.GetKeyDown("space"))
		{


				if(buildspot == null)
				{
					return;
				}

				if(Score.count <= Turret.buildPrice)
				{
					
					Instantiate (sellEffect, transform.position, Quaternion.identity);
					return;
				}

				if(selectedTurret == null)
				{
					selectedTurret = cannon;
				}
				else
				{
					Score.count = Score.count - Turret.buildPrice;
					//DisplayHealth.count -= integrityValue;
					Instantiate (buyEffect, buildspot.position, Quaternion.identity);
					Instantiate (selectedTurret, buildspot.position, Quaternion.identity);
				}
			}

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "buildSpot")
		{
			if (buildspot == null)
			{
				buildspot = other.gameObject.transform;

			}
		}

	}

	void OnTriggerStay(Collider other)
	{
		if(buildspot == null)
		{
			if(other.gameObject.tag == "buildSpot")
			{
				buildspot = other.transform;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform == buildspot)
		{
			buildspot = null;
		}
	}
}
