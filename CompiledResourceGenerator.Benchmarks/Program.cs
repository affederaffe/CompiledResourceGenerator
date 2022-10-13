using System.IO;
using System.Reflection;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace CompiledResourceGenerator.Benchmarks
{
     internal static partial class Program
     {
          public static void Main() => BenchmarkRunner.Run<Test>();


          [CompiledResource("LoremIpsum.txt")]
          public static partial byte[] GetBytes();
     }

     [MemoryDiagnoser]
     public class Test
     {
          [Benchmark(Baseline = true)]
          public void EmbeddedResourceStreamBenchmark()
          {
               Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CompiledResourceGenerator.Benchmarks.LoremIpsum.txt")!;
               new StreamReader(stream).ReadToEnd();
          }

          [Benchmark]
          public void CompiledResourceBenchmark()
          {
               Stream stream = new MemoryStream(Program.GetBytes());
               new StreamReader(stream).ReadToEnd();
          }
     }
}
