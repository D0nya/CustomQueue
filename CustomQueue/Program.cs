using System;

namespace CustomQueue
{
  class Program
  {
    static void Main()
    {
      CustomQueue<int> queue = new CustomQueue<int>();
      queue.Enqueue(10);
      queue.Enqueue(20);
      queue.Enqueue(30);
      queue.Enqueue(40);
      queue.Enqueue(50);

      foreach (var item in queue)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("Dequeue(): {0}", queue.Dequeue()); 
      Console.WriteLine("Dequeue(): {0}", queue.Dequeue()); 
      Console.WriteLine("Dequeue(): {0}", queue.Dequeue());

      foreach (var item in queue)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine("Peek(): {0}", queue.Peek());
      Console.WriteLine("Peek(): {0}", queue.Peek());
      foreach (var item in queue)
      {
        Console.WriteLine(item);
      }
    }
  }
}