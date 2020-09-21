using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Lab4
{
    public partial class Form1 : Form
    {
        Ctriangle st;  // Создаем объект класса Ctriangle
        EqCtriangle ct; // Создаем объект класса EqCtriangle
        OpenFileDialog openFileDialog1 = new OpenFileDialog(); // Создаем объект класса EqCtriangle
        SaveFileDialog saveFileDialog1 = new SaveFileDialog(); // Создаем объект класса SaveFileDialog
        OpenFileDialog openFileDialog2 = new OpenFileDialog(); // Создаем объект класса EqCtriangle
        SaveFileDialog saveFileDialog2 = new SaveFileDialog(); // Создаем объект класса SaveFileDialog
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // Используем метод класса для фильтрации файлов
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // Используем метод класса для фильтрации файлов
            openFileDialog2.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // Используем метод класса для фильтрации файлов
            saveFileDialog2.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // Используем метод класса для фильтрации файлов
        }

        private void button1_Click(object sender, EventArgs e) // Кнопка Вычислить
        {
            try // Проверка на ошибки
            {
                st = new Ctriangle(Convert.ToInt32(textBox1.Text)); // Создаем массив объектов с введеным размером
                ct = new EqCtriangle(Convert.ToInt32(textBox2.Text));  // Создаем массив объектов с введеным размером
                richTextBox1.Text += st.ToString();  // Выводим в поле всю информации из массива
                richTextBox2.Text += ct.ToString(); // Выводим в поле всю информации из массива
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message); // Выводим сообщение об ошибке     
            }
        }

        private void button3_Click(object sender, EventArgs e) // Кнопка Сохранить
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) // Открываем Проводник и вибираем нужный файл
                return; // При выборе или нажанитии на Отмнена, закрыть Проводник
            string filename = saveFileDialog1.FileName; // Сохраняем свойства объекта в файл
            if (st.Save(filename) == true) // Если удалось сохранить данные в файл,
                MessageBox.Show("Файл сохранен"); // то выводим сообщение об успехе
            else
                MessageBox.Show("Сохранение не удалось"); // или выводим сообщение об неудаче
        }

        private void button4_Click(object sender, EventArgs e) // Кнопка Загрузить
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) // Открываем Проводник и вибираем нужный файл
                return; // При выборе или нажанитии на Отмнена, закрыть Проводник
            // получаем выбранный файл
            string filename = openFileDialog1.FileName; // Сохраняем свойства объекта в файл
            if (st.Load(filename) == true) // Если удалось считать данные из файла в переменные,
                MessageBox.Show("Данные загружены"); // то выводим сообщение об успехе
            else
                MessageBox.Show("Не удалось загрузить данные"); // или выводим сообщение об неудаче

            richTextBox1.Text = st.ToString(); // Присваиваем полю метод объкта об выводе информации из массива
            MessageBox.Show("Файл открыт"); // Выводим сообщение об открытии файла
        }

        private void button6_Click(object sender, EventArgs e) // Кнопка Сохранить(2)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.Cancel) // Открываем Проводник и вибираем нужный файл
                return; // При выборе или нажанитии на Отмнена, закрыть Проводник
            string filename = saveFileDialog2.FileName; // Сохраняем свойства объекта в файл
            if (ct.Save(filename) == true) // Если удалось сохранить данные в файл,
                MessageBox.Show("Файл сохранен"); // то выводим сообщение об успехе
            else
                MessageBox.Show("Сохранение не удалось"); // или выводим сообщение об неудаче
        }

        private void button5_Click(object sender, EventArgs e) // Кнопка Загрузить(2)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel) // Открываем Проводник и вибираем нужный файл
                return; // При выборе или нажанитии на Отмнена, закрыть Проводник
            // получаем выбранный файл
            string filename = openFileDialog2.FileName; // Сохраняем свойства объекта в файл
            if (st.Load(filename) == true) // Если удалось считать данные из файла в переменные,
                MessageBox.Show("Данные загружены"); // то выводим сообщение об успехе
            else
                MessageBox.Show("Не удалось загрузить данные"); // или выводим сообщение об неудаче

            richTextBox2.Text = ct.ToString(); // Присваиваем полю метод объкта об выводе информации из массива
            MessageBox.Show("Файл открыт"); // Выводим сообщение об открытии файла
        }

        private void button2_Click(object sender, EventArgs e) // Кнопка Очистить
        {
            // Очищаем все вводимые и выводимые поля
            textBox1.Clear(); 
            textBox2.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
        }
    }
}
