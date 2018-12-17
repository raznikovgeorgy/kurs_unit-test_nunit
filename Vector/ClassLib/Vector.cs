using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLib
{
    public class Vector : IVector
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
                if (i < 0)
                    throw new ArgumentException("Индекс не может быть отрицательным");
                if (i >= Size())
                    throw new ArgumentException("Выход за пределы границы вектора");
                return elems[i];
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
			if (pos >= 0)
			{
                if (elems.Count() >= pos)
                {
                    elems.Insert(pos, value);
                }
                else
                {
                    throw new ArgumentException("Установка значения за пределы вектора");
                }
			}
            else
            {
                throw new ArgumentException("Позиция в векторе должна быть положительной");
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
                {
                    elems.Remove(elems[pos]);
                }
                else
                {
                    throw new ArgumentException("Удаление значения за пределами вектора");
                }
            }
            else
            {
                throw new ArgumentException("Позиция в векторе должна быть положительной");
            }
        }

        /// <summary>
        /// Удаляет последний элемент
        /// </summary>
        public void PopBack()
        {
            if (elems.Count > 0)
            {
                elems.RemoveAt(elems.Count - 1);
            }
            else
            {
                throw new ArgumentException("Вектор пуст");
            }
        }
    }
}
