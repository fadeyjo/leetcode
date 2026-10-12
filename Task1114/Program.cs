namespace Task1114;

class Program
{
    public class Foo
    {
        private CountdownEvent _firstDone = new(1);
        private CountdownEvent _secondDone = new(1);
        
        public Foo() {
            
        }

        public void First(Action printFirst) {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();

            _firstDone.Signal();
        }

        public void Second(Action printSecond)
        {
            _firstDone.Wait();
            
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            
            _secondDone.Signal();
        }

        public void Third(Action printThird)
        {
            _secondDone.Wait();
            
            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }
    
    static void Main(string[] args)
    {
        var myFoo = new Foo();

        var t1 = new Thread(() => myFoo.First(() => Console.WriteLine("first")));
        var t2 = new Thread(() => myFoo.Second(() => Console.WriteLine("second")));
        var t3 = new Thread(() => myFoo.Third(() => Console.WriteLine("third")));
        
        t3.Start();
        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
        t3.Join();
    }
}