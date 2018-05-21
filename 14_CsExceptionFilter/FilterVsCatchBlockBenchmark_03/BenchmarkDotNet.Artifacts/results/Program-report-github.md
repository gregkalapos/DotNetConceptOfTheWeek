``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.192 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
Frequency=2143474 Hz, Resolution=466.5324 ns, Timer=TSC
.NET Core SDK=2.1.300-preview1-008174
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|                           Method |      Mean |    Error |   StdDev |
|--------------------------------- |----------:|---------:|---------:|
| CountingExceptionsWithCatchBlock | 136.70 us | 2.432 us | 2.156 us |
|     CountingExceptionsWithFilter |  92.07 us | 1.714 us | 1.519 us |
