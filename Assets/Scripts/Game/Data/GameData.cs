using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameData
{
	private ProfileList profileList;
	public ProfileList ProfileList {get {return profileList;}}

	public Profile CurrentProfile {get{ return profileList.CurrentProfile;	}}

	private GameTime gameTime;
	public GameTime GameTime {get {return gameTime;}}

	public GameData()
	{
		profileList = new ProfileList();
		profileList.AddProfile(new Profile("Fred", System.DateTime.Today));
		gameTime = new GameTime(CurrentProfile);
	}

	public void StartGame()
	{
		gameTime.StartTime();
	}
}
