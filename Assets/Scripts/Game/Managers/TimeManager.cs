using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{
	public static TimeManager Instance;
	
	void Awake()
	{
		Instance = this;
	}

	public void StartTime()
	{
		StartCoroutine(TimeRoutine());
	}

	public void Pause(bool paused)
	{
		if(paused)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}

	public void StopTime()
	{
		StopCoroutine(TimeRoutine());
	}

	private IEnumerator TimeRoutine()
	{
		yield return new WaitForSeconds(10f);
		ProfileManager.Instance.CurrentProfile.PassTime(new System.TimeSpan(1,0,0,0));

		StartCoroutine(TimeRoutine());
	}
}
