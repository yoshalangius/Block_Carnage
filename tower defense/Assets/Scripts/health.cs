using UnityEngine;
using System.Collections;

public class health : MonoBehaviour 
{

	public float integrity;
	public GameObject destroyed;
	public int integrityValue = 1;
	public static bool dead;

	void Start()
	{
		dead = false;
	}

	void OnTriggerEnter (Collider other)
	{
		
		
		if(other.gameObject.tag == "Enemy")
		{
			
			integrity = integrity - 1;
			DisplayHealth.count -= integrityValue;
			if(integrity <= 0)
			{
				dead = true;
				Instantiate (destroyed, transform.position, Quaternion.identity);

				DestroyObject (gameObject);
			}
		}
		
	}
}
