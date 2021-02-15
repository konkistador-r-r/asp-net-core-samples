using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandPattern
{
    public partial class Form1 : Form // client
    {
        private CommandManager _commandManager = new CommandManager(); // invoker
        private Document _document;

        public Form1()
        {
            InitializeComponent();
            _document = new Document(documentTextbox); // receiver
        }

        private void CopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            _commandManager.ExecuteCommand(new CopyCommand(_document)); // client tels to invoker with command to execute and pass Object that contains all info receiver, parameters etc.
        }

        private void PasteToolStripMenuItemClick(object sender, EventArgs e)
        {
            _commandManager.ExecuteCommand(new PasteCommand(_document));
        }

        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            _commandManager.Undo();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandManager.ExecuteCommand(new BoldCommand(_document));
        }
    }
}
