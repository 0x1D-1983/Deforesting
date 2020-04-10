using System;
using System.Collections.Generic;
using System.Linq;
using static Deforesting.StopwatchHelper;

namespace Deforesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[100000];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            StopwatchAction(() => QueryWithWhereSelectSum(data));
            StopwatchAction(() => DeforestWithAggregate(data));
            StopwatchAction(() => DeforestWithSingleSum(data));
        }

        static void QueryWithWhereSelectSum(IEnumerable<int> list)
        {
            long sum = list.AsParallel()
                .Where(i => i % 2 == 0)
                .Select(i => i + i)
                .Sum(i => (long)i);

            Console.WriteLine($"QueryWithWhereSelectSum: {sum}");
        }

        static void DeforestWithAggregate(IEnumerable<int> list)
        {
            long sum = list.AsParallel()
                .Aggregate(0L, (aggr, i) => i % 2 == 0 ? aggr + i + i : aggr);

            Console.WriteLine($"DeforestingWithAggregate: {sum}");
        }

        static void DeforestWithSingleSum(IEnumerable<int> list)
        {
            long sum = list.AsParallel()
                .Sum(i => (long)i % 2 == 0 ? (long)i + i : 0L);

            Console.WriteLine($"DeforestingWithSingleSum: {sum}");
        }
    }
}
