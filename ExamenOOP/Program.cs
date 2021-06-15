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
    }

    class Stack2 : IStack
    {
        static int MAX = 2;
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

                Console.WriteLine($"top: {top}");
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
            var stack = new Stack2();

            stack.Push(69);
            Console.WriteLine(stack.Capacity);

            stack.Push(59);
            stack.Push(100);

            Console.WriteLine(stack.Capacity);
            Console.WriteLine(stack.Peek());

            stack.Pop();

            Console.WriteLine(stack.Peek());


            
        }
    }
}
