using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ProfileManager : MonoBehaviour
{
	private Profile currentProfile;
	public Profile CurrentProfile {	get {return currentProfile;	}}

	private List<Profile> profiles;
	public List<Profile> Profiles {get {return profiles;}}

	public static ProfileManager Instance;

	void Awake()
	{
		Instance = this;
		profiles = new List<Profile>();
	}

	public void CreateNewProfile(string name)
	{
		profiles.Add(new Profile(name, new DateTime(0)));
		currentProfile = profiles[profiles.Count -1];
	}
}
