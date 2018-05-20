``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.192)
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical cores and 2 physical cores
Frequency=2143475 Hz, Resolution=466.5321 ns, Timer=TSC
.NET Core SDK=2.1.4
  [Host]     : .NET Core 2.0.5 (CoreCLR 4.6.26020.03, CoreFX 4.6.26018.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.5 (CoreCLR 4.6.26020.03, CoreFX 4.6.26018.01), 64bit RyuJIT


```
|                     Method |     Mean |    Error |   StdDev |
|--------------------------- |---------:|---------:|---------:|
| AddArrays_Simple_Benchmark | 215.2 ns | 3.710 ns | 4.123 ns |
| AddArrays_Vector_Benchmark | 162.7 ns | 2.383 ns | 2.113 ns |
