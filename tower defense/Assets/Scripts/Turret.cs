using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{

	public GameObject Bullet;
	public float reloadTime = 1f;
	public float turnSpeed = 5f;
	public float firePauseTime = .25f;
	public GameObject muzzleEffect;
	public float errorAmount = .001f;
	public float aimAmount = 0f;
	public Transform target;
	public Transform[] muzzlePositions;
	public Transform turretBall;
	public static int buildPrice = 1;
	public GameObject lostEffect;

	private float nextFireTime;
	private float nextMoveTime;
	private Quaternion desiredRotation;
	private float aimError;
	private Vector3 aimPoint;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		if(target)
		{
			if(Time.time >= nextMoveTime)
			{
				CalculateAimPosition(target.position);
				turretBall.rotation = Quaternion.Lerp(turretBall.rotation, desiredRotation, Time.deltaTime * turnSpeed);
			}

			if(Time.time >= nextFireTime)
			{
				FireProjectile();
			}
		}

		if (health.dead == true)
		{
			Instantiate (lostEffect, transform.position, Quaternion.identity);
			DestroyObject (gameObject);
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

	/*void CalculateAimPosition(Vector3 targetPos)
	{
		Vector3 aimPoint = new Vector3 (targetPos.x + aimError, targetPos.y + aimError, targetPos.z + aimError);
		desiredRotation = Quaternion.LookRotation (aimPoint);
	}*/

	void CalculateAimPosition (Vector3 targetPos)
	 {
		Vector3 aimPoint = new Vector3(targetPos.x-turretBall.position.x-aimAmount,targetPos.y-turretBall.position.y-aimAmount,targetPos.z-turretBall.position.z);
		desiredRotation = Quaternion.LookRotation (aimPoint);
	}

	void CalculateAimError()
	{
		aimError = Random.Range (-errorAmount, errorAmount);
	}

	void FireProjectile ()
	{
		audio.Play ();
		nextFireTime = Time.time + reloadTime;
		nextMoveTime = Time.time + firePauseTime;
		CalculateAimError ();


		foreach(Transform theMuzzlePos in muzzlePositions) 
		{
			GameObject bullet = (GameObject)Instantiate(Bullet, theMuzzlePos.position, theMuzzlePos.rotation);
			GameObject muzzleFire = (GameObject)Instantiate(muzzleEffect, theMuzzlePos.position, theMuzzlePos.rotation);
			Destroy (muzzleFire, 2.0f);
		}
	}

}
