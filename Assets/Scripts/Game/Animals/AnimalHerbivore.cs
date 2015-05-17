using UnityEngine;
using System.Collections;

public class AnimalHerbivore : Animal
{
	// Current predator it is running away from
	protected AnimalCarnivore predator;

	// Current foliage it is going to eat
	protected Foliage foliage;
	protected int minimumFoodRequired;

	public AnimalHerbivore(int age, Gender gender) : base(age, gender)
	{
		animalData.name = "AnimalHerbivore"; // currently only difference with base constructor
		minimumFoodRequired = 50;
	}
}