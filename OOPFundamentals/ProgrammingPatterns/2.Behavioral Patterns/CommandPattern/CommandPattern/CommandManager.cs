using System.Collections;

namespace CommandPattern
{
    // By creating a document object that wraps the textbox, we were able to completely decouple 
    // the object that will invoke the operation (Command as e.g. menu item) from the one that knows 
    // how to perform it (the document object).


    // The remaining piece that we will need to bring everything together is a CommandManager. 
    // The CommandManager is a very simple class that has an internal stack that keeps track of 
    // our commands for our undo functionality.

    // Commands are pops from stack
    class CommandManager // invoker
    {
		private Stack commandStack = new Stack();

		public void ExecuteCommand(Command cmd)
		{
			cmd.Execute();
			if (cmd is UndoableCommand)
			{
				commandStack.Push(cmd);
			}
		}

		public void Undo()
		{
			if (commandStack.Count > 0)
			{
				UndoableCommand cmd = (UndoableCommand)commandStack.Pop();
				cmd.Undo();
			}
		}
	}
}
