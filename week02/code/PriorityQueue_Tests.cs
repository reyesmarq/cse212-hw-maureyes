using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several items with different priorities and dequeue them all.
    // Expected Result: Items come back in order from highest priority to lowest: cherry, banana, apple.
    // Defect(s) Found: The loop bound (index < _queue.Count - 1) skipped the last item in the
    // queue when searching for the highest priority, and Dequeue never removed the item it found.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("apple", 1);
        priorityQueue.Enqueue("banana", 2);
        priorityQueue.Enqueue("cherry", 3);

        Assert.AreEqual("cherry", priorityQueue.Dequeue());
        Assert.AreEqual("banana", priorityQueue.Dequeue());
        Assert.AreEqual("apple", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items that share the highest priority, followed by a lower priority item.
    // Expected Result: The item that was enqueued first (front of queue) among the tied items is
    // dequeued first: "first", then "second", then "third".
    // Defect(s) Found: The comparison used >= instead of >, so a later item with an equal priority
    // replaced the earlier one, breaking the FIFO tie-breaking rule.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None - this case already worked correctly.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}