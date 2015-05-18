using UnityEngine;
using System.Collections;

public class WaitBehaviour : BaseBehaviour 
{
	// Data
	private float duration;
	
	/// <summary>
	/// Creates a new WaitBehaviour
	/// </summary>
	public WaitBehaviour(float duration)
	{
		this.duration = duration;
	}
	
	public override void Start()
	{
		base.Start();
		BaseBehaviourManager.Instance.StartCoroutine(Wait ());
	}
	
	/// <summary>
	/// This behaviour waits until it has reached its duration
	/// </summary>
	private IEnumerator Wait()
	{
		yield return new WaitForSeconds(duration);
		Stop ();
	}
	
	// When stopped, stop our routine
	public override void Stop ()
	{
		base.Stop();
		BaseBehaviourManager.Instance.StopCoroutine(Wait());
	}
}