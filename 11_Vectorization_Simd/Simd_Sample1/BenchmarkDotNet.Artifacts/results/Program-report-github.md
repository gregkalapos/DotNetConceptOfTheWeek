``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 2 [1703, Creators Update] (10.0.15063.909)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=3328125 Hz, Resolution=300.4695 ns, Timer=TSC
.NET Core SDK=2.1.4
  [Host]     : .NET Core 2.0.5 (CoreCLR 4.6.26020.03, CoreFX 4.6.26018.01), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.0.5 (CoreCLR 4.6.26020.03, CoreFX 4.6.26018.01), 64bit RyuJIT


```
|                     Method |      Mean |    Error |   StdDev |
|--------------------------- |----------:|---------:|---------:|
| AddArrays_Vector_Benchmark |  68.31 ns | 1.428 ns | 3.012 ns |
| AddArrays_Simple_Benchmark | 123.93 ns | 2.489 ns | 4.676 ns |
