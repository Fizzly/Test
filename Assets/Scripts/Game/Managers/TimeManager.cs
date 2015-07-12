using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class TimeManager : MonoBehaviour
{
	// We are a singleton
	public static TimeManager Instance;

	void Awake()
	{
		Instance = this;
	}

	/// <summary>
	/// Starts the time of the game
	/// </summary>
	public void StartTime()
	{
		StartCoroutine(TimeRoutine());
	}

	/// <summary>
	/// Pauses time depending on bool
	/// </summary>
	/// <param name="paused">If set to <c>true</c> paused.</param>
	public void Pause(bool paused)
	{
		if(paused)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}

	public void StopTime()
	{
		StopAllCoroutines();
	}

	private IEnumerator TimeRoutine()
	{
		int passedSeconds = 0;
		while(passedSeconds < 60)
		{
			yield return new WaitForSeconds(0.1f);
			GameManager.Instance.CurrentGame.CurrentProfile.PassTime(new System.TimeSpan(1,0,0,0));
			passedSeconds+=10;
		}

		StartCoroutine(TimeRoutine());
	}
}
