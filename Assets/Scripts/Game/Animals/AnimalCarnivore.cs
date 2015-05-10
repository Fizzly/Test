using UnityEngine;
using System.Collections;

public class AnimalCarnivore : Animal
{
	// The current prey of this carnivore
	protected AnimalHerbivore prey;

	public AnimalCarnivore(int age, Gender gender) : base(age, gender)
	{
		animalData.name = "AnimalCarnivore"; // currently only difference with base constructor
	}
}