using System;
using ClassLib;
using NUnit.Framework;

namespace ClassLibTests
{
    [TestFixture]
    public class StackTest
    {
        private Stack _stack;

        [SetUp]
        public void Init()
        {
            _stack = new Stack(5);
        }

        [TearDown]
        public void CleanUP()
        {
            _stack = null;
        }

        [Test(Description = "Тест конструктора класса")]
        public void ConstructTest()
        {
            Assert.Throws<ArgumentException>(() => { _stack = new Stack(-5); });
        }

        [Test(Description = "Тест очистки стека")]
        public void ClearTest()
        {
            _stack.Push(new Vector());
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestCase(66, Description = "Позитивный тест метода Push")]
        public void PushTestNewVector(int count)
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пустой");

            Assert.Throws<ArgumentException>(() => {
                for (int i = 0; i < count; ++i)
                {
                    _stack.Push(new Vector());
                }
            });

            Assert.IsFalse(_stack.IsEmpty(), "Начальный стек пуст");
        }

        [Test(Description = "Негативный тест метода Push")]
        public void PushTestNull()
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пустой");

            _stack.Push(null);

            Assert.IsFalse(_stack.IsEmpty(), "Начальный стек не пуст");
        }

        [Test(Description = "Позитивный тест метода Pull")]
        public void PullTest()
        {
            var vector1 = new Vector();
            var vector2 = new Vector();
            _stack.Push(vector1);
            _stack.Push(vector2);
            Assert.AreEqual(_stack.Pull(), vector2, "Не соответствует первому значению");
            Assert.AreEqual(_stack.Pull(), vector1, "Не соответствует второму значению");
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
        }

        [Test(Description = "Негативный тест метода Pull")]
        public void PullTest_Exception()
        {
            Assert.Throws<Exception>(() => { var testVector = _stack.Pull(); });
        }

        [Test(Description = "Тест метода Top")]
        public void TopTest()
        {
            var actual = new Vector();
            var expected = new Vector();
            expected = actual;
            _stack.Push(actual);
            Assert.AreEqual(_stack.Top(), expected, "Не соответствует ожидаемому значению");
            Assert.IsFalse(_stack.IsEmpty(), "Стек пуст");
        }

        [Test(Description = "Проверка метода IsEmpty")]
        public void IsEmptyTest()
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пуст");
            _stack.Push(new Vector());
            Assert.IsFalse(_stack.IsEmpty(), "Стек пуст");
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestCase(5, Description = "Проверка метода IsFull")]
        public void IsFullTest(int count)
        {
            Assert.IsFalse(_stack.IsFull(), "Начальный стек не заполнен");

            for (int i = 0; i < count; ++i)
            {
                _stack.Push(new Vector());
            }

            Assert.IsTrue(_stack.IsFull(), "Стек не полон");
        }
    }
}