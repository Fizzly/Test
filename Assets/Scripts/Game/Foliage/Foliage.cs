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

	void Start()
	{
		food = 100;
		FoliageManager.Instance.FoliageList.Add(this);
	}

	// Returns true if sufficient food available, else false
	public bool Eat(int anAmount)
	{
		if(food >= anAmount)
		{
			food -= anAmount;
			transform.localScale = new Vector3(1, food * 0.01f,1);
			return true;
		}
		else
			return false;
	}
}