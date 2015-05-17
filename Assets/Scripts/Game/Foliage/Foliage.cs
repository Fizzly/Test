using UnityEngine;
using System.Collections;

public class Foliage : MonoBehaviour
{
	// Data
	private int food;
	public int Food {
		get {
			return food;
		}
	}

	// New Foliage
	public Foliage ( Vector3 aPosition)
	{
		food = 100;
		transform.position = aPosition;
		FoliageManager.Instance.FoliageList.Add(this);
	}

	// Returns true if sufficient food available, else false
	public bool Eat(int anAmount)
	{
		if(food >= anAmount)
		{
			food -= anAmount;
			return true;
		}
		else
			return false;
	}
}