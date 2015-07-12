using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

public class Profile
{
	private string name;

	private DateTime currentDate;
	public DateTime CurrentDate {get {return currentDate;}}

	private int cash;

	public Profile(string name, DateTime startDate)
	{
		this.name = name;
		currentDate = startDate;
		cash = 0;
	}

	public DateTime PassTime(TimeSpan amount)
	{
		return currentDate = currentDate.AddTicks(amount.Ticks);
	}

	public void Income(int cashAmount)
	{
		cash+= cashAmount;
	}

	public void Expense(int cashAmount)
	{
		cash-= cashAmount;
	}
}

public class ProfileList
{
	private List<Profile> profiles;
	public List<Profile> Profiles {get {return profiles;}}

	public ProfileList()
	{
		profiles = new List<Profile>();
	}

	public Profile AddProfile(Profile newProfile)
	{
		profiles.Add(newProfile);
		return newProfile;
	}

}