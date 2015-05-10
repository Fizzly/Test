using UnityEngine;
using System.Collections;

// Maybe used when expanding current system
public enum Gender
{
	Male,
	Female,
}

public class AnimalData
{
	// Data
	public string name;
	public int age;
	public Gender gender;
	public float energy;

	public AnimalData(string name, int age, Gender gender, float engergy)
	{
		this.name = name;
		this.age = age;
		this.gender = gender;
		this.energy = energy;
	}
}

public class Animal : MonoBehaviour
{
	// This should be in a data class can be used as reference type
	protected AnimalData animalData;

	public Animal(int age, Gender gender)
	{
		animalData = new AnimalData ("Animal", age, gender, 1.0f);
	}
}