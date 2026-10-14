// https://leetcode.com/problems/fizz-buzz-multithreaded/description/

namespace Task1195;

class Program
{
    public class FizzBuzz
    {
        private SemaphoreSlim sem = new(1, 1);
        
        private int n;

        private int i = 1;

        public FizzBuzz(int n) {
            this.n = n;
        }

        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)
        {
            while (true)
            {
                sem.Wait();

                if (i > n)
                {
                    sem.Release();
                    break;
                }
                
                if (i % 3 == 0 && i % 5 != 0)
                {
                    printFizz();
                    i++;
                }
                
                sem.Release();
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz) {
            while (true)
            {
                sem.Wait();
                
                if (i > n)
                {
                    sem.Release();
                    break;
                }
                
                if (i % 3 != 0 && i % 5 == 0)
                {
                    printBuzz();
                    i++;
                }
                
                sem.Release();
            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz) {
            while (true)
            {
                sem.Wait();
                
                if (i > n)
                {
                    sem.Release();
                    break;
                }
                
                if (i % 3 == 0 && i % 5 == 0)
                {
                    printFizzBuzz();
                    i++;
                }
                
                sem.Release();
            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber) {
            while (true)
            {
                sem.Wait();
                
                if (i > n)
                {
                    sem.Release();
                    break;
                }
                
                if (i % 3 != 0 && i % 5 != 0)
                    printNumber(i++);
                
                sem.Release();
            }
        }
    }
    
    static void Main(string[] args)
    {
        var n = 15;
        
        var obj = new FizzBuzz(n);

        var A = new Thread(() => obj.Fizz(() => Console.Write("fizz ")));
        var B = new Thread(() => obj.Buzz(() => Console.Write("buzz ")));
        var C = new Thread(() => obj.Fizzbuzz(() => Console.Write("fizzbuzz ")));
        var D = new Thread(() => obj.Number((int i) => Console.Write($"{i} ")));
        
        A.Start();
        B.Start();
        C.Start();
        D.Start();

        A.Join();
        B.Join();
        C.Join();
        D.Join();
    }
}