using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Profile
{
	private string name;

	private DateTime currentDate;
	public DateTime CurrentDate {get {return currentDate;}}

	private BankAccount bankAccount;
	public BankAccount BankAccount {get {return bankAccount;}}

	public Profile(string name, DateTime startDate)
	{
		this.name = name;
		currentDate = startDate;
		bankAccount = new BankAccount();
	}

	public DateTime PassTime(TimeSpan amount)
	{
		DateTime oldDate = currentDate;
		currentDate = currentDate.AddTicks(amount.Ticks);

		if(oldDate.Month != currentDate.Month)
			bankAccount.MonthHasPassed();

		return CurrentDate;
	}
}

[System.Serializable]
public class ProfileList
{
	private List<Profile> profiles;
	public List<Profile> Profiles {get {return profiles;}}

	private Profile currentProfile;
	public Profile CurrentProfile {	get {return currentProfile;	}}

	public ProfileList()
	{
		profiles = new List<Profile>();
	}

	public Profile AddProfile(Profile newProfile)
	{
		profiles.Add(newProfile);
		currentProfile = newProfile;
		return newProfile;
	}

}


[System.Serializable]
public class BankAccount
{
	private double money;
	public double Money {get {return money;}}

	private double loan;

	private double monthlyExpenses;
	private double monthlyIncome;

	public BankAccount()
	{
		money = 5000.00;
		loan = 5000.00;
		monthlyExpenses = 0.00;
		monthlyIncome = 0.00;
	}
	
	public void Income(double amount)
	{
		money+=amount;
		monthlyExpenses += amount;
	}

	public void Expense(double amount)
	{
		money-=amount;
		monthlyIncome += amount;
	}

	public void MonthHasPassed()
	{
		money = Math.Round( money - (loan * 0.014653f), 2);
	}
}