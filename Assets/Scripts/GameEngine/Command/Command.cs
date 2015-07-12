using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameEngine
{
	public abstract class Command 
	{
		public abstract void Execute();
		public abstract void Undo ();
		public abstract void Redo ();
	}

	/// <summary>
	/// Command list keeps track of commands and enables to undo and redo commands in the list
	/// </summary>
	public class CommandList
	{
		// Data
		private int maxUndo;
		private int commandIndex;
		private List<Command> commandList;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameEngine.CommandList"/> class.
		/// Needs a maximum of undo commands stored.
		/// </summary>
		/// <param name="maxUndo">Max undo.</param>
		public CommandList( int maxUndo)
		{
			this.maxUndo = maxUndo;
			commandIndex = 0;
			commandList = new List<Command> ();
		}

		/// <summary>
		/// Executes the given command and adds it to the list.
		/// </summary>
		/// <param name="command">Command.</param>
		public void ExecuteCommand(Command command)
		{
			// Remove commands after commandIndex from the list
			if(commandList.Count > 1)
				for(int checkIndex=commandList.Count-1; checkIndex > commandIndex; checkIndex--)
						commandList.RemoveAt(checkIndex);

			// Execute the command
			command.Execute ();

			// Put the command to the list
			if(commandList.Count > maxUndo)
				commandList.RemoveAt(0);
			commandList.Add (command);

			// Update commandIndex
			commandIndex = commandList.Count -1;
		}

		/// <summary>
		/// Undos the command.
		/// </summary>
		public void UndoCommand()
		{
			if (commandList.Count > 0 && commandIndex > 0)
				commandList [commandIndex].Undo ();
				commandIndex--;
		}

		/// <summary>
		/// Redos the command.
		/// </summary>
		public void RedoCommand()
		{
			if (commandIndex < commandList.Count - 1)
				commandIndex++;
				commandList [commandIndex].Redo ();
		}
	}

	public class MoveCommand : Command
	{
		// Data
		private GameObject gameObject;
		private float translation;
		private Vector3 oldPosition;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameEngine.MoveCommand"/> class.
		/// Moves a given object along its transform.forward by translation
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		/// <param name="translation">Translation.</param>
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
}