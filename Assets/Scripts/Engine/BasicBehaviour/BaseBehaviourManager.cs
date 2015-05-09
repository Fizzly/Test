using UnityEngine;
using System.Collections;

public class BaseBehaviourManager : MonoBehaviour
{
	// We are a singleton
	public static BaseBehaviourManager Instance;

	void Awake()
	{
		// Define our singleton
		Instance = this;
	}

	/// <summary>
	/// Used by behaviours to start a coroutine
	/// Done here since only monobehaviour have coroutine functionality
	/// </summary>
	public void StartRoutine(IEnumerator routine)
	{
		StartCoroutine(routine);
	}

	/// <summary>
	/// Used by behaviours to stop a coroutine
	/// Done here since only monobehaviour have coroutine functionality
	/// </summary>
	public void StopRoutine(IEnumerator routine)
	{
		StopRoutine(routine);
	}
}