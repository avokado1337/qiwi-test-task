using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.RemoveAt(0);
        list.Add(30);
        Console.WriteLine(list[0]);
        Console.WriteLine(list.Count);
        foreach(var i in list)
        {
            Console.WriteLine(i);
        }
        var result = from x in list where x > 10 select x;
        Console.WriteLine(string.Join(", ", result));
    }
}
class LinkedList<T> : IEnumerable<T>
{
    private Node head;
    private int size;
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
    }


    public void Add(T value)
    {
        if (head == null)
        {
            head = new Node { Value = value };
        }
        else
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node { Value = value };
        }
        size++;
    }

    public void Insert(int index, T value)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        if (index == 0)
        {
            head = new Node { Value = value, Next = head };
        }
        else
        {
            var current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = new Node { Value = value, Next = current.Next };
        }
        size++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            var current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
        size--;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }
    }

    public T GetElementAt(int index)
    {
        if (index < 0 || index > size)
        {
            throw new IndexOutOfRangeException(nameof(index));
        }
        var current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current.Value;
    }

    public int Count { get { return size; } }
    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


