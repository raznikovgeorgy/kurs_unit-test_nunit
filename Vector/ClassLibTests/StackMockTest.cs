using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClassLib;
using Moq;

namespace ClassLibTests
{
    [TestFixture]
    public class StackMockTest
    {
        private Stack _stack;

        [SetUp]
        public void Init()
        {
            _stack = new Stack(5);
        }

        [Test]
        public void PushTestNew()
        {
            var mock = new Mock<IVector>();
            _stack.Push(mock.Object);
            Assert.AreEqual(_stack.Top(), mock.Object);
        }

        [Test]
        public void ClearTest()
        {
            _stack.Push((new Mock<IVector>()).Object);
            _stack.Clear();
            Assert.IsTrue(_stack.IsEmpty(), "Стек не пуст");
        }

        [TestCase(66)]
        public void PushTest(int count)
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пуст");

            Assert.Throws<ArgumentException>(() => {
                for (int i = 0; i < count; ++i)
                {
                    var mock = new Mock<IVector>();
                    _stack.Push(mock.Object);
                }
            });

            Assert.IsFalse(_stack.IsEmpty(), "Cтек пуст");
        }

        [Test]
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

        [Test]
        public void PullTest_ArgumentException()
        {
            Assert.Throws<Exception>(() => { var testVector = _stack.Pull(); });
        }

        [Test]
        public void TopTest()
        {
            var actual = new Mock<IVector>();
            var expected = new Mock<IVector>();
            expected = actual;
            _stack.Push(actual.Object);
            Assert.AreEqual(_stack.Top(), expected.Object, "Не соответствует ожидаемому значению");
            Assert.IsFalse(_stack.IsEmpty(), "Стек пуст");
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue(_stack.IsEmpty(), "Начальный стек не пуст");
            _stack.Push((new Mock<IVector>()).Object);
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
                _stack.Push((new Mock<IVector>()).Object);
            }

            Assert.True(_stack.IsFull(), "Стек не полон");
        }
    }
}
