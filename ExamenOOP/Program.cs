using System;

namespace ExamenOOP
{

    interface IStack
    {
        void Push(int item);

        int Pop();

        int Peek();

        int Capacity { get; set; }

        int Count { get; set; }
    }

    class Stack1 : IStack
    {
        static int MAX = 100;
        private int[] data = new int[MAX];
        int top = -1;

        public int Capacity { get => MAX; set { } }
        public int Count { get => top + 1; set { } }

        public int Peek()
        {
            if (top < 0)
                throw new Exception("Stack Underflow");
            else return data[top];
        }

        public int Pop()
        {
            if (top < 0)
                throw new Exception("Stack Underflow");
            else
            {
                int val = data[top--];
                return val;
            }
        }

        public void Push(int item)
        {
            if (top+1 >= Capacity)
                throw new Exception("Stack Overflow");
            else
            {
                data[++top] = item;
            }
        }


        public void PrintStackInChar()
        {
            for (int i = 0; i < Count; i++)
                Console.Write((char)data[i]);
        }
    }

    class Stack2 : IStack
    {
        int MAX = 100;
        private int[] data = new int[MAX];
        int top = -1;

        public int Capacity { get => MAX; set { } }
        public int Count { get => top + 1; set { } }

        public int Peek()
        {
            if (top < 0)
                throw new Exception("Stack Underflow");
            else
            {
                return data[top];
            }
        }

        public int Pop()
        {
            if (top < 0)
                throw new Exception("Stack Underflow");
            else
            {
                int val = data[top--];
                return val;
            }
        }

        public void Push(int item)
        {
            if (top+1 >= Capacity)
            {
                MAX *= 2;
                int[] doubleData = new int[MAX];

                for(int i = 0; i <= top; i++)
                    doubleData[i] = data[i];

                data = doubleData;

                data[++top] = item;
            }
            else
            {
                data[++top] = item;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack1();
            var final = new Stack1();


            stack.Push('/');
            stack.Push('u');
            stack.Push('/');
            stack.Push('l');
            stack.Push('o');
            stack.Push('v');
            stack.Push('e');
            stack.Push('\\');
            stack.Push('i');
            stack.Push('\\');

            stack.PrintStackInChar();

            Console.WriteLine();

            stack.Pop();

            while(stack.Peek() != '\\')
            {
                final.Push(stack.Peek());
                stack.Pop();
            }

            stack.Pop();

            var mid = new Stack1();

            while(stack.Peek() != '/')
            {
                mid.Push(stack.Peek());
                stack.Pop();
            }

            while(mid.Count > 0)
            {
                final.Push(mid.Peek());
                mid.Pop();
            }

            stack.Pop();

            while (stack.Peek() != '/')
            {
                final.Push(stack.Peek());
                stack.Pop();
            }

            final.PrintStackInChar();

        }
    }
}
