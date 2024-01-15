using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создать класс «Car», со свойствами: Id, Model, Year.
//Создать базу данных «Cars». Создать таблицу с соответствующими столбцами, заполнить таблицу на 5 разных авто.
//Создать список класса, добавить все авто из таблицы и вывести на экран.
//Создать вторую коллекцию, в нее получить все авто младше 2018 года, вывести на экран.

namespace Task_1
{
    internal class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Model: {Model}, Year: {Year}";
        }
    }
}
