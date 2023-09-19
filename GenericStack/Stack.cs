using System;

namespace GenericStack
{
    public class Stack<T>
    {
        private T[] Items;
        private int Sum;

        public Stack(int size)
        {
            Items=new T[size];
            Sum = -1;
        }

        public void Push(T item)
        {
            if (Sum == Items.Length -1)
            {
                Console.WriteLine("Yığın doldu!");
                return;
            }
            Items[++Sum] = item;

        }
        public T Pop()
        {
            if(Sum == -1)
            {
                Console.WriteLine("Yığın boş");
                return default(T);
            }
            return Items[Sum--];
        }

    }
}
