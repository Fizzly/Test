using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game
{
	private ProfileList profileList;

	public ProfileList ProfileList {
		get {
			return profileList;
		}
	}

	public Profile CurrentProfile {get{ return profileList.CurrentProfile;	}}

	public Game()
	{
		profileList = new ProfileList();
	}

	public void StartGame()
	{
		TimeManager.Instance.StartTime();

		if(profileList.Profiles.Count ==0)
			profileList.AddProfile(new Profile("Fred", System.DateTime.Today));
	}
}
