using UnityEngine;
using System.Collections;

public class MovementBehaviour : BaseBehaviour
{
	// Data
	protected GameObject	gameObject;
	protected Vector3		origin;
	protected Vector3		target;
	protected float			duration;
	protected bool			targetIsReached;


	// Local Data
	private float currentTime;
	private float offsetTime;

	/// <summary>
	/// Creates a new MovementBehaviour
	/// </summary>
	public MovementBehaviour(GameObject gameObject, Vector3 target)
	{
		this.gameObject = gameObject;
		this.target = target;
		this.origin = gameObject.transform.position;
		this.duration = 1.0f;
		
		Setup();
	}

	public MovementBehaviour(GameObject gameObject, Vector3 target, float duration)
	{
		this.gameObject = gameObject;
		this.target = target;
		this.origin = gameObject.transform.position;
		this.duration = duration;
		
		Setup();
	}

	public MovementBehaviour(GameObject gameObject, Vector3 target, Vector3 origin, float duration)
	{
		this.gameObject = gameObject;
		this.target = target;
		this.origin = origin;
		this.duration = duration;

		Setup();
	}

	private void Setup()
	{
		targetIsReached = false;
		currentTime = 0f;

		Debug.DrawLine(origin,target,Color.green,duration);
	}

	public override void Start()
	{
		base.Start();
		BaseBehaviourManager.Instance.StartCoroutine(Move ());
	}
	
	/// <summary>
	/// This behaviour moves until it reached the target
	/// </summary>
	private IEnumerator Move()
	{
		while(targetIsReached == false)
		{
			currentTime += Time.deltaTime;
			gameObject.transform.position = Vector3.Lerp(origin, target, currentTime / duration);

			if(currentTime >= duration)
				targetIsReached = true;

			yield return new WaitForEndOfFrame();
		}

		Stop ();
	}
	
	// When stopped, stop our routine
	public override void Stop ()
	{
		base.Stop();
		BaseBehaviourManager.Instance.StopCoroutine(Move ());
	}

}
