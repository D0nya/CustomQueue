using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueue
{
  public class CustomQueue<TSource> : IEnumerable<TSource>
  {
    private class Node<T>
    {
      public T Value { get; set; }
      public Node<T> Next { get; set; }
      public Node<T> Prev { get; set; }

      public Node(T value)
      {
        Value = value;
      }
    }
    private class CustomQueueIterator<T> : IEnumerator<T>
    {
      private readonly CustomQueue<T> source;
      private T current;
      private int state = 0;
      private int i;
      public CustomQueueIterator(CustomQueue<T> source)
      {
        this.source = source;
      }

      public T Current { get { return current; } }
      object IEnumerator.Current { get { return Current; } }

      public bool MoveNext()
      {
        switch(state)
        {
          case 0:
            i = 0;
            state = 1;
            goto case 1;
          case 1:
            if (!(i < source.Count))
            {
              state = 0;
              return false;
            }
            current = source.Peek();
            source.Enqueue(source.Dequeue());
            state = 2;
            return true;
          case 2:
            ++i;
            goto case 1;
        }
        return false;
      }
      public void Reset()
      {
        throw new NotImplementedException();
      }
      public void Dispose(){}
    }

    private Node<TSource> start;
    private Node<TSource> end;
    public CustomQueue()
    {
      start = null;
      end = null;
    }
    public CustomQueue(IEnumerable<TSource> collection)
    {
      foreach (TSource item in collection)
      {
        Enqueue(item);
      }
    }

    public int Count { get; private set; }

    public TSource Dequeue()
    {
      if (Count == 0)
        throw new InvalidOperationException("Queue is empty");

      TSource ret = start.Value;

      start = start.Prev;
      if(start != null)
        start.Next = null;

      Count--;
      return ret;
    }
    public TSource Peek()
    {
      if(Count == 0)
        throw new InvalidOperationException("Queue is empty");

      TSource ret = start.Value;

      return ret;
    }
    public void Enqueue(TSource item)
    {
      Node<TSource> newItem = new Node<TSource>(item);
      if (end == null)
      {
        end = newItem;
        start = newItem;
      }
      else
      {
        newItem.Next = end;
        end.Prev = newItem;
        end = newItem;
      }
      Count++;
    }
    public TSource[] ToArray()
    {
      TSource[] array = new TSource[Count];
      int i = 0;

      foreach (TSource item in this)
      {
        array[i] = item;
        i++;
      }

      return array;
    }


    public IEnumerator<TSource> GetEnumerator()
    {
      return new CustomQueueIterator<TSource>(this);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
      return new CustomQueueIterator<TSource>(this);
    }
  }
}