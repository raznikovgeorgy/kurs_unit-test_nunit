using System;
using System.ComponentModel.Design;
using ClassLib;
using NUnit.Framework;

namespace ClassLibTests
{
    [TestFixture]
    public class VectorTest
    {
        private Vector _vector;

        [SetUp]
        public void Initialize()
        {
            _vector = new Vector();
        }

        [TearDown]
        public void cleanUP()
        {
            _vector = null;
        }

        [Test(Description = "Проверка конструктора класса")]
        public void VectorConstructTest()
        {
            var expected = 0;

            Assert.AreEqual(expected, _vector.Size(), "Конструктор работает не верно");
        }

        [Test(Description = "Проверка заполнения вектора")]
        public void PushBackTest()
        {
            _vector.PushBack(4);

            Assert.IsFalse(_vector.IsEmpty(), "Вектор пуст");

            int expected = 4;

            Assert.AreEqual(_vector[0], expected, "Значения не совпадают");

            _vector.PushBack(11);

            Assert.AreEqual(_vector.Size(), 2, "Размер вектора не верен");
        }

        [Test(Description = "Проверка соответствия размерности вектора")]
        public void SizeTest()
        {
            int size = 10;

            for (int i = 0; i < size; ++i)
            {
                _vector.PushBack(i);
            }

            Assert.AreEqual(_vector.Size(), size, "Несоответсвие размера вектора ожидаемому значению");
        }

        [TestCase(0, Description = "Проверка метода очистки вектора")]
        public void ClearTest(int size)
        {
            for (int i = 0; i < size; ++i)
            {
                _vector.PushBack(i);
            }

            _vector.Clear();

            Assert.AreEqual(_vector.Size(), 0, "Очистка произведена некорректно, вектор не пустой");
        }

        [TestCase(10, 90, "Элементы вектора не могут располагаться вне границ вектора",
            TestName = "Позитивный тест Insert")]
        public void PositiveInsertTest(int pos, int value, string message)
        {
            for (int i = 0; i < pos + 1; i++)
            {
                _vector.PushBack(i);
            }
            var size = _vector.Size();
            _vector.Insert(pos, value);
            Assert.IsTrue(_vector.Size() == ++size, string.Format("Размер вектора должен быть: {0}, а был: {1}", ++size, _vector.Size()));
            Assert.IsTrue(_vector[pos] == value, string.Format("Не добавлено значение {0} в поле {1}", value, pos));
        }

        [TestCase(-6, 1, "Элементы вектора не могут располагаться вне границ вектора (Отрицательная позиция)",
            TestName = "Негативный тест Insert 1")]
        [TestCase(int.MaxValue, 0, "Элементы вектора не могут располагаться вне границ вектора",
            TestName = "Негативный тест Insert 2")]
        public void InsertTest_ArgumentException(int pos, int value, string message)
        {
            Assert.Throws<ArgumentException>((() => { _vector.Insert(pos, value); }));
        }

        [TestCase(10, Description = "Проверка метода удаления значения")]
        public void EraseTest(int pos)
        {
            for (int i = 0; i < pos + 4; ++i)
            {
                _vector.PushBack(i);
            }

            var oldValue = _vector[pos];
            var size = _vector.Size();

            _vector.Erase(pos);

            Assert.AreEqual(_vector.Size(), --size, string.Format("Размер вектора был: {0}, а должен быть: {1}", size, _vector.Size()));
            Assert.IsFalse(_vector[pos] == oldValue, string.Format("Не удалено значение {0} в поле {1}", oldValue, pos));
        }

        [TestCase(-6, Description = "Негативная проверка метода удаления значения")]
        [TestCase(0, Description = "Негативная проверка метода удаления значения")]
        public void EraseTest_ArgumentException(int pos)
        {
            Assert.Throws<ArgumentException>(() => { _vector.Erase(pos); });
        }

        [Test(Description = "Проверка PopBack")]
        public void PopBackTest()
        {
            int expected = 4;

            _vector.PushBack(4);
            _vector.PushBack(3);
            _vector.PopBack();

            Assert.AreEqual(_vector.Size(), 1, "Не удалось удалить последний элемент");
            Assert.AreEqual(_vector[_vector.Size() - 1], expected, "Удалился не последний элемент");
        }

        [Test(Description = "Негативный тест PopBack")]
        public void PopBackTest_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { _vector.PopBack(); });
        }
    }
}