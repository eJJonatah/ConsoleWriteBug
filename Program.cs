using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleStackOVerflow
{
    internal class Program
    {
        public static void WriteSafe(int number, char[] chars)
        {
            Console.Write(chars[number]);
        }
        public static char[] Chars = new char[]
        {
            'x',
            'p',
            't',
            'o'
        };
        public static void Example(char[] chars)
        {
            while (true) //<Some Condition>
            {
                Console.CursorLeft = 1;
                int l = 0;
                if (l >= chars.Length)
                    l = 0;
                Console.CursorLeft--;
                var safeWriter = new CancellationTokenSource();
                safeWriter.CancelAfter(5000);
                var write = new Task(() => WriteSafe(l, chars), safeWriter.Token);
                try
                {
                    write.Wait();
                }
                catch
                {
                    continue;
                }

                System.Threading.Thread.Sleep(600);
                l++;
            }

        }
        public static void Main()
        {
            Example(Chars);
        }
    }
}
