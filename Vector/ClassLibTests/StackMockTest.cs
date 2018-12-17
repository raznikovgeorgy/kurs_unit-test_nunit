using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTests
{
    [TestClass]
    public class StackMockTest
    {
        private Stack _stack;

        [TestInitialize()]
        public void Init()
        {
            _stack = new Stack(5);
        }

        [TestMethod()]
        public void PushTestNew()
        {
            var mock = new Mock<IVector>();
            mock.Setup(a => a.PushBack(5));
            _stack.Push(mock.Object);
            Assert.AreEqual(_stack.Top(), mock.Object);
        }

        [TestMethod()]
        public void ClearTest()
        {
            _stack.Push((new Mock<IVector>()).Object);
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
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
                {
                    var mock = new Mock<IVector>();
                    mock.Setup(a => a.PushBack(5));
                    _stack.Push(mock.Object);
                }
                Assert.IsFalse(_stack.IsEmpty(), "Cтек пуст");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Выход за пределы диапазона стека", "Не совпадают ошибки");
            }
        }

        [TestMethod()]
        public void PullTest()
        {
            var mock1 = new Mock<IVector>();
            var mock2 = new Mock<IVector>();
            _stack.Push(mock1.Object);
            _stack.Push(mock2.Object);
            Assert.AreEqual(_stack.Pull(), mock2.Object, "Не соответствует первому значению");
            Assert.AreEqual(_stack.Pull(), mock1.Object, "Не соответствует второму значению");
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestMethod()]
        public void PullTestNegative()
        {
            var mock = new Mock<IVector>();
            _stack.Push(mock.Object);
            Assert.AreEqual(_stack.Pull(), mock.Object, "Не соответствует первому значению");
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
            var mock1 = new Mock<IVector>();
            var mock2 = new Mock<IVector>();
            _stack.Push(mock1.Object);
            _stack.Push(mock2.Object);
            Assert.AreEqual(_stack.Top(), mock2.Object, "Не соответствует первому значению");
            Assert.IsFalse(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пуст");
            _stack.Push((new Mock<IVector>()).Object);
            Assert.IsFalse(_stack.IsEmpty(), "Стек пуст");
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestMethod()]
        public void IsFullTest()
        {
            Assert.IsFalse(_stack.IsFull(), "Начальный стек не полон");
            _stack.Push((new Mock<IVector>()).Object);
            Assert.IsFalse(_stack.IsFull(), "Стек не полон");
            _stack.Push((new Mock<IVector>()).Object);
            _stack.Push((new Mock<IVector>()).Object);
            _stack.Push((new Mock<IVector>()).Object);
            _stack.Push((new Mock<IVector>()).Object);
            Assert.IsTrue(_stack.IsFull(), "Стек полон");
        }
    }
}
