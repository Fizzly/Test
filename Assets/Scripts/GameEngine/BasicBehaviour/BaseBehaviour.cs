using UnityEngine;
using System.Collections;

public class BaseBehaviour
{
	// Keeps track of the state
	internal BehaviourState state;

	// Events
	public delegate void BehaviourStarted();
	public event BehaviourStarted OnBehaviourStarted;

	public delegate void BehaviourStopped();
	public event BehaviourStopped OnBehaviourStopped;

	/// <summary>
	/// This is called when the behaviour should start
	/// </summary>
	public virtual void Start()
	{
		state = BehaviourState.running;

		// Start Event;
		if(OnBehaviourStarted!=null)
			OnBehaviourStarted();
	}

	public virtual void Pause()
	{
		state = BehaviourState.paused;
	}

	public virtual void Resume()
	{
		state = BehaviourState.running;
	}

	public virtual void Stop()
	{
		state = BehaviourState.off;

		// Stop Event;
		if(OnBehaviourStopped!=null)
			OnBehaviourStopped();
	}
}

public enum BehaviourState
{
	off = 0,
	running,
	paused
}