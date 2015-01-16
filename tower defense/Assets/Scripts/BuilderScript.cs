using UnityEngine;
using System.Collections;

public class BuilderScript : MonoBehaviour
{


	public GameObject setTower;
	public int price = 1;

	public GUISkin skin = null;
		
	bool gui = false;
		
	void Start()
	{
		price = price + Turret.buildPrice;
	}
		
	void OnGUI() 
	{    
		if (gui) 
		{
		GUI.skin = skin;
				
			// get 3d position on screen        
			Vector3 v = Camera.main.WorldToScreenPoint(transform.position);
				
			// convert to gui coordinates
			v = new Vector2(v.x, Screen.height - v.y); 
				
			// creation menu for tower
			int width = 200;
			int height = 40;
			Rect r = new Rect(v.x - width / 2, v.y - height / 2, width, height);
			//GUI.contentColor = (Score.count >= price ? Color.green : Color.red);

				
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    r.Contains(Event.current.mousePosition) &&
			    Score.count >= Turret.buildPrice) 
			{
				// decrease gold
				Score.count -= price;
					
				// instantiate
				Instantiate(setTower , transform.position, Quaternion.identity);

					
				// disable gameobject
				gameObject.SetActive(false);
			}
		}
	}
		
	public void OnMouseDown() 
	{
		gui = true;
	}
		
		
	public void OnMouseUp()
	{
		gui = false;
	}
}