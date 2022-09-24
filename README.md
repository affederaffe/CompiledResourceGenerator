# CompiledResourceGenerator

To embed a resource into your application, create a new static, partial method with a `byte[]` return type, then mark it with the `CompiledResourceAttribute` with a path to the file as an argument.

### Example
```cs
using CompiledResourceGenerator;


namespace Example
{
     internal static partial class Program
     {
          public static void Main() => Console.WriteLine(Encoding.Default.GetString(GetBytes());

          [CompiledResource("LoremIpsum.txt")]
          private static partial byte[] GetBytes();
     }
}
```

### Benchmark
|                          Method |     Mean |     Error |    StdDev |    Gen0 |   Gen1 | Allocated |
|-------------------------------- |---------:|----------:|----------:|--------:|-------:|----------:|
| EmbeddedResourceStreamBenchmark | 7.299 us | 0.0401 us | 0.0356 us | 15.7471 |      - |  64.63 KB |
|       CompiledResourceBenchmark | 6.077 us | 0.0362 us | 0.0321 us | 15.7471 | 0.0076 |  64.59 KB |
