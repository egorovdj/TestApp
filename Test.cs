using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    internal class Test
    {
        private const int ReadTimeSec = 1;
        private const int WriteTimeSec = 2;

        internal void Read()
        {
            Thread.Sleep(ReadTimeSec * 1000);
            //Task.Delay(ReadTimeSec * 1000);
        }

        internal void Write()
        {
            Thread.Sleep(WriteTimeSec * 1000);
        }

        internal void Quest()
        {
            int i = 0;
            Task? r = null;
            Task? w = null;
            Console.WriteLine($"Start Quest: {DateTime.Now}");
            var read = (() =>
            {
                Console.WriteLine($"Start Read{i}: {DateTime.Now}");
                Read();
                Console.WriteLine($"Stop Read{i}: {DateTime.Now}");
            });
            var write = (() =>
            {
                Console.WriteLine($"Start Write{i}: {DateTime.Now}");
                Write();
                Console.WriteLine($"Stop Write{i}: {DateTime.Now}");
            });
            //r = Task.Run(read);
            //r.Wait();
            //i++;
            //w = Task.Run(write);
            for (i = 1; i < 10; i++)
            {
                r = Task.Run(read);
                r?.Wait();
                w?.Wait();
                w = Task.Run(write);
            }
            Console.WriteLine($"Stop Quest: {DateTime.Now}");
            // Чтение и запись должны происходить одновременно.
            // Суммарное время должно быть примерно равно (кол-ву
            // повторов + 1) * большее из времени записи и чтения
        }
    }
}
