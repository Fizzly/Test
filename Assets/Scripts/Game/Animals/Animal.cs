using UnityEngine;
using System.Collections;

// Maybe used when expanding current system
public enum Gender
{
	Male,
	Female,
}

public class Animal : MonoBehaviour
{
	// This should be in a data class can be used as reference type
	protected string name;
	protected int age;
	protected Gender gender;

	protected float energy;

	public Animal(int age, Gender gender)
	{
		this.age = age;
		this.gender = gender;

		name = "Animal";
		energy = 1.0f;
	}
}