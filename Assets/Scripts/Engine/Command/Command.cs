using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Command 
{
	public abstract void Execute();
	public abstract void Undo ();
	public abstract void Redo ();
}

public class CommandList
{
	private int maxUndo;
	private int commandIndex;
	private List<Command> commandList;

	public CommandList( int maxUndo)
	{
		this.maxUndo = maxUndo;
		commandIndex = 0;
		commandList = new List<Command> ();
	}

	public void ExecuteCommand(Command command)
	{
		if(commandList.Count > 1)
			for(int checkIndex=commandList.Count-1; checkIndex > commandIndex; checkIndex--)
					commandList.RemoveAt(checkIndex);
		
		command.Execute ();

		if(commandList.Count > maxUndo)
			commandList.RemoveAt(0);

		commandList.Add (command);

		commandIndex = commandList.Count -1;
	}

	public void UndoCommand()
	{
		if (commandList.Count > 0 && commandIndex > 0)
		{
			commandList [commandIndex].Undo ();
			commandIndex--;
		}
	}

	public void RedoCommand()
	{
		if (commandIndex < commandList.Count - 1)
		{
			commandIndex++;
			commandList [commandIndex].Redo ();
		}
	}

}

public class MoveCommand : Command
{
	private GameObject gameObject;
	private float translation;

	private Vector3 oldPosition;

	public MoveCommand( GameObject gameObject, float translation)
	{
		this.gameObject = gameObject;
		this.translation = translation;
		oldPosition = gameObject.transform.position;
	}

	public override void Execute()
	{
		gameObject.transform.position += gameObject.transform.forward * translation;
	}

	public override void Undo()
	{
		gameObject.transform.position = oldPosition;
	}

	public override void Redo()
	{
		this.Execute ();
	}
}

public class RotateCommand : Command
{
	private GameObject gameObject;
	private Vector3 eulerAngles;
	private Quaternion oldRotation;

	public RotateCommand( GameObject gameObject, Vector3 eulerAngles)
	{
		this.gameObject = gameObject;
		this.eulerAngles = eulerAngles;
		oldRotation = gameObject.transform.rotation;
	}
	
	public override void Execute()
	{
		gameObject.transform.Rotate(eulerAngles);
	}

	public override void Undo()
	{
		gameObject.transform.rotation = oldRotation;
	}

	public override void Redo()
	{
		this.Execute ();
	}
}