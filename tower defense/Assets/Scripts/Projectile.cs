using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float bulletSpeed = 10;
	public float bulletRange = 10;

	private float bulletDistence;
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.forward * Time.deltaTime * bulletSpeed);
		bulletDistence += Time.deltaTime * bulletSpeed;
		if (bulletDistence >= bulletRange)
						Destroy (gameObject);
	}
}
