using UnityEngine;
using System.Collections;

public class EatBehaviour : BaseBehaviour
{
	// Data
	private int hunger;

	/// <summary>
	/// Creates a new EatBehaviour
	/// </summary>
	public EatBehaviour(int hunger)
	{
		this.hunger = hunger;
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
		while(hunger > 0)
		{
			if(state != BehaviourState.paused)
			{
				// Do our thing
				Debug.Log ("NOM NOM NOM NOM NOM NOM NOM My hunger is: " + hunger.ToString());
				hunger -= 1;
				yield return new WaitForSeconds(1.0f); // 1 second delay
			}
			else
			{
				Debug.Log ("Paused");
				yield return new WaitForSeconds(1.0f); // 1 second delay
			}
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
