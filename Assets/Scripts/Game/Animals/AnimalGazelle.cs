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
		FindFood();
	}
	
	private void FindFood()
	{
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
		behaviour = new EatBehaviour(2 + Random.Range (0,6));
		behaviour.OnBehaviourStopped += FindFood;
		behaviour.Start();
	}	
}