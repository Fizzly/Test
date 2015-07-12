using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using GameEngine.Extensions;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public Game CurrentGame;

	void Awake()
	{
		Instance = this;

		if(PlayerPrefs.GetString("SaveGame")!=null)
			CurrentGame = (Game) PlayerPrefsSerialization.Load("SaveGame");

		if(CurrentGame==null)
			CurrentGame = new Game();
	}

	void OnGUI()
	{
		if(CurrentGame!=null && CurrentGame.CurrentProfile != null)
		{
			GUI.Box (new Rect(0,0,300,30),  CurrentGame.CurrentProfile.CurrentDate.Date.Day + " " + CurrentGame.CurrentProfile.CurrentDate.Date.Month + " " + CurrentGame.CurrentProfile.CurrentDate.Date.Year);
			GUI.Box (new Rect(300,0,300,30),  CurrentGame.CurrentProfile.BankAccount.Money.ToString());
		}

		if (GUI.Button(new Rect(10,70,50,30),"Save"))
			PlayerPrefsSerialization.Save("SaveGame",CurrentGame);

		if (GUI.Button(new Rect(80,70,50,30),"New"))
		{
			TimeManager.Instance.StopTime();
			CurrentGame = new Game();
		}

		if (GUI.Button(new Rect(150,70,50,30),"Start"))
		{
			CurrentGame.StartGame();
		}
	}
}
