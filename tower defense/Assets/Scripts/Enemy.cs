using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public float Dtime = 0.1f;
	public float life;
	public GameObject death;
	public int scoreValue = 1;
	private int scoreNumber = 1;
	public bool hit = false;

	public float som = 100f;
	public float some = 0f;

	void start()
	{

		//count = 0;
		//SetCountText ();
	}

	void Update()
	{
		some = some + 1f;
		if(hit == true)
		{
			Dtime = Dtime + 1f;
		}

		if(TempSpawn.wait == false)
		{
			life = life + TempSpawn.upgradeLife;
			scoreValue = scoreValue;
			some = 0f;
		}

		if(health.dead == true)
		{
			Instantiate (death, transform.position, Quaternion.identity);
			DestroyObject (gameObject);
		}
	}

	void Awake ()
	{
		//parts = GetComponent <Text> ();
	}



	void OnTriggerEnter (Collider other)
	{
		

		if(other.gameObject.tag == "Projectile")
		{
		
			life = life - 1;
			if(life <= 0)
			{
				Score.count += scoreValue;
				Parts.score += scoreNumber;
				Instantiate (death, transform.position, Quaternion.identity);
				DestroyObject (gameObject);
			}
		}

		if(other.gameObject.tag == "base")
		{
			hit = true;
			if(Dtime >= 10f)
			{
				Instantiate (death, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}
		
	}



	/*void SetCountText()
	{
		parts.text = "Parts:" + count.ToString ();
	}*/
}
