using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GameTime
{
	private Profile profile;

	public GameTime(Profile currentProfile)
	{
		profile = currentProfile;
	}

	/// <summary>
	/// Starts the time of the game
	/// </summary>
	public void StartTime()
	{
		GameManager.Instance.StartCoroutine(TimeRoutine());
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
		GameManager.Instance.StopCoroutine(TimeRoutine());
	}

	private IEnumerator TimeRoutine()
	{
		int passedSeconds = 0;
		while(passedSeconds < 60)
		{
			yield return new WaitForSeconds(0.1f);
			profile.PassTime(new System.TimeSpan(1,0,0,0));
			passedSeconds+=10;
		}

		GameManager.Instance.StartCoroutine(TimeRoutine());
	}
}
