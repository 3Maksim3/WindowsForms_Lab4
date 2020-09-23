using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab4
{
    class EqCtriangle : Ctriangle
    {
        // Объявляем переменные
        private double lengthside1;
        private double lengthside2;
        private double lengthside3;
        private double Angle1, Angle2, Angle3;
        private double Perimetr, Square, Max;
        // Свойства переменных
        public double Lengthside1 { get => lengthside1; set => lengthside1 = (value > 0 ? value : 1); }
        public double Lengthside2 { get => lengthside2; set => lengthside2 = (value > 0 ? value : 1); }
        public double Lengthside3 { get => lengthside3; set => lengthside3 = (value > 0 ? value : 1); }
        public double Angle12 { get => Angle1; set => Angle1 = value; }
        public double Angle22 { get => Angle2; set => Angle2 = value; }
        public double Angle32 { get => Angle3; set => Angle3 = value; }
        public double Perimetr2 { get => Perimetr; set => Perimetr = value; }
        public double Square2 { get => Square; set => Square = value; }
        public double Max1 { get => Max; set => Max = value; }

        // Метод на проверку свойства треугольника
        public bool isCorrect()
        {
            // Если все стороны равны между собой, то вернется true
            if (this.Lengthside1 == this.Lengthside2 && this.Lengthside1 == this.Lengthside3 && this.Lengthside2 == this.Lengthside3)
                return true;
            else
                return false;
        }
        // Метод вычисления угла
        new public double GetAngle1()
        {
            return Angle11 = Math.Cos((Math.Pow(Lengthside1, 2) + Math.Pow(Lengthside3, 2) - Math.Pow(Lengthside2, 2)) / (2 * Lengthside1 * Lengthside3));
        }
        // Метод вычисления угла
        new public double GetAngle2()
        {
            return Angle21 = Math.Cos((Math.Pow(Lengthside1, 2) + Math.Pow(Lengthside2, 2) - Math.Pow(Lengthside3, 2)) / (2 * Lengthside1 * Lengthside3));
        }
        // Метод вычисления угла
        new public double GetAngle3()
        {
            return Angle31 = Math.Cos((Math.Pow(Lengthside2, 2) + Math.Pow(Lengthside3, 2) - Math.Pow(Lengthside1, 2)) / (2 * Lengthside1 * Lengthside3));
        }
        // Метод вычисления периметра
        new public double GetPerimetr()
        {
            return Lengthside1 + Lengthside2 + Lengthside3;
        }
        // Метод вычисления площади по формуле Герона
        new public double GetSquare()
        {
            double p = (Lengthside1 + Lengthside2 + Lengthside3) / 2;
            return Math.Sqrt(p * (p - Lengthside1) * (p - Lengthside2) * (p - Lengthside3));
        }
        // Метод находящий наибольший треугольник
        public double findMaxSquare(EqCtriangle[] arr)
        {
            double max = 0; // Создаем переменную и присваиваем ей 0

            if (arr.Length > 0) // Проверка на данные в массиве
                for (int i = 0; i < (arr.Length < 10 ? arr.Length : 10); i++)
                {
                    if (arr[i].GetSquare() > max) // Если элемент массива больше максимума, 
                        max = arr[i].GetSquare(); // то его значение присваиваем максимуму
                }
            return max; // Возвращаем максимум
        }

        EqCtriangle[] eqct; // Создаем массив объектов класса Равносторонний Треугольник

        public EqCtriangle() // Создаем Конструктор без параметров
        {

        }

        public EqCtriangle(int N) // Создаем конструктор с 1 параметром(в данном случае это размер массива)
        {
            if (N > 10)
                N = 10;

            eqct = new EqCtriangle[N]; // Выделяем память под массив

            Random r = new Random(); // Создаем объект класса Random

            for (int i = 0; i < eqct.Length; i++) // Цикл для заполнения элементов
            {
                do
                {
                    eqct[i] = new EqCtriangle(); // Выделяем память под каждый элемент массива
                    eqct[i].Lengthside1 = r.Next(5, 20); // Присваиваем стороне тругольника длину от 5 до 20 единиц 
                    eqct[i].Lengthside2 = r.Next(5, 20); // Присваиваем стороне тругольника длину от 5 до 20 единиц
                    eqct[i].Lengthside3 = r.Next(5, 20); // Присваиваем стороне тругольника длину от 5 до 20 единиц

                } while (!eqct[i].isCorrect()); // Пока все три стороны не соответствуют свойству равностороннего треугольника
            }
        }

        override public string ToString()  // Создаем метод для вывода элементов массива
        {
            string result = ""; // Создаем строковую переменную и присваиваем ей пустоту

            for (int i = 0; i < eqct.Length; i++) // Цикл для перебора элементов
            {
                // Строковой переменной присваиваем данные элементов
                result += "\nДанные о треугольнике № " + (i + 1) + " " +
                          "\nДлина стороны № 1 : " + eqct[i].Lengthside1 + " " +
                          "\nДлина стороны № 2 : " + eqct[i].Lengthside2 + " " +
                          "\nДлина стороны № 3 : " + eqct[i].Lengthside3 + " " +
                          "\nУгол № 1                   : " + Math.Round(eqct[i].GetAngle1() , 3) + " " +
                          "\nУгол № 2                   : " + Math.Round(eqct[i].GetAngle2(), 3) + " " +
                          "\nУгол № 3                   : " + Math.Round(eqct[i].GetAngle3(), 3) + " " +
                          "\nПериметр                   : " + Math.Round(eqct[i].GetPerimetr(), 3) + " " +
                          "\nПлощадь                    : " + Math.Round(eqct[i].GetSquare(), 3) + " " +
                          "\nМаксимальная площадь среди треугольников : " + Math.Round(eqct[i].findMaxSquare(eqct) , 3) + " " +
                          "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            }

            return result; // Возвращаем готовую строку
        }

        new public bool Save(string filename) // Создаем булевой метод для сохранения данных
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

        new public bool Load(string filename) // Создаем булевой метод для загрузки данных
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
                    Max = br.ReadDouble();
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
