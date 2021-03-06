﻿using UnityEngine;
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
	public float health;

	public AnimalData(string name, int age, Gender gender)
	{
		this.name = name;
		this.age = age;
		this.gender = gender;
		energy = 1.0f;
		health = 100.0f;
	}
}

public class Animal : MonoBehaviour
{
	// Data
	// Visual object, should be replaced if inherited from actor class
	protected GameObject gameObject;
	// This should be in a data class can be used as reference type
	protected AnimalData animalData;
	// The current behaviour of this animal
	protected BaseBehaviour behaviour;

	// Properties
	public Vector3 Position{
		get
		{
			return transform.position;
		}
	}

	public Animal(int age, Gender gender)
	{
		animalData = new AnimalData ("Animal", age, gender);
	}
}