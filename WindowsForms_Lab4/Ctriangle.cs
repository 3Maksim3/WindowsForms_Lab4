using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab4
{
    class Ctriangle
    {
        // Обьявляем переменные
        private double lengthside1;
        private double lengthside2;
        private double lengthside3;
        private double Angle1, Angle2, Angle3;
        private double Perimetr, Square, Middle;
        // Свойства переменных
        public double Side1 { get => lengthside1; set => lengthside1 = (value > 0 ? value : 1); }
        public double Side2 { get => lengthside2; set => lengthside2 = (value > 0 ? value : 1); }
        public double Side3 { get => lengthside3; set => lengthside3 = (value > 0 ? value : 1); }
        public double Angle11 { get => Angle1; set => Angle1 = value; }
        public double Angle21 { get => Angle2; set => Angle2 = value; }
        public double Angle31 { get => Angle3; set => Angle3 = value; }
        public double Perimetr1 { get => Perimetr; set => Perimetr = value; }
        public double Square1 { get => Square; set => Square = value; }
        public double Middle1 { get => Middle; set => Middle = value; }

        // Метод на проверку существования треугольника
        public bool isCtriangle()
        {
            if ((this.Side1 + this.Side2) > this.Side3)
                return true;
            else
                return false;
        }
        // Метод вычисления угла
        public double GetAngle1()
        {
            return Angle11 = Math.Cos((Math.Pow(Side1, 2) + Math.Pow(Side3, 2) - Math.Pow(Side2, 2)) / (2 * Side1 * Side3));
        }
        // Метод вычисления угла
        public double GetAngle2()
        {
            return Angle21 = Math.Cos((Math.Pow(Side1, 2) + Math.Pow(Side2, 2) - Math.Pow(Side3, 2)) / (2 * Side1 * Side3));
        }
        // Метод вычисления угла
        public double GetAngle3()
        {
            return Angle31 = Math.Cos((Math.Pow(Side2, 2) + Math.Pow(Side3, 2) - Math.Pow(Side1, 2)) / (2 * Side1 * Side3));
        }
        // Метод вычисления периметра
        public double GetPerimetr()
        {
            return Side1 + Side2 + Side3;
        }
        // Метод вычисления площади
        public double GetSquare()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }

        Ctriangle[] eqct; // Создаем массив объектов класса Треугольник

        public Ctriangle() // Создаем Конструктор без параметров
        {

        }

        public Ctriangle(int N)  // Создаем конструктор с 1 параметром(в данном случае это размер массива)
        {
            eqct = new Ctriangle[N]; // Выделяем память под массив

            Random r = new Random(); // Создаем объект класса Random

            for (int i = 0; i < eqct.Length; i++) // Цикл для заполнения элементов
            {
                do
                {
                    eqct[i] = new Ctriangle(); // Выделяем память под каждый элемент массива
                    eqct[i].Side1 = r.Next(5, 20); // Присваиваем стороне тругольника длину от 5 до 20 единиц 
                    eqct[i].Side2 = r.Next(5, 20); // Присваиваем стороне тругольника длину от 5 до 20 единиц 
                    eqct[i].Side3 = r.Next(14, 20); // Присваиваем стороне тругольника длину от 14 до 20 единиц 

                } while (!eqct[i].isCtriangle()); // Пока все три стороны не соответствуют свойству треугольника
            }
        }

        // Метод находящий среднее арифметическое всех площадей
        public double findMiddleSquare(Ctriangle[] arr) // В параметр принимае массив
        {
            double middle = 0; // Создаем переменную и присваиваем ей 0

            if (arr.Length > 0) // Проверка на данные в массиве
                for (int i = 0; i < arr.Length; i++) // Цикл для перебора элементов массива
                    middle += arr[i].GetSquare(); // Складываем площади каждого треугольника и присваиваем значение переменной

            middle /= arr.Length; // Делим значение переменной на длину массива и присваиваем полученное значение переменной

            return middle; // Возвращаем значение переменной
        }

        override public string ToString() // Создаем метод для вывода элементов массива
        {
            string result = ""; // Создаем строковую переменную и присваиваем ей пустоту

            for (int i = 0; i < eqct.Length; i++) // Цикл для перебора элементов
            {
                // Строковой переменной присваиваем данные элементов
                result += "\nДанные о треугольнике № " + (i + 1) + " " + 
                          "\nДлина стороны № 1 : " + eqct[i].Side1 + " " +
                          "\nДлина стороны № 2 : " + eqct[i].Side2 + " " +
                          "\nДлина стороны № 3 : " + eqct[i].Side3 + " " +
                          "\nУгол № 1                   : " + Math.Round(eqct[i].GetAngle1() , 3) + " " +
                          "\nУгол № 2                   : " + Math.Round(eqct[i].GetAngle2() , 3) + " " +
                          "\nУгол № 3                   : " + Math.Round(eqct[i].GetAngle3() , 3) + " " +
                          "\nПериметр                   : " + Math.Round(eqct[i].GetPerimetr() , 3) + " " +
                          "\nПлощадь                    : " + Math.Round(eqct[i].GetSquare() , 3) + " " +
                          "\nСреднее арифметическое всех площадей : " + Math.Round(eqct[i].findMiddleSquare(eqct) , 3) + 
                          "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            }

            return result; // Возвращаем готовую строку
        }

        public bool Save(string filename) // Создаем булевой метод для сохранения данных
        {
            try // Проверка на ошибки 
            {
                // Создаем объект класса FileStream и передаем путь к файлу, открываем или создаем файл для записи 
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8); // Создаем двоичный поток для записи
                for (int i = 0; i < eqct.Length; i++) // Цикл для перебора и записи элементов массива в файл
                {
                    bw.Write(eqct[i].Side1);
                    bw.Write(eqct[i].Side2);
                    bw.Write(eqct[i].Side3);
                    bw.Write(eqct[i].GetAngle1());
                    bw.Write(eqct[i].GetAngle2());
                    bw.Write(eqct[i].GetAngle3());
                    bw.Write(eqct[i].GetPerimetr());
                    bw.Write(eqct[i].GetSquare());
                    bw.Write(eqct[i].findMiddleSquare(eqct));
                }
                bw.Close(); // Закрываем двоичный поток
                fs.Close(); // Закрываем объект класса FileStream
            }
            catch (IOException exc)
            {
                return false; // Возвращаем ложь при ошибке
            }

            return true; // Возвращаем правду при удачном исходе
        }

        public bool Load(string filename)  // Создаем булевой метод для загрузки данных
        {
            try // Проверка на ошибки 
            {
                // Создаем объект класса FileStream и передаем путь к файлу, открываем или создаем файл для чтения
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs, Encoding.UTF8); // Создаем двоичный поток для чтения
                for (int i = 0; i < eqct.Length; i++) // Цикл для перебора и чтения из файла в переменные
                {
                    Side1 = br.ReadDouble();
                    Side2 = br.ReadDouble();
                    Side2 = br.ReadDouble();
                    Angle1 = br.ReadDouble();
                    Angle2 = br.ReadDouble();
                    Angle3 = br.ReadDouble();
                    Perimetr = br.ReadDouble();
                    Square = br.ReadDouble();
                    Middle = br.ReadDouble();
                }
                br.Close(); // Закрываем двоичный поток
                fs.Close(); // Закрываем объект класса FileStream
            }
            catch (IOException exc)
            {
                return false; // Возвращаем ложь при ошибке
            }

            return true; // Возвращаем правду при удачном исходе
        }

    }
}
