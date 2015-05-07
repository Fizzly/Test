using UnityEngine;
using System.Collections;

public class SleepBehaviour : BasicBehaviour
{
	// Data
	private int sleep;
	
	/// <summary>
	/// Creates a new SleepBehaviour
	/// </summary>
	public SleepBehaviour(int sleep)
	{
		this.sleep = sleep;
	}
	
	public override void Start()
	{
		base.Start();
		BasicBehaviourManager.Instance.StartCoroutine(Sleep ());
	}
	
	/// <summary>
	/// This behaviour sleeps until it sleep has run out
	/// </summary>
	private IEnumerator Sleep()
	{
		// Only run when we're active
		while(sleep>0)
		{
			if(state != BehaviourState.paused)
			{
				// Do our thing
				Debug.Log ("ZZZZZZZZZZZZZZZZZzzzzzzzzzzzzz  My sleep is: " + sleep.ToString());
				sleep -= 1;
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
		BasicBehaviourManager.Instance.StopCoroutine(Sleep ());
	}
}