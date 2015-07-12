using UnityEngine;
using System.Collections;

public class EatBehaviour : BaseBehaviour
{
	// Data
	private AnimalData animalData;
	private Foliage foliage;

	/// <summary>
	/// Creates a new EatBehaviour
	/// </summary>
	public EatBehaviour(AnimalData animalData, Foliage foliage)
	{
		this.animalData = animalData;
		this.foliage = foliage;
	}

	public override void Start()
	{
		base.Start();
		BaseBehaviourManager.Instance.StartCoroutine(Eat ());
	}

	/// <summary>
	/// This behaviour eats until it is out of hunger
	/// </summary>
	private IEnumerator Eat()
	{
		// Only run when we're active
		while(foliage.Food > 0)
		{
			if(state != BehaviourState.paused)
			{
				// Do our thing
				if(foliage.Eat(5))
					animalData.energy += 5;

				yield return new WaitForSeconds(0.2f); // 1 second delay
			}
			else
				yield return new WaitForSeconds(0.2f); // 1 second delay
		}

		Stop ();
	}

	// When stopped, stop our routine
	public override void Stop ()
	{
		base.Stop();
		BaseBehaviourManager.Instance.StopCoroutine(Eat ());
	}
}
