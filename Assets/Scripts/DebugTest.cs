using UnityEngine;
using System.Collections;

public class DebugTest : MonoBehaviour
{
	// Data
	private BaseBehaviour behaviour = new BaseBehaviour();

	// Use this for initialization
	void Start ()
	{
		GoEating();
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.P))
			behaviour.Pause();
		else
			behaviour.Resume();
	}

	private void GoEating()
	{
		// Release
		behaviour.OnBehaviourStopped -= GoEating;

		behaviour = new EatBehaviour(5) as BaseBehaviour;
		behaviour.Start();

		// Subscribe
		behaviour.OnBehaviourStopped += GotoSleep;
	}

	private void GotoSleep()
	{
		// Release
		behaviour.OnBehaviourStopped -= GotoSleep;

		behaviour = new SleepBehaviour(10) as BaseBehaviour;
		behaviour.Start();

		// Subscribe
		behaviour.OnBehaviourStopped += GoEating;
	}
}
