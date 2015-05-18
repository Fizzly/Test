using UnityEngine;
using System.Collections;

public class AnimalGazelle : AnimalHerbivore
{
	public AnimalGazelle (int age, Gender gender) : base(age, gender)
	{
		Start();
	}

	// This needs to be rewritten, animal class now inherits from monobehaviour
	// Maybe add a static creation function so it can still inherit from mono
	public void Start()
	{
		animalData = new AnimalData ("Animal", 10, Gender.Male);
		minimumFoodRequired = 20;

		FindFood();
	}

	// FindFood function
	private void FindFood()
	{
		Debug.Log ("FindFood");
		foliage = FoliageManager.Instance.GetClosestFoliage(Position, minimumFoodRequired);

		if(foliage!=null)
		{
			behaviour = new MovementBehaviour(transform.gameObject, foliage.Position);
			behaviour.OnBehaviourStopped += StartEating;
			behaviour.Start();
		}
		else
			WaitAWhile();
	}

	// Started when no food is available
	private void WaitAWhile()
	{
		Debug.Log ("WaitAWhile");
		behaviour = new WaitBehaviour(2f);
		behaviour.OnBehaviourStopped += FindFood;
		behaviour.Start();
	}

	// Eat the food!
	private void StartEating()
	{
		Debug.Log ("StartEating");
		behaviour = new EatBehaviour(animalData, foliage);
		behaviour.OnBehaviourStopped += FindFood;
		behaviour.Start();
	}	
}