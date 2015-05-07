using UnityEngine;
using System.Collections;

public class BasicBehaviourManager : MonoBehaviour
{
	// We are a singleton
	public static BasicBehaviourManager Instance;

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