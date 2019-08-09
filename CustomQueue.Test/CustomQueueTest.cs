using System;
using Xunit;

namespace CustomQueue.Test
{
  public class CustomQueueTest
  {
    private CustomQueue<int> queue;

    [Fact]
    public void Count_CountEmptyQueue_Return0()
    {
      queue = new CustomQueue<int>();

      var res = queue.Count;

      Assert.Equal(0, res);
    }

    [Fact]
    public void Count_AddItemsAndCount_Return5()
    {
      queue = new CustomQueue<int>(new int[] { 100,200,300,400,500});

      var res = queue.Count;

      Assert.Equal(5, res);
    }

    [Fact]
    public void Dequeue_GetFirstItemFromEmptyQueue_ThrowInvalidOperationException()
    {
      queue = new CustomQueue<int>();

      var e = Assert.Throws<InvalidOperationException>(()=>queue.Dequeue());

      Assert.Equal("Queue is empty", e.Message);
    }

    [Fact]
    public void Peek_GetFirstItemWithoutReturn_Return10()
    {
      queue = new CustomQueue<int>(new int[] { 10, 20, 30 });

      // Get first without return: 10
      var res = queue.Peek();
      Assert.Equal(10, res);

      // Get first without return: 10
      res = queue.Peek();
      Assert.Equal(10, res);

      // Get first and return: 10
      res = queue.Dequeue();
      Assert.Equal(10, res);

      // Get first and return: 20
      res = queue.Dequeue();
      Assert.Equal(20, res);
    }

    [Fact]
    public void CustomQueueIterator_GetItemsFromQueueUsingForeach_ReturnQueue()
    {
      queue = new CustomQueue<int>(new int[] { 1, 2, 3, 4, 5 });
      int times = 0;

      foreach (int item in queue)
      {
        Assert.InRange(item, 1, 5);
        times++;
      }
      Assert.Equal(5, times);
    }
  }
}
