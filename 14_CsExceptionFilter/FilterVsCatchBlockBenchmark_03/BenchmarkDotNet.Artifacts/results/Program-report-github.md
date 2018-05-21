``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.192 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
Frequency=2143474 Hz, Resolution=466.5324 ns, Timer=TSC
.NET Core SDK=2.1.300-preview1-008174
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|                   Method |      Mean |     Error |    StdDev |
|------------------------- |----------:|----------:|----------:|
| ExceptionsWithCatchBlock | 14.485 ms | 0.2378 ms | 0.2224 ms |
|     ExceptionsWithFilter |  9.830 ms | 0.2367 ms | 0.2726 ms |
