using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchInSecondArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //путь
            string inputpath = "D:\\SolutionsForSpaceApp\\2023\\input.txt";
            string outputpath = "D:\\SolutionsForSpaceApp\\2023\\output.txt";

            //создание файлов
            FileStream fs = new FileStream(inputpath, FileMode.OpenOrCreate);
            fs.Close();
            FileStream fsout = new FileStream(outputpath, FileMode.OpenOrCreate);
            fsout.Close();

            //переменная для обьвления размера массива#1
            int a;
            using (var readera = new StreamReader(inputpath))
            {
                a = Convert.ToInt32(readera.ReadLine());  // записываем в переменную
            };
            //переменная для обьвления размера массива#2
            int b;
            using (var readerb = new StreamReader(inputpath))
            {
                readerb.ReadLine(); //пропуск 1 строки
                readerb.ReadLine(); //пропуск 2 строки
                b = Convert.ToInt32(readerb.ReadLine());  // записываем в переменную 3 строку
            };

            //запись в строку содержимого 2 строки файла
            string secondLine;
            using (var readersecond = new StreamReader(inputpath))
            {
                readersecond.ReadLine(); //пропуск 1 строки
                secondLine = readersecond.ReadLine();  // записываем в переменную
            }

            //запись в строку содержимого 4 строки файла
            string fourthLine;
            using (var readerfourth = new StreamReader(inputpath))
            {
                readerfourth.ReadLine(); //пропуск 1 строки
                readerfourth.ReadLine(); //пропуск 2 строки
                readerfourth.ReadLine(); //пропуск 3 строки
                fourthLine = readerfourth.ReadLine();  // записываем в переменную
            }

            //запись из строки в массив строк с разделением
            string[] secondlineforint = secondLine.Split(' ');

            string[] fourthlineforint = fourthLine.Split(' ');
          

            //создание массивов куда будут записываться числа
            int[] A;
            A = new int[a];

            int[] B;
            B = new int[b];


            //запись элементов в А
            int count = 0;
            foreach (var s in secondlineforint)
            {
                if (count <= a)
                {
                    A[count] = Convert.ToInt32(s);
                    count++;
                }
            }

            //запись элементов в Б
            count = 0;
            foreach (var sy in fourthlineforint)
            {
                if (count <= a)
                {
                    B[count] = Convert.ToInt32(sy);
                    count++;
                }
            }

            //задаю массиву С размер минимального из массивов
            int length = 0;
            if(A.Length>B.Length)
            {
                length =B.Length; 
            }
            else
            {
                length =A.Length;
            }
            //обьявление массива С
            int[] C = new int[length];

            //Сравнение элементов, запись в строку и подсчет совпадений,
            //чтобы потом переделать массив под нужный размер
            int Clength = 0;
            string outputstring = "";
            for (int i = 0; i < C.Length; i++)
            {
                if (A[i] == B[i])
                {
                    C[i] = B[i];
                    Clength++;
                    outputstring = outputstring + C[i] + " ";
                }
            }
            //переделка размера массива под количество совпадений
            C = new int[Clength];

            string SEmpty = " ";
            //если совпадений нет и строка пустая, выводим 0
            if (outputstring == SEmpty)
            {
                outputstring = 0.ToString();
            }
            else
            {
                //через writer записываю в нужном виде
                using (var outputwriter = new StreamWriter(outputpath))
                {
                    outputwriter.WriteLine(C.Length);
                    outputwriter.Write(outputstring);  // записываем в переменную
                }
            }

        }
    }
}
