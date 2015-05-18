using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	// Test creating foliage for AnimalGazelle to eat
	void Start ()
	{
		for(int i=0;i<10;i++)
		{
			Foliage newFoliage = new Foliage(new Vector3(Random.Range (-30f,30f),0f,Random.Range (-30f,30f)));
		}
	}
}
