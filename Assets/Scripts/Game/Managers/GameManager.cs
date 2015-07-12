using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using GameEngine.Extensions;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public GameData gameData;

	void Awake()
	{
		Instance = this;

		if(PlayerPrefs.GetString("SaveGame")!=null)
			gameData = (GameData) PlayerPrefsSerialization.Load("SaveGame");

		if(gameData==null)
			gameData = new GameData();
	}

	void OnGUI()
	{
		if(gameData!=null && gameData.CurrentProfile != null)
		{
			GUI.Box (new Rect(0,0,300,30),  gameData.CurrentProfile.CurrentDate.Date.Day + " " + gameData.CurrentProfile.CurrentDate.Date.Month + " " + gameData.CurrentProfile.CurrentDate.Date.Year);
			GUI.Box (new Rect(300,0,300,30),  gameData.CurrentProfile.BankAccount.Money.ToString());
		}

		if (GUI.Button(new Rect(10,70,50,30),"Save"))
			PlayerPrefsSerialization.Save("SaveGame",gameData);

		if (GUI.Button(new Rect(80,70,50,30),"New"))
		{
			gameData.GameTime.StopTime();
			gameData = new GameData();
		}

		if (GUI.Button(new Rect(150,70,50,30),"Start"))
		{
			gameData.StartGame();
		}
	}
}
