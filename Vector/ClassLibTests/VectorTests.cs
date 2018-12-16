using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Tests
{
    [TestClass()]
    public class VectorTests
    {
        private Vector _vector;

        [TestInitialize()]
        public void Init()
        {
            _vector = new Vector();
        }

        [TestMethod()]
        public void PushBackTest()
        {
            _vector.PushBack(2);
            Assert.IsFalse(_vector.IsEmpty(), "Вектор пуст");
            Assert.IsTrue(_vector[0] == 2, "Значение установлено не коректно");
            _vector.PushBack(3);
            Assert.IsTrue(_vector.Size() == 2, "Размер вектора не верен");
            Assert.IsTrue(_vector[1] == 3, "Повторное значение установлено не коректно");
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            _vector.PushBack(0);
            Assert.IsFalse(_vector.IsEmpty(), "Вектор пуст");
            _vector.PopBack();
            Assert.IsTrue(_vector.IsEmpty(), "Вектор не пуст");
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(10)]
        public void SizeTest(int size)
        {
            for(int i = 0; i<size;i++)
            {
                _vector.PushBack(i);
            }
            Assert.IsTrue(_vector.Size() == size, "Несоответсвие размеров");
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(10)]
        public void ClearTest(int size)
        {
            for (int i = 0; i < size; i++)
            {
                _vector.PushBack(i);
            }
            _vector.Clear();
            Assert.AreEqual(_vector.Size(), 0, "Список не очистился");
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(10, 90)]
        [DataRow(1000000, 9)]
        public void InsertTestPositive(int pos, int value)
        {
            for (long i = 0; i < (long)pos + 1; i++)
            {
                _vector.PushBack((int)i);
            }
            var size = _vector.Size();
            _vector.Insert(pos, value);
            Assert.IsTrue(_vector.Size() == ++size, "Вектор слишком мал: " + size);
            Assert.IsTrue(_vector[pos] == value, string.Format("Не добавлено значение {0} в поле {1}", value, pos));
        }

        [DataTestMethod]
        [DataRow(-6, 1, "Позиция в векторе должна быть положительной")]
        [DataRow(-1000000, 90, "Позиция в векторе должна быть положительной")]
        [DataRow(1000000, 0, "Установка значения за пределы вектора")]
        [DataRow(1, int.MaxValue, "Установка значения за пределы вектора")]
        public void InsertTestNegative(int pos, int value, string message)
        {
            try
            {
                _vector.Insert(pos, value);
                Assert.Fail("Должна была быть ошибка");
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, message, "Не совпадают ошибки");
            }
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(1000000)]
        public void EraseTestPositive(int pos)
        {
            for(long i = 0; i < (long)pos + 4; i++)
            {
                _vector.PushBack((int)i);
            }
            var oldValue = _vector[pos];
            var size = _vector.Size();
            _vector.Erase(pos);
            Assert.IsTrue(_vector.Size() == --size, "Вектор слишком велик: " + size);
            Assert.IsFalse(_vector[pos] == oldValue, string.Format("Не удалено значение {0} в поле {1}", oldValue, pos));
        }

        [DataTestMethod]
        [DataRow(-6, "Позиция в векторе должна быть положительной")]
        [DataRow(-1000000, "Позиция в векторе должна быть положительной")]
        [DataRow(1000000, "Удаление значения за пределами вектора")]
        [DataRow(1, "Удаление значения за пределами вектора")]
        public void EraseTestNegative(int pos, string message)
        {
            try
            {
                _vector.Erase(pos);
                Assert.Fail("Должна была быть ошибка");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, message, "Не совпадают ошибки");
            }
        }

        [TestMethod()]
        public void PopBackTestPositive()
        {
            _vector.PushBack(1);
            _vector.PushBack(2);
            _vector.PopBack();
            Assert.IsTrue(_vector.Size() == 1, "Не удалился последний элемент");
            Assert.IsTrue(_vector[_vector.Size() - 1] == 1, "Удалился не последний элемент");
        }

        [TestMethod()]
        public void PopBackTestNegative()
        {
            try
            {
                _vector.PopBack();
                Assert.Fail("Должна была быть ошибка");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Вектор пуст", "Не совпадают ошибки");
            }
        }

        [DataTestMethod]
        [DataRow(-6, "Индекс не может быть отрицательным")]
        [DataRow(-1000000, "Индекс не может быть отрицательным")]
        [DataRow(1000000, "Выход за пределы границы вектора")]
        [DataRow(4, "Выход за пределы границы вектора")]
        public void IndexerTestNegative(int pos, string message)
        {
            try
            {
                _vector.PushBack(1);
                _vector.PushBack(2);
                var result = _vector[pos];
                Assert.Fail("Должна была быть ошибка");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, message, "Не совпадают ошибки");
            }
        }

        [TestMethod()]
        public void IndexerTestPositive()
        {
            _vector.PushBack(1);
            _vector.PushBack(2);
            Assert.IsTrue(_vector[0] == 1, "Не соответствует первый элемент");
            Assert.IsTrue(_vector[1] == 2, "Не соответствует второй элемент");
        }
    }
}