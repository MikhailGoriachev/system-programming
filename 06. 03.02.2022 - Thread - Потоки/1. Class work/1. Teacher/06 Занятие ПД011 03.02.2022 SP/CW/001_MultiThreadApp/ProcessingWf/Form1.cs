using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Threads;

namespace ProcessingWf
{
    public partial class Form1 : Form
    {
        private Processing _processings;

        // в конструкторе создать объект для создания потоков 
        public Form1() {
            InitializeComponent();
            _processings = new Processing {
                Array1 = new[] { 1, 12, 3, 42, 10, 11 },
                Array2 = new[] { 11, 12, 32, 10, 7, -1 },
                TextFileName = "Thread2Data.txt",
                BinFileName = "Thread3Data.bin",

                Form = this,

                UserControl1 = textBox1,
                UserControl2 = textBox2,
                UserControl3 = textBox3
            };

        }

        private void Thread1_Exec(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Thread thread = new Thread(_processings.Process1);
            thread.Start();
        }

        private void Thread2_Exec(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Thread thread = new Thread(_processings.Process2);
            thread.Start();
        }

        private void Thread3_Exec(object sender, EventArgs e)
        {
            textBox3.Text = "";
            Thread thread = new Thread(_processings.Process3);
            thread.Start();
        }

        // запуск всех потков параллельно
        private void ThreadAll_Exec(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";

            List<Thread> threads = new List<Thread>(new[] {
                new Thread(_processings.Process1),
                new Thread(_processings.Process2),
                new Thread(_processings.Process3),
            });

            // запуск потоков на парвллельное исполнение
            threads.ForEach(t => t.Start());
        }

        // заверение работы приложения
        private void Quit_Execute(object sender, EventArgs e) => Application.Exit();
    }
}
