using UnityEngine;
using System.Collections;

public class DebugTest : MonoBehaviour
{
	// Data
	private BaseBehaviour behaviour = new BaseBehaviour();

	// Use this for initialization
	void Start ()
	{
		NewTarget();
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.P))
			behaviour.Pause();
		else
			behaviour.Resume();
	}

	private void NewTarget()
	{
		behaviour = new MovementBehaviour(this.gameObject, new Vector3(Random.Range (1f,20f) ,0f ,Random.Range (1f,20f)));
		behaviour.OnBehaviourStopped += NewTarget;
		behaviour.Start();
	}

}
