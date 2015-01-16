using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public GameObject Explosion;
	public float rocketSpeed = 10;
	public float rocketRange = 10;
	private Turret turret;
	public bool fuckthisshit = true;

	private float rocketDistence;
		
	void Start () 
	{

	}
	

	void Update () 
	{
		transform.Translate (Vector3.forward * Time.deltaTime * rocketSpeed);
		rocketDistence += Time.deltaTime * rocketSpeed;
		if (rocketDistence >= rocketRange)
						Explode ();

	}

	void OnTriggerCollider (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Explode();
		}
	}

    void Explode ()
	{
		//Instantiate (Explosion, transform.position, Quaternion.identity);
		//Destroy (gameObject);
	}
}
