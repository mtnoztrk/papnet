# PapNet
Helper library for sending tracking requests to Post Affiliate Pro server.

# Motivation
WIP
# Installation
Available on [NuGet](https://www.nuget.org/packages/PapNet)

	PM> Install-Package PapNet

`Startup.cs`
```csharp
using PapNet;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) 
    {
        ...
        services.AddPapService(Configuration);
        ...
    }
}
```
# Important Notes

WIP


# Usage
WIP
# License
MIT License

Copyright (c) 2024 Metin ÖZTÜRK

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.