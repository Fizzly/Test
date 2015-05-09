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
		behaviour = new EatBehaviour(2 + Random.Range (0,6));
		behaviour.OnBehaviourStopped += MoveToFreshGrass;
		behaviour.Start();
	}
}