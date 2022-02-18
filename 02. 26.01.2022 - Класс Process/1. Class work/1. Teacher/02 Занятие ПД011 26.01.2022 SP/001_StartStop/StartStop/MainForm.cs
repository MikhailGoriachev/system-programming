using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;   // для работы с процессами

namespace StartStop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // prcMain - экземпляр компонента Process для запуска/завершения процесса 
            // prcMain.StartInfo = new ProcessStartInfo("notepad.exe");
            
            // передача параметров процессу
            prcMain.StartInfo = new ProcessStartInfo(
                "notepad.exe", @"d:\data\barmaglot.txt"
            ) {WindowStyle = ProcessWindowStyle.Normal};

            btnStop.Enabled = false;
        } // MainForm

        // Запуск процесса (можно и несколько экземпляров запустить) 
        private void btnStart_Click(object sender, EventArgs e) {
            // после запуска процесса элемент prcMain имеет доступ к его блоку управления
            // т.е. можем его завершить
            prcMain.Start();         // собственно старт процесса

            btnStop.Enabled = true;  // теперь процесс запущен, его можно остановить
        } // btnStart_Click


        // Завершение процесса, запущенного последним
        private void btnStop_Click(object sender, EventArgs e) {
            try {
                if (prcMain.HasExited) {
                    btnStop.Enabled = false;
                    return;
                } // if

                // Завершение процесса
                prcMain.CloseMainWindow(); // закрыть окно процесса
                prcMain.Close(); // освободить ресурсы процесса
                // prcMain.Kill();  // завершить принудительно

                btnStop.Enabled = false;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } // try-catch
        } // btnStop_Click

        private void btnQuit_Click(object sender, EventArgs e) {
            // завершение процесса при выходе из приложения
            btnStop_Click(this, EventArgs.Empty);
            Application.Exit();
        } // btnQuit_Click
    }
}
