using System;
using System.Windows.Forms;

namespace CommandPattern
{
    //  we have defined with the Document object are the operations that could be performed 
    // against this document, completely decoupling this functionality from our main application.
    //  If we want to change what happens when we bold a selection, we go to this object, 
    // rather than to the presentation code.
	class Document // receiver
    {
		private TextBox textbox;
		public Document(TextBox tb)
		{
			this.textbox = tb;
		}

		public string Text
		{
			get { return textbox.Text; }
			set { textbox.Text = value; }
		}

		public void BoldSelection()
		{
			textbox.SelectedText = String.Format("<b>{0}</b>", textbox.SelectedText);
		}

		public void ItalicizeSelection()
		{
			textbox.SelectedText = String.Format("<i>{0}</i>", textbox.SelectedText);
		}

		public void UnderlineSelection()
		{
			textbox.SelectedText = String.Format("<u>{0}</u>", textbox.SelectedText);
		}

		public void Cut()
		{
			textbox.Cut();
		}

		public void Copy()
		{
			textbox.Copy();
		}

		public void Paste()
		{
			textbox.Paste();
		}
	}
}