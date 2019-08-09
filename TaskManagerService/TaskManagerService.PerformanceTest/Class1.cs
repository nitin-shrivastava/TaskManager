using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerService.PerformanceTest
{
    public class Class1
    {

        private Counter _counter;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
        }

        // Perfectly valid counter setup
        [PerfBenchmark(NumberOfIterations = 3, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        [CounterTotalAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        [CounterMeasurement("TestCounter")]
        public void Benchmark()
        {
            _counter.Increment();
        }
    }
}
