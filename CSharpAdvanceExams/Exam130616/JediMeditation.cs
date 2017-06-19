using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam130616
{
    public class JediMeditation
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Queue<string> meditationOrder = new Queue<string>();
            var mediators = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                mediators.Append(Console.ReadLine() + " ");
            }

            var mediatorsInput = mediators.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padavans = new Queue<string>();
            var special = new Queue<string>();
            var isYodaExist = false;
            foreach (var mediator in mediatorsInput)
            {
                if (mediator.StartsWith("m"))
                {
                    masters.Enqueue(mediator);
                }
                else if (mediator.StartsWith("k"))
                {
                    knights.Enqueue(mediator);
                }
                else if (mediator.StartsWith("p"))
                {
                    padavans.Enqueue(mediator);
                }
                else if (mediator.StartsWith("y"))
                {
                    isYodaExist = true;
                }
                else
                {
                    special.Enqueue(mediator);
                }
            }
            var result = new StringBuilder();
            if (isYodaExist)
            {
                result.Append(string.Join(" ", masters) + " ");
                result.Append(string.Join(" ", knights) + " ");
                result.Append(string.Join(" ", special) + " ");
                result.Append(string.Join(" ", padavans));
            }
            else
            {
                result.Append(string.Join(" ", special) + " ");
                result.Append(string.Join(" ", masters) + " ");
                result.Append(string.Join(" ", knights) + " ");
                result.Append(string.Join(" ", padavans));
            }

            Console.WriteLine(result);
        }
    }
}