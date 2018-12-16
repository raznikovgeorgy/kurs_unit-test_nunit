using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLib
{
    public class Vector
    {
        /// <summary>
        /// Создаем контейнер для хранения чисел
        /// </summary>
        private List<int> elems;

        /// <summary>
        /// Оператор для обращения к элементу вектора
        /// </summary>
        public int this[int i]
		{
			get
			{
				try
				{
					return elems[i];
				}
				catch (ArgumentOutOfRangeException outOfRange)
				{

					Console.WriteLine("Error: {0}", outOfRange.Message);
					return -0;  //нужно что то вернуть еще, ругается если не возврщаться в этом блоке
				}
			}
		}

        /// <summary>
        /// Конструктор. При вызове создает динамичный контейнер
        /// </summary>
        public Vector() {
            elems = new List<int>();
        }

        /// <summary>
        /// Добавляет значение в "вектор"
        /// </summary>
        /// <param name="value">Значение которое нужно добавить в "вектор"</param>
        public void PushBack(int value)
        {
            elems.Add(value);
        }

        /// <summary>
        /// Проверяет, пустой ли вектор
        /// </summary>
        /// <returns>Возвращает true если пустой, false если есть хотя бы один элемент</returns>
        public bool IsEmpty()
        {
            return (elems.Count() == 0);
        }

        /// <summary>
        /// Возвращает количество элементов в "векторе"
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return elems.Count();
        }

        /// <summary>
        /// Очищает "вектор"
        /// </summary>
        public void Clear()
        {
            elems.Clear();
        }

        /// <summary>
        /// Добавляет число в конкретную позицию в "векторе"
        /// </summary>
        /// <param name="pos">Позиция в "векторе"</param>
        /// <param name="value">Значение, которое нужно добавить</param>
        public void Insert(int pos, int value)
        {
			if (pos > 0)
			{
				if (elems.Count() >= pos)
					elems.Insert(pos, value);
			}
        }

        /// <summary>
        /// Удаляет число в нужно позиции
        /// </summary>
        /// <param name="pos">Позиция числа, которое нужно удалить</param>
        public void Erase(int pos)
        {
			if (pos > 0)
			{
				if (elems.Count() >= pos)
					elems.Remove(elems[pos]);
			}
        }

        /// <summary>
        /// Удаляет последний элемент
        /// </summary>
        public void PopBack()
        {
            elems.RemoveAt(elems.Count-1);
        }
    }
}
