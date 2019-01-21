using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowsArgNullException()
        {
            //Arrange
            var stack = new Stack<string>();

            //Assert
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }


        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            //Arrange
            var stack = new Stack<string>();

            //Act
            stack.Push("a");

            //Assert
            Assert.That(stack.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            //Arrange
            var stack = new Stack<string>();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(0));
        }


        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            //Arrange
            var stack = new Stack<string>();

            //Assert
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }


        [Test]
        public void Pop_StackWithAFewObjects_ReturnsObjectOnTheTop()
        {
            //Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Pop();

            //Assert
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithAFewObjects_RemovedObjectOnTheTop()
        {
            //Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Pop();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(2));
        }


        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            //Arrange
            var stack = new Stack<string>();

            //Assert
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }


        [Test]
        public void Peek_StackWithObjects_ReturnObjectOnTopOfStack()
        {
            //Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Peek();

            //Assert
            Assert.That(result, Is.EqualTo("c"));
        }


        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
        {
            //Arrange
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            stack.Peek();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}
