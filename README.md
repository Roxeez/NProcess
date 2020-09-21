# NProcess
![AppVeyor](https://img.shields.io/appveyor/build/Roxeez/NProcess)  

NProcess is a .NET library used to easily interact with local or remote processes.

## Features

Since NProcess is still in development, much features will be added later

* Memory reading/writting
* Pattern scanning

## Installation

Using Package Manager
```sh
Install-Package NProcess -Version 1.0.0
```

Using .NET CLI
```sh
dotnet add package NProcess -Version 1.0.0
```

Using Package Reference
```xml
<PackageReference Include="NProcess" Version="1.0.0" />
```

## Example
#### IProcess object creation
Local process
```csharp
var process = new LocalProcess();
```
Remote process
```csharp
Process original = Process.GetProcessesByName("MySuperProcess").FirstOrDefault();
if (original == null)
{
    Console.WriteLine("Can't found process");
    return;
}

var process = new RemoteProcess(original);
```
#### Working with IProcess object

##### Pattern
Find a pattern in process main module
```csharp
IntPtr address = process.FindPattern("A1 B8 58 D4 ?? ?? ?? ?? E4 85");
```
Find a pattern in selected process module
```csharp
IntPtr address = process["MySuperModuleName"].FindPattern("A1 B8 58 D4 ?? ?? ?? ?? E4 85");
```
Find a pattern and automatically add offset to it
```csharp
IntPtr address = process.FindPattern("A1 B8 58 D4 ?? ?? ?? ?? E4 85", 4);
```  

##### Memory reading
Read from address without offsets
```csharp
string value = process.Memory.Read<string>(new IntPtr(0x458732));
```
Read from address with offsets
```csharp
int value = process.Memory.Read<int>(new IntPtr(0x458732), 0xC4, 0x4C);
```  

##### Memory writing
Write to address without offsets
```csharp
process.Memory.Write<int>(24, new IntPtr(0x458732));
```
Write to address with offsets
```csharp
process.Memory.Write<string>("My super string", new IntPtr(0x458732), 0xC4, 0x4C);
```  

### Todos
 - Detour
 - Window interaction
 - Keyboard interaction
