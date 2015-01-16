using UnityEngine;
using System.Collections;

public class Payload : MonoBehaviour 
{
	public float rocketSpeed = 10;
	public float rocketRange = 10;

	public GameObject Explosion;
	public bool exploded = false;


	private float rocketDistence;



	void Start () 
	{
	
	}

	void Update()
	{
		transform.Translate (Vector3.forward * Time.deltaTime * rocketSpeed);
		rocketDistence += Time.deltaTime * rocketSpeed;
		if (rocketDistence >= rocketRange)
		{
			Instantiate (Explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
		

	}


	void OnTriggerEnter (Collider other)
	{

		Debug.Log("feagbhjaga");
		if(other.gameObject.tag == "Enemy")
		{

			Instantiate (Explosion, transform.position, Quaternion.identity);

			DestroyObject (gameObject);
			exploded = true;


		}
		else if(other.gameObject.tag == "Wall")
		{
			Instantiate (Explosion, transform.position, Quaternion.identity);
			
			DestroyObject (gameObject);
			exploded = true;

		}
		else if(other.gameObject.tag == "Ground")
		{
			Instantiate (Explosion, transform.position, Quaternion.identity);
			
			DestroyObject (gameObject);
			exploded = true;

		}

	}
	
	/*void ExplodePayload ()
	{
		if(Explode == true)
		{
			Instantiate (Explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}*/
}
