using System;

namespace CommandPattern
{
    // Since it is possible that we have commands that will not require undo functionality 
    // (for example, Copy), we have created two base classes (Command and UndoableCommand).
	public abstract class Command
	{
		public abstract void Execute();
	}

	public abstract class UndoableCommand : Command
	{
		public abstract void Undo();
	}

    // As we work through our application and start adding menu items to it, 
    // we will start to see that we need a Command object to handle each of this actions.
	class BoldCommand : UndoableCommand
	{
		private Document document;
		private string previousText;
		public BoldCommand(Document document)
		{
			this.document = document;
			previousText = this.document.Text;
		}

		public override void Execute()
		{
			document.BoldSelection();
		}

		public override void Undo()
		{
			document.Text = previousText;
		}
    } // command

    class UnderlineCommand : UndoableCommand
	{
		private Document document;
		private string previousText;
		public UnderlineCommand(Document document)
		{
			this.document = document;
			previousText = this.document.Text;
		}

		public override void Execute()
		{
			document.UnderlineSelection();
		}

		public override void Undo()
		{
			document.Text = previousText;
		}
    } // command

    class ItalicizeCommand : UndoableCommand
	{
		private Document document;
		private string previousText;
		public ItalicizeCommand(Document document)
		{
			this.document = document;
			previousText = this.document.Text;
		}

		public override void Execute()
		{
			document.ItalicizeSelection();
		}

		public override void Undo()
		{
			document.Text = previousText;
		}
	}

	class CutCommand : UndoableCommand
	{
		private Document document;
		private string previousText;
		public CutCommand(Document document)
		{
			this.document = document;
			previousText = this.document.Text;
		}

		public override void Execute()
		{
			document.Cut();
		}

		public override void Undo()
		{
			document.Text = previousText;
		}
	}

	class PasteCommand : UndoableCommand
	{
		private Document document;
		private string previousText;
		public PasteCommand(Document document)
		{
			this.document = document;
			previousText = this.document.Text;
		}

		public override void Execute()
		{
			document.Paste();
		}

		public override void Undo()
		{
			document.Text = previousText;
		}
	}

	class CopyCommand : Command
	{
		private Document document;
		public CopyCommand(Document document)
		{
			this.document = document;
		}

		public override void Execute()
		{
			document.Copy();
		}
	}
}
