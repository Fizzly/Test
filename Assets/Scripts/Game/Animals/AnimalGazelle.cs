using UnityEngine;
using System.Collections;

public class AnimalGazelle : AnimalHerbivore
{
	public AnimalGazelle (int age, Gender gender) : base(age, gender)
	{
		Start();
	}

	public void Start()
	{
		animalData = new AnimalData ("Animal", 10, Gender.Male);
		minimumFoodRequired = 20;

		FindFood();
	}
	
	private void FindFood()
	{
		Debug.Log ("FindFood");
		foliage = FoliageManager.Instance.GetClosestFoliage(transform.position, minimumFoodRequired);

		if(foliage!=null)
		{
			behaviour = new MovementBehaviour(this.gameObject, foliage.transform.position);
			behaviour.OnBehaviourStopped += StartEating;
			behaviour.Start();
		}
		else
			Invoke("FindFood",1.0f);
	}

	private void StartEating()
	{
		Debug.Log ("StartEating");
		behaviour = new EatBehaviour(animalData, foliage);
		behaviour.OnBehaviourStopped += FindFood;
		behaviour.Start();
	}	
}