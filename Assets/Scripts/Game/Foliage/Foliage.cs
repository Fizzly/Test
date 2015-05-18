using UnityEngine;
using System.Collections;

public class Foliage
{
	// Data
	private int food;
	private GameObject gameObject;

	// Properties
	public int Food {
		get {
			return food;
		}
	}
	public Vector3 Position{
		get {
			return gameObject.transform.position;
		}
	}

	public Foliage(Vector3 aPosition)
	{
		// Creation of our visual object in the scene
		gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		gameObject.transform.position = aPosition;
		gameObject.transform.parent = FoliageManager.Instance.transform;

		// Data
		food = 100;
		FoliageManager.Instance.FoliageList.Add(this);
	}

	// Returns true if sufficient food available, else false
	public bool Eat(int anAmount)
	{
		if(food >= anAmount)
		{
			food -= anAmount;
			gameObject.transform.localScale = new Vector3(1, food * 0.01f,1);
			return true;
		}
		else
			return false;
	}
}