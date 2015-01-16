using UnityEngine;
using System.Collections;

public class builPoint : MonoBehaviour 
{
	public GameObject done;

	void Update()
	{
		if(health.dead == true)
		{
			Instantiate (done, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "base")
		{
			Destroy(gameObject);
		}
		
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "base")
		{
			Destroy(gameObject);
		}
	}
}
