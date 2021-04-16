using NUnit.Framework;


namespace test2.Test
{
    public class Tests
    {
        private Queue queue;

        [SetUp]
        public void Setup()
        {
            queue = new Queue();
            queue.Enqueue(1, 1);
            queue.Enqueue(9, 9);
            queue.Enqueue(2, 2);
            queue.Enqueue(5, 5);
            queue.Enqueue(3, 3);
            queue.Enqueue(4, 4);
            queue.Enqueue(5, 10);
            queue.Enqueue(7, 10);
            queue.Enqueue(10, 10);
            queue.Enqueue(7, 7);
            queue.Enqueue(8, 8);
            queue.Enqueue(6, 6);
        }

        [Test]
        public void EnqueueTest()
        {
            var queueNew = new Queue();
            Assert.IsTrue(queueNew.Empty());
            queueNew.Enqueue(1, 4);
            Assert.IsFalse(queueNew.Empty());
        }

        [Test]
        public void DequeueTest()
        {
            int[] result1 = new int[4]{ 5, 7, 10, 9 };
            var functionResult = queue.Dequeue();
            Assert.AreEqual(result1[0], functionResult);
            functionResult = queue.Dequeue();
            Assert.AreEqual(result1[1], functionResult);
            functionResult = queue.Dequeue();
            Assert.AreEqual(result1[2], functionResult);
            functionResult = queue.Dequeue();
            Assert.AreEqual(result1[3], functionResult);
        }

        [Test]
        public void DequeueExceptionTest()
        {
            var queueException = new Queue();
            Assert.Throws<QueueException>(() => queueException.Dequeue());
        }
    }
}