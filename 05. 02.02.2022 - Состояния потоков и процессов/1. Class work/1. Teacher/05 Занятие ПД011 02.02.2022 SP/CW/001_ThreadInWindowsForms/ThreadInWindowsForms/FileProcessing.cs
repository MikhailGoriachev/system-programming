using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace ThreadInWindowsForms
{
    public class FileProcessing
    {
        private Label _label;
        private Form _form;

        public FileProcessing(Label label, Form form)
        {
            _label = label;
            _form = form;
        }

        public void Run1()
        {
            string fieName = "text.txt";

            int countLine = File.ReadAllLines(fieName).Length;

            if (_label.InvokeRequired)
                _form.BeginInvoke((Action) (() => _label.Text = $"{countLine}"));
            else
                _label.Text = $"{countLine}";

        }
    }
}
