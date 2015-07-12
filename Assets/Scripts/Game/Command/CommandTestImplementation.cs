using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameEngine;

public class CommandTestImplementation : MonoBehaviour
{
	[SerializeField]
	private GameObject testObject;

	// Command Data
	private Command currentCommand;
	private CommandList commandList = new CommandList(5);

	void Update ()
	{
		currentCommand = GetInputCommand (testObject);

		if (currentCommand != null)
			commandList.ExecuteCommand (currentCommand);
		if (Input.GetKeyDown (KeyCode.U))
			commandList.UndoCommand ();
		if (Input.GetKeyDown (KeyCode.R))	
			commandList.RedoCommand ();
	}

	private Command GetInputCommand(GameObject gameObject)
	{
		if (Input.GetKeyDown(KeyCode.W))
			return new MoveCommand (gameObject, 1f);
		if (Input.GetKeyDown(KeyCode.S))
			return new MoveCommand (gameObject, -1f );

		if (Input.GetKeyDown(KeyCode.A))
			return new RotateCommand (gameObject,new Vector3(0f, -45f,0f));
		if (Input.GetKeyDown(KeyCode.D))
			return new RotateCommand (gameObject,new Vector3(0f,  45f,0f));

		return null;
	}
}
