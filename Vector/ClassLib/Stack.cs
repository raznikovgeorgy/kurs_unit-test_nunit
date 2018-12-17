using System;
using System.Linq;

namespace ClassLib
{
    public class Stack
    {
        private Vector[] _elem;
        private int _size;

        private int _count;

        /// <summary>
        /// Конструктор, создает стек заданной длинны
        /// </summary>
        /// <param name="size">Длинна стека</param>
        public Stack(int size)
        {
            _count = 0;

            if (size > 0)
            {
                _size = size;
                _elem = new Vector[_size];
            }
            else
                throw new ArgumentException("Выход за пределы диапазона стека");
        }

        /// <summary>
        /// Очищает стек
        /// </summary>
        public void Clear()
        {
            _size = 0;
            _count = 0;
            Array.Clear(_elem, 0, _elem.Count() - 1);
        }

        /// <summary>
        /// Добавляет вектор в стек
        /// </summary>
        /// <param name="vector">Вектор, который нужно добавить</param>
        public void Push(Vector vector)
        {
            if (_count >= _size)
                throw new ArgumentException("Выход за пределы диапазона стека");
            _elem[_count] = vector;
            _count++;
        }

        /// <summary>
        /// Взять верхний вектор из стека и удалить его оттуда 
        /// </summary>
        /// <returns>Вектор который находится на вершине стека</returns>
        public Vector Pull()
        {
            if (_count == 0)
                throw new Exception("Стек пуст");
            Vector temp = _elem[_count - 1];
            Array.Clear(_elem, _count - 1, _count - 1);
            _count--;
            return temp;
        }

        /// <summary>
        /// Получаем вектор с вершины стека, но не удаляем
        /// </summary>
        /// <returns>Вектор на вершине стека</returns>
        public Vector Top()
        {
            if (_count == 0)
                throw new Exception("Стек пуст");

            return _elem[_count - 1];
        }

        /// <summary>
        /// Проверяет, пустой ли стек
        /// </summary>
        /// <returns>True если стек пустой, False если в стеке есть вектора</returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// Проверяет, полный ли стек
        /// </summary>
        /// <returns>True если стек полнстью заполнен, false если не полностью</returns>
        public bool IsFull()
        {
            return _size == _count;
        }
    }
}
