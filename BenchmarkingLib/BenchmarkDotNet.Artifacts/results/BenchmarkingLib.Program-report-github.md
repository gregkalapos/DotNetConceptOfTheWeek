``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.192)
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical cores and 2 physical cores
Frequency=2143476 Hz, Resolution=466.5319 ns, Timer=TSC
.NET Core SDK=2.1.2
  [Host]     : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT


```
|               Method |     Mean |     Error |    StdDev |   Median |    Gen 0 |    Gen 1 |  Allocated |
|--------------------- |---------:|----------:|----------:|---------:|---------:|---------:|-----------:|
|    CalculateWithLinq | 12.67 ms | 0.6614 ms | 1.9501 ms | 11.98 ms | 296.8750 | 109.3750 | 1168.34 KB |
| CalculateWithNonLinq | 17.29 ms | 0.3448 ms | 0.2879 ms | 17.27 ms | 125.0000 |  31.2500 |  434.43 KB |
