using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassLib.Tests
{
    [TestClass()]
    public class StackTests
    {
        private Stack _stack;

        [TestInitialize()]
        public void Init()
        {
            _stack = new Stack(5);
        }

        [TestMethod()]
        public void StackTestNegative()
        {
            try
            {
                _stack = new Stack(-5);
                Assert.Fail("Должна была быть ошибка");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Выход за пределы диапазона стека", "Не совпадают ошибки");
            }
        }

        [TestMethod()]
        public void ClearTest()
        {
            _stack.Push(new Vector());
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestMethod()]
        public void PushTestNew()
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пуст");
            _stack.Push(new Vector());
            Assert.IsFalse(_stack.IsEmpty(), "Начальный стек не пуст");
        }

        [TestMethod()]
        public void PushTestNull()
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пуст");
            _stack.Push(null);
            Assert.IsFalse(_stack.IsEmpty(), "Начальный стек не пуст");
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(6)]
        public void PushTest(int count)
        {
            try
            {
                Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пуст");
                for (int i = 0; i < count; i++)
                    _stack.Push(new Vector());
                Assert.IsFalse(_stack.IsEmpty(), "Cтек  пуст");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Выход за пределы диапазона стека", "Не совпадают ошибки");
            }
        }

        [TestMethod()]
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

        [TestMethod()]
        public void PullTestNegative()
        {
            var vector1 = new Vector();
            _stack.Push(vector1);
            Assert.AreEqual(_stack.Pull(), vector1, "Не соответствует первому значению");
            try
            {
                var vector2 = _stack.Pull();
                Assert.Fail("Должна была быть ошибка");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Стек пуст", "Не совпадают ошибки");
            }
        }

        [TestMethod()]
        public void TopTest()
        {
            var vector1 = new Vector();
            var vector2 = new Vector();
            _stack.Push(vector1);
            _stack.Push(vector2);
            Assert.AreEqual(_stack.Top(), vector2, "Не соответствует первому значению");
            Assert.IsFalse(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пуст");
            _stack.Push(new Vector());
            Assert.IsFalse(_stack.IsEmpty(), "Стек пуст");
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestMethod()]
        public void IsFullTest()
        {
            Assert.IsFalse(_stack.IsFull(), "Начальный стек не полон");
            _stack.Push(new Vector());
            Assert.IsFalse(_stack.IsFull(), "Стек не полон");
            _stack.Push(new Vector());
            _stack.Push(new Vector());
            _stack.Push(new Vector());
            _stack.Push(new Vector());
            Assert.IsTrue(_stack.IsFull(), "Стек полон");
        }
    }
}