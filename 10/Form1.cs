using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10
{
    public partial class Form1 : Form
    {
        // описала колекции как глобальные
        List<int> list1 = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }
        // сгенерировать
        private void сгенерироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // предварительно очищаем предыдущие значения
            list1.Clear();
            listBox1.Items.Clear();
            int amount = Convert.ToInt32(numericUpDownAmount.Value),//кол-во
                min = Convert.ToInt32(numericUpDownMin.Value),
                max = Convert.ToInt32(numericUpDownMax.Value);
            Random rnd = new Random();
            // генерируем список и сразу заполняем листбокс
            for (int i = 0; i < amount; i++)
            {
                list1.Add(rnd.Next(min, max));
                listBox1.Items.Add(list1[i]);
            }
        }
        // рассчитать
        private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pos = 0,
                otr = 0;
            for(int i = 0;i<list1.Count;i++)
            {
                if (list1[i] > 0) pos++;
                if (list1[i] < 0) otr++;
            }
            textBoxPos.Text = pos.ToString();
            textBoxOtr.Text = otr.ToString();
        }
        // сброс
        private void сбросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list1.Clear();
            listBox1.Items.Clear();
            textBoxPos.Clear();
            textBoxAdd.Clear();
        }
        // о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Дан массив в диапазоне [-100;100] найти количество положительных и отрицательных.");
        }
        // выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // проверяем конвертацию
            try
            {
                int dop = Convert.ToInt32(textBoxAdd.Text);
                // добавляем элемент в лист
                list1.Add(dop);
                // очищаем листбокс
                listBox1.Items.Clear();
                // снова заполняем его
                for (int i = 0; i < list1.Count; i++)
                {
                    listBox1.Items.Add(list1[i]);
                }
            }
            // при ошибке выводим подсказку
            catch
            {
                MessageBox.Show("Ошибка конвертации!");
                return;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i != -1)
            {
                listBox1.Items.RemoveAt(i);
                list1.RemoveAt(i);
            }
            else
            {
                MessageBox.Show("Элемент не выбран!");
            }
        }
    }
}
