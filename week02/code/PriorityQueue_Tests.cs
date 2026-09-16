using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items to the queue.
    // Expected Result: Items are stored in the order they were added.
    // Defect(s) Found: None.

    public void TestPriorityQueue_Enqueue_AddsItemsToBack()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 4);
        priorityQueue.Enqueue("B", 6);
        priorityQueue.Enqueue("C", 2);

        var expectedResult = "[A (Pri:4), B (Pri:6), C (Pri:2)]";

        Assert.AreEqual(expectedResult, priorityQueue.ToString());
    }


    // Add more test cases as needed below.
        [TestMethod]
    // Scenario: Remove an item when two items have the same highest priority.
    // Expected Result: The first item added with that priority is removed first (FIFO).
    // Defect(s) Found: The Dequeue method did not maintain FIFO order for items with equal priority 
    // because equal priority items replaced the earlier item in the queue.
    public void TestPriorityQueue_Dequeue_SamePriorityUsesFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("A", result);
    }


    [TestMethod]
    // Scenario: Attempt to remove an item from an empty queue.
    // Expected Result: InvalidOperationException is thrown with the correct message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Dequeue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: The highest priority item was added after lower priority items.
    // Expected Result: Dequeue removes and returns the highest priority item.
    // Defect(s) Found: The Dequeue method did not check the final item in the queue when searching for 
    // the highest priority item, causing incorrect results when the highest priority item was added last.
    public void TestPriorityQueue_Dequeue_HighestPriorityAddedLast()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("C", result);
    }

        [TestMethod]
    // Scenario: Remove multiple items from the queue in priority order.
    // Expected Result: Each Dequeue removes the current highest priority item until the queue is empty.
    // Defect(s) Found: Before the fix, Dequeue returned the highest priority item but did not remove it from the queue.
    public void TestPriorityQueue_Dequeue_MultipleItems()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 10);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}