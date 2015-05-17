using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoliageManager : MonoBehaviour
{
	// We are a singleton
	public static FoliageManager Instance;

	private List<Foliage> foliageList = new List<Foliage>();
	public List<Foliage> FoliageList {get{ return foliageList; } set { foliageList = value;	}}

	void Awake()
	{
		// Define our singleton
		Instance = this;
	}

	public Foliage GetClosestFoliage(Vector3 anOrigin)
	{
		return GetClosestFoliage(anOrigin, 0);
	}

	public Foliage GetClosestFoliage(Vector3 anOrigin, int aMinimumFood)
	{
		// To be returned foliage
		Foliage closestFoliage = null;

		// Distance containers
		float closestDistance = 9999.0f;
		float currentDistance = 0f;

		// Search for the closest, should be optimized
		foreach(Foliage foliage in foliageList)
		{
			currentDistance = Vector3.Distance(foliage.transform.position, anOrigin);
			if(currentDistance < closestDistance && foliage.Food >= aMinimumFood)
			{
				closestFoliage = foliage;
				closestDistance = currentDistance;
			}
		}

		// Return the closest foliage
		return closestFoliage;
	}
}