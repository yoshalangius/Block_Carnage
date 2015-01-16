using UnityEngine;
using System.Collections;

public class RocketPod : MonoBehaviour 
{

	public GameObject rocket;
	public float reloadTime = 1f;
	public float turnSpeed = 5f;
	public float firePauseTime = 0.25f;
	public float error = .001f;
	public Transform target;
	public Transform[] muzzlePositions;
	public Transform pivotTilt;
	public Transform pivotPan;
	public Transform aimTilt;
	public Transform aimPan;
	public int m;

	private float nextFireTime;
	private Vector3 desiredRotation;
	private float aimError;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(target)
		{
			aimPan.LookAt (target);
			//aimPan.eulerAngles = Vector3 (0, aimPan.eulerAngles.y, 0);
			aimTilt.LookAt (target);

			pivotPan.rotation = Quaternion.Lerp (pivotPan.rotation, aimPan.rotation, Time.deltaTime * turnSpeed);
			pivotTilt.rotation = Quaternion.Lerp (pivotTilt.rotation, aimTilt.rotation, Time.deltaTime * turnSpeed);
		}

		if(Time.time >= nextFireTime)
		{
			FireRocket();
		}
	}

	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			if (target == null)
			{
				nextFireTime = Time.time + (reloadTime * 0.5f);
				target = other.gameObject.transform;
			}
		}
		
	}
	
	void OnTriggerStay(Collider other)
	{
		if(target == null)
		{
			if(other.gameObject.tag == "Enemy")
			{
				target = other.transform;
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform == target)
		{
			target = null;
		}
	}

	void FireRocket ()
	{
		audio.Play();

		nextFireTime = Time.time + reloadTime;
		m = Random.Range (0,6);

		GameObject newRocket = (GameObject)Instantiate(rocket, muzzlePositions[m].position, muzzlePositions[m].rotation);

	}
}

