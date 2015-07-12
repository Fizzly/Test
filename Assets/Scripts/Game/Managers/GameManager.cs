using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
		
	void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		ProfileManager.Instance.CreateNewProfile("John");
		TimeManager.Instance.StartTime();
	}
}
