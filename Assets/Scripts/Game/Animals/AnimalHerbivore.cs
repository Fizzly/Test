using UnityEngine;
using System.Collections;

public class AnimalHerbivore : Animal
{
	// Current predator is is running away from
	protected AnimalCarnivore predator;

	public AnimalHerbivore(int age, Gender gender) : base(age, gender)
	{
		animalData.name = "AnimalHerbivore"; // currently only difference with base constructor
	}
}