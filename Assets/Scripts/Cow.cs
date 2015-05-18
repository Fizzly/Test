using UnityEngine;
using System.Collections;

public class Cow : MonoBehaviour
{
	// Data
	private BaseBehaviour behaviour = new BaseBehaviour();

	// Use this for initialization
	void Start ()
	{
		MoveToFreshGrass();
	}

	private void MoveToFreshGrass()
	{
		behaviour = new MovementBehaviour(this.gameObject, new Vector3(Random.Range (1f,20f) ,0f ,Random.Range (1f,20f)));
		behaviour.OnBehaviourStopped += StartEating;
		behaviour.Start();
	}

	private void StartEating()
	{
		// This script should be deleted, not up to date anymore
	}
}