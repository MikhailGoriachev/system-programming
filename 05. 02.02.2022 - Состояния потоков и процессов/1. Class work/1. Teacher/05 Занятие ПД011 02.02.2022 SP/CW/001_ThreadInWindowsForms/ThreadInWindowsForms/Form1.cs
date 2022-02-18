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

namespace ThreadInWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        // длительная обработка в потоке UI
        private void button1_Click(object sender, EventArgs e) {
            int i;
            for (i = 0; i < 30; i++) {
                // Sleep() - имитация длительной обработки
                Thread.Sleep(300);
                label1.Text = $"Промежуточный результат {i}";
            }

            label1.Text = $"Расчет завершен, ответ: {i}";
        } // button1_Click

        // длительная обработка в потоке UI, использование Application.DoEvents()
        private void button2_Click(object sender, EventArgs e) {
            int i;
            for (i = 0; i < 30; i++) {
                // Sleep() - имитация длительной обработки
                Thread.Sleep(300);
                label2.Text = $"Промежуточный результат {i}";
                Application.DoEvents();
            } // for i

            label2.Text = $"Расчет завершен, ответ: {i}";
        } // button2_Click


        // Длительная обработка в другом потоке исполнения - небезопасный
        // доступ к элементам управления
        private Thread _thread1;
        private void button3_Click(object sender, EventArgs e) {
            _thread1 = new Thread(() => {
                int i;
                for (i = 0; i < 300; i++) {
                    // Sleep() - имитация длительной обработки
                    Thread.Sleep(300);
                    
                    // доступ к UI небезопасный!!!!
                    label3.Text = $"Промежуточный результат {i}";
                    Application.DoEvents();
                } // for i

                label3.Text = $"Расчет завершен, ответ: {i}";
            });

            _thread1.Start();
        } // button3_Click

        // Длительная обработка в другом потоке исполнения - безопасный
        // доступ к элементам управления
        // private Thread _thread2;
        private void button4_Click(object sender, EventArgs e) {
            // _thread2 = new Thread(() => {
            //     int i;
            //     for (i = 0; i < 300; i++) {
            //         // Sleep() - имитация длительной обработки
            //         Thread.Sleep(300);
            // 
            //         // безопасный доступ к UI 
            //         ShowLabel(label4, $"Промежуточный результат {i}");
            //         // Application.DoEvents();
            //     } // for i
            // 
            //     ShowLabel(label4, $"Расчет завершен, ответ: {i}");
            // });
            // 
            // _thread2.Start();

            FileProcessing fileProcessing = new FileProcessing(label4, this);
            Thread thread = new Thread(fileProcessing.Run1);
            thread.Start();
        } // button4_Click

        // вспомогательный метод для безопасного доступа к элементам UI
        private void ShowLabel(Label label, string str) {
            if (label.InvokeRequired)
                BeginInvoke((Action)(() => label.Text = str));
            else
                label.Text = str;
        } // ShowLabel
    }
}
