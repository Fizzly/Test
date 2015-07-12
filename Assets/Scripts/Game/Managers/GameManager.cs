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

	void OnGUI()
	{
		GUI.Box (new Rect(0,0,300,30),  ProfileManager.Instance.CurrentProfile.CurrentDate.Date.Day + " " + ProfileManager.Instance.CurrentProfile.CurrentDate.Date.Month + " " + ProfileManager.Instance.CurrentProfile.CurrentDate.Date.Year);
		GUI.Box (new Rect(300,0,300,30),  ProfileManager.Instance.CurrentProfile.BankAccount.Money.ToString());
	}

}
