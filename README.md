# Memories

A dotNet Memory Pool

## Nuget Package
[Latest Version](https://www.nuget.org/packages/Seven.Memories/)

## Benchmark
### Initialize And Dispose
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1082 (1909/November2018Update/19H2)
Intel Core i5-9400F CPU 2.90GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=3.1.402
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  CoreRt 3.1 : .NET 5.0.29325.02 @BuiltBy: dlab14-DDVSOWINAGE075 @Branch: master @Commit: 64389dad34695712b2520fba2b04713c7c220d89, X64 AOT

Job=CoreRt 3.1  Runtime=CoreRt 3.1  

```
|  Count |  Size |       Mean |    Error |   StdDev |     Median |
|------- |------ |-----------:|---------:|---------:|-----------:|
|     **10** |  **1024** |   **109.5 ms** |  **3.13 ms** |  **9.23 ms** |   **103.4 ms** |
|     **10** |  **2048** |   **109.4 ms** |  **2.17 ms** |  **5.60 ms** |   **109.0 ms** |
|     **10** | **10240** |   **108.1 ms** |  **2.34 ms** |  **6.91 ms** |   **106.7 ms** |
|     **10** | **20480** |   **101.2 ms** |  **2.01 ms** |  **2.06 ms** |   **101.8 ms** |
|    **100** |  **1024** |   **101.9 ms** |  **0.16 ms** |  **0.14 ms** |   **101.9 ms** |
|    **100** |  **2048** |   **101.9 ms** |  **0.13 ms** |  **0.12 ms** |   **101.9 ms** |
|    **100** | **10240** |   **101.5 ms** |  **0.18 ms** |  **0.17 ms** |   **101.5 ms** |
|    **100** | **20480** |   **101.6 ms** |  **0.13 ms** |  **0.11 ms** |   **101.5 ms** |
|   **1000** |  **1024** |   **100.9 ms** |  **1.84 ms** |  **2.04 ms** |   **101.6 ms** |
|   **1000** |  **2048** |   **101.6 ms** |  **0.22 ms** |  **0.20 ms** |   **101.6 ms** |
|   **1000** | **10240** |   **102.1 ms** |  **2.04 ms** |  **2.79 ms** |   **103.5 ms** |
|   **1000** | **20480** |   **108.4 ms** |  **0.25 ms** |  **0.22 ms** |   **108.4 ms** |
|  **10000** |  **1024** |   **112.2 ms** |  **2.24 ms** |  **5.86 ms** |   **111.6 ms** |
|  **10000** |  **2048** |   **117.9 ms** |  **2.35 ms** |  **5.72 ms** |   **117.0 ms** |
|  **10000** | **10240** |   **152.3 ms** |  **3.86 ms** | **11.39 ms** |   **147.2 ms** |
|  **10000** | **20480** |   **238.0 ms** |  **4.81 ms** | **14.19 ms** |   **231.9 ms** |
| **100000** |  **1024** |   **205.8 ms** |  **4.07 ms** |  **9.60 ms** |   **201.7 ms** |
| **100000** |  **2048** |   **317.1 ms** |  **6.24 ms** | **12.60 ms** |   **316.9 ms** |
| **100000** | **10240** |   **667.2 ms** | **13.13 ms** | **11.64 ms** |   **664.9 ms** |
| **100000** | **20480** | **1,184.9 ms** | **22.58 ms** | **35.15 ms** | **1,178.2 ms** |
### Random Rent And Return 1000
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1082 (1909/November2018Update/19H2)
Intel Core i5-9400F CPU 2.90GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=3.1.402
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  CoreRt 3.1 : .NET 5.0.29325.02 @BuiltBy: dlab14-DDVSOWINAGE075 @Branch: master @Commit: 64389dad34695712b2520fba2b04713c7c220d89, X64 AOT

Job=CoreRt 3.1  Runtime=CoreRt 3.1  

```
| Count | MaxCount |  Size | MaxRentSize |     Mean |     Error |    StdDev |
|------ |--------- |------ |------------ |---------:|----------:|----------:|
|    **10** |    **20000** |  **1024** |          **16** | **3.042 ms** | **0.0296 ms** | **0.0277 ms** |
|    **10** |    **20000** |  **1024** |          **32** | **3.179 ms** | **0.0178 ms** | **0.0167 ms** |
|    **10** |    **20000** |  **1024** |          **64** | **3.593 ms** | **0.0430 ms** | **0.0402 ms** |
|    **10** |    **20000** |  **1024** |         **128** | **4.189 ms** | **0.0359 ms** | **0.0336 ms** |
|    **10** |    **20000** |  **1024** |         **256** | **5.071 ms** | **0.0287 ms** | **0.0269 ms** |
|    **10** |    **20000** |  **1024** |        **1024** | **9.884 ms** | **0.0880 ms** | **0.0823 ms** |
|    **10** |    **20000** |  **2048** |          **16** | **2.960 ms** | **0.0319 ms** | **0.0298 ms** |
|    **10** |    **20000** |  **2048** |          **32** | **3.051 ms** | **0.0342 ms** | **0.0320 ms** |
|    **10** |    **20000** |  **2048** |          **64** | **3.212 ms** | **0.0474 ms** | **0.0421 ms** |
|    **10** |    **20000** |  **2048** |         **128** | **3.550 ms** | **0.0289 ms** | **0.0271 ms** |
|    **10** |    **20000** |  **2048** |         **256** | **4.396 ms** | **0.0859 ms** | **0.0882 ms** |
|    **10** |    **20000** |  **2048** |        **1024** | **7.083 ms** | **0.0762 ms** | **0.0713 ms** |
|    **10** |    **20000** | **10240** |          **16** | **2.933 ms** | **0.0340 ms** | **0.0302 ms** |
|    **10** |    **20000** | **10240** |          **32** | **2.923 ms** | **0.0246 ms** | **0.0218 ms** |
|    **10** |    **20000** | **10240** |          **64** | **2.986 ms** | **0.0578 ms** | **0.0513 ms** |
|    **10** |    **20000** | **10240** |         **128** | **3.085 ms** | **0.0488 ms** | **0.0456 ms** |
|    **10** |    **20000** | **10240** |         **256** | **3.159 ms** | **0.0277 ms** | **0.0259 ms** |
|    **10** |    **20000** | **10240** |        **1024** | **4.012 ms** | **0.0295 ms** | **0.0276 ms** |
|    **10** |    **20000** | **20480** |          **16** | **2.868 ms** | **0.0125 ms** | **0.0111 ms** |
|    **10** |    **20000** | **20480** |          **32** | **2.870 ms** | **0.0199 ms** | **0.0186 ms** |
|    **10** |    **20000** | **20480** |          **64** | **2.895 ms** | **0.0162 ms** | **0.0143 ms** |
|    **10** |    **20000** | **20480** |         **128** | **2.916 ms** | **0.0178 ms** | **0.0158 ms** |
|    **10** |    **20000** | **20480** |         **256** | **3.023 ms** | **0.0418 ms** | **0.0391 ms** |
|    **10** |    **20000** | **20480** |        **1024** | **3.392 ms** | **0.0211 ms** | **0.0197 ms** |
|   **100** |    **20000** |  **1024** |          **16** | **3.022 ms** | **0.0301 ms** | **0.0281 ms** |
|   **100** |    **20000** |  **1024** |          **32** | **3.168 ms** | **0.0153 ms** | **0.0143 ms** |
|   **100** |    **20000** |  **1024** |          **64** | **3.522 ms** | **0.0280 ms** | **0.0262 ms** |
|   **100** |    **20000** |  **1024** |         **128** | **4.159 ms** | **0.0505 ms** | **0.0472 ms** |
|   **100** |    **20000** |  **1024** |         **256** | **5.049 ms** | **0.0292 ms** | **0.0258 ms** |
|   **100** |    **20000** |  **1024** |        **1024** | **9.918 ms** | **0.0638 ms** | **0.0566 ms** |
|   **100** |    **20000** |  **2048** |          **16** | **2.939 ms** | **0.0152 ms** | **0.0143 ms** |
|   **100** |    **20000** |  **2048** |          **32** | **3.004 ms** | **0.0168 ms** | **0.0157 ms** |
|   **100** |    **20000** |  **2048** |          **64** | **3.193 ms** | **0.0306 ms** | **0.0271 ms** |
|   **100** |    **20000** |  **2048** |         **128** | **3.545 ms** | **0.0538 ms** | **0.0504 ms** |
|   **100** |    **20000** |  **2048** |         **256** | **4.268 ms** | **0.0488 ms** | **0.0457 ms** |
|   **100** |    **20000** |  **2048** |        **1024** | **7.071 ms** | **0.0831 ms** | **0.0778 ms** |
|   **100** |    **20000** | **10240** |          **16** | **2.878 ms** | **0.0096 ms** | **0.0085 ms** |
|   **100** |    **20000** | **10240** |          **32** | **2.918 ms** | **0.0238 ms** | **0.0211 ms** |
|   **100** |    **20000** | **10240** |          **64** | **2.922 ms** | **0.0182 ms** | **0.0170 ms** |
|   **100** |    **20000** | **10240** |         **128** | **2.989 ms** | **0.0215 ms** | **0.0201 ms** |
|   **100** |    **20000** | **10240** |         **256** | **3.107 ms** | **0.0199 ms** | **0.0186 ms** |
|   **100** |    **20000** | **10240** |        **1024** | **3.968 ms** | **0.0268 ms** | **0.0250 ms** |
|   **100** |    **20000** | **20480** |          **16** | **2.858 ms** | **0.0129 ms** | **0.0115 ms** |
|   **100** |    **20000** | **20480** |          **32** | **2.861 ms** | **0.0153 ms** | **0.0143 ms** |
|   **100** |    **20000** | **20480** |          **64** | **2.886 ms** | **0.0213 ms** | **0.0199 ms** |
|   **100** |    **20000** | **20480** |         **128** | **2.907 ms** | **0.0092 ms** | **0.0077 ms** |
|   **100** |    **20000** | **20480** |         **256** | **2.977 ms** | **0.0105 ms** | **0.0088 ms** |
|   **100** |    **20000** | **20480** |        **1024** | **3.394 ms** | **0.0188 ms** | **0.0167 ms** |
|  **1000** |    **20000** |  **1024** |          **16** | **3.015 ms** | **0.0176 ms** | **0.0164 ms** |
|  **1000** |    **20000** |  **1024** |          **32** | **3.180 ms** | **0.0271 ms** | **0.0241 ms** |
|  **1000** |    **20000** |  **1024** |          **64** | **3.560 ms** | **0.0483 ms** | **0.0452 ms** |
|  **1000** |    **20000** |  **1024** |         **128** | **4.228 ms** | **0.0572 ms** | **0.0535 ms** |
|  **1000** |    **20000** |  **1024** |         **256** | **5.076 ms** | **0.0489 ms** | **0.0457 ms** |
|  **1000** |    **20000** |  **1024** |        **1024** | **9.740 ms** | **0.0710 ms** | **0.0664 ms** |
|  **1000** |    **20000** |  **2048** |          **16** | **2.940 ms** | **0.0162 ms** | **0.0151 ms** |
|  **1000** |    **20000** |  **2048** |          **32** | **3.029 ms** | **0.0311 ms** | **0.0291 ms** |
|  **1000** |    **20000** |  **2048** |          **64** | **3.180 ms** | **0.0292 ms** | **0.0273 ms** |
|  **1000** |    **20000** |  **2048** |         **128** | **3.561 ms** | **0.0360 ms** | **0.0336 ms** |
|  **1000** |    **20000** |  **2048** |         **256** | **4.203 ms** | **0.0314 ms** | **0.0279 ms** |
|  **1000** |    **20000** |  **2048** |        **1024** | **6.970 ms** | **0.0685 ms** | **0.0572 ms** |
|  **1000** |    **20000** | **10240** |          **16** | **2.892 ms** | **0.0365 ms** | **0.0324 ms** |
|  **1000** |    **20000** | **10240** |          **32** | **2.911 ms** | **0.0283 ms** | **0.0265 ms** |
|  **1000** |    **20000** | **10240** |          **64** | **2.934 ms** | **0.0224 ms** | **0.0209 ms** |
|  **1000** |    **20000** | **10240** |         **128** | **3.011 ms** | **0.0457 ms** | **0.0428 ms** |
|  **1000** |    **20000** | **10240** |         **256** | **3.138 ms** | **0.0247 ms** | **0.0231 ms** |
|  **1000** |    **20000** | **10240** |        **1024** | **3.989 ms** | **0.0311 ms** | **0.0259 ms** |
|  **1000** |    **20000** | **20480** |          **16** | **2.905 ms** | **0.0265 ms** | **0.0235 ms** |
|  **1000** |    **20000** | **20480** |          **32** | **2.882 ms** | **0.0315 ms** | **0.0279 ms** |
|  **1000** |    **20000** | **20480** |          **64** | **2.919 ms** | **0.0239 ms** | **0.0224 ms** |
|  **1000** |    **20000** | **20480** |         **128** | **2.946 ms** | **0.0303 ms** | **0.0284 ms** |
|  **1000** |    **20000** | **20480** |         **256** | **3.031 ms** | **0.0274 ms** | **0.0256 ms** |
|  **1000** |    **20000** | **20480** |        **1024** | **3.477 ms** | **0.0376 ms** | **0.0333 ms** |
| **10000** |    **20000** |  **1024** |          **16** | **3.010 ms** | **0.0095 ms** | **0.0084 ms** |
| **10000** |    **20000** |  **1024** |          **32** | **3.166 ms** | **0.0140 ms** | **0.0124 ms** |
| **10000** |    **20000** |  **1024** |          **64** | **3.525 ms** | **0.0231 ms** | **0.0193 ms** |
| **10000** |    **20000** |  **1024** |         **128** | **4.239 ms** | **0.0413 ms** | **0.0386 ms** |
| **10000** |    **20000** |  **1024** |         **256** | **5.088 ms** | **0.0557 ms** | **0.0521 ms** |
| **10000** |    **20000** |  **1024** |        **1024** | **9.810 ms** | **0.1191 ms** | **0.1114 ms** |
| **10000** |    **20000** |  **2048** |          **16** | **2.998 ms** | **0.0408 ms** | **0.0362 ms** |
| **10000** |    **20000** |  **2048** |          **32** | **3.062 ms** | **0.0548 ms** | **0.0513 ms** |
| **10000** |    **20000** |  **2048** |          **64** | **3.222 ms** | **0.0295 ms** | **0.0276 ms** |
| **10000** |    **20000** |  **2048** |         **128** | **3.578 ms** | **0.0114 ms** | **0.0101 ms** |
| **10000** |    **20000** |  **2048** |         **256** | **4.207 ms** | **0.0399 ms** | **0.0373 ms** |
| **10000** |    **20000** |  **2048** |        **1024** | **7.000 ms** | **0.0540 ms** | **0.0478 ms** |
| **10000** |    **20000** | **10240** |          **16** | **2.866 ms** | **0.0150 ms** | **0.0140 ms** |
| **10000** |    **20000** | **10240** |          **32** | **2.891 ms** | **0.0149 ms** | **0.0140 ms** |
| **10000** |    **20000** | **10240** |          **64** | **2.919 ms** | **0.0161 ms** | **0.0143 ms** |
| **10000** |    **20000** | **10240** |         **128** | **2.990 ms** | **0.0104 ms** | **0.0097 ms** |
| **10000** |    **20000** | **10240** |         **256** | **3.134 ms** | **0.0163 ms** | **0.0153 ms** |
| **10000** |    **20000** | **10240** |        **1024** | **4.045 ms** | **0.0224 ms** | **0.0198 ms** |
| **10000** |    **20000** | **20480** |          **16** | **2.867 ms** | **0.0123 ms** | **0.0109 ms** |
| **10000** |    **20000** | **20480** |          **32** | **2.871 ms** | **0.0128 ms** | **0.0120 ms** |
| **10000** |    **20000** | **20480** |          **64** | **2.890 ms** | **0.0128 ms** | **0.0100 ms** |
| **10000** |    **20000** | **20480** |         **128** | **2.920 ms** | **0.0139 ms** | **0.0109 ms** |
| **10000** |    **20000** | **20480** |         **256** | **2.987 ms** | **0.0096 ms** | **0.0085 ms** |
| **10000** |    **20000** | **20480** |        **1024** | **3.461 ms** | **0.0328 ms** | **0.0306 ms** |
