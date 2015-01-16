using UnityEngine;
using System.Collections;

public class Homing : MonoBehaviour 
{
	public float calTime = 1f;
	public float turnSpeed = 5f;
	public Transform target;
	public Transform rocket;
	public float calPauseTime = .25f;
	public float rocketSpeed = 10;
	public float rocketRange = 10;
	//


	//

	private float nextCalTime;
	private float nextMoveTime;
	private Quaternion desiredRotation;
	private float aimError;
	private Vector3 aimPoint;
	private float rocketDistence;


	void Awake ()
	{

	}
	void Start () 
	{


	}
	


	void Update ()
	{

		transform.Translate (Vector3.forward * Time.deltaTime * rocketSpeed);
		rocketDistence += Time.deltaTime * rocketSpeed;
		if(target)
		{
			if(Time.time >= nextMoveTime)
			{
				CalculateAimPosition(target.position);
				rocket.rotation = Quaternion.Lerp(rocket.rotation, desiredRotation, Time.deltaTime * turnSpeed);
			}
			if(Time.time >= calTime)
			{
				Calculate();
			}

		}


	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			if (target == null)
			{
				nextCalTime = Time.time + (calTime * 0.5f);
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

	void CalculateAimPosition (Vector3 targetPos)
	{
		Vector3 aimPoint = new Vector3(targetPos.x-rocket.position.x,targetPos.y-rocket.position.y,targetPos.z-rocket.position.z);
		desiredRotation = Quaternion.LookRotation (aimPoint);
	}

	void Calculate ()
	{

		nextCalTime = Time.time + calTime;
		nextMoveTime = Time.time + calPauseTime;

	}

	void explode()
	{
		if(rocket.transform == target.transform)
		{
			Destroy(gameObject);
		}
	}




}
