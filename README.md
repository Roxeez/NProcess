# NProcess
![AppVeyor](https://img.shields.io/appveyor/build/Roxeez/NProcess)  

NProcess is a .NET library used to easily interact with local or remote processes.

## Features

Since NProcess is still in development, much features will be added later

* Memory reading/writting
* Pattern scanning
* Window/Keyboard/Mouse interaction

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
**Read/Write remote process memory using static address and offsets**
```csharp
public static void Main(string[] args)
{
    // Find our target process
    Process source = Process.GetProcessesByName("NostaleClientX").FirstOrDefault();
    if (source == null)
    {
        return;
    }

    // Create new RemoteProcess instance to interact with previously found process
    using (var process = new RemoteProcess(source))
    {
        // Get process main module
        IModule module = process.MainModule;
        
        // Get pointers using static address and offsets
        IntPtr hpPointer = module.GetPointer(new IntPtr(0x895898), 0xC4, 0x4C);
        
        // Read value from pointer
        int hp = module.ReadMemory<int>(hpPointer);

        // Write value to pointer
        module.WriteMemory<int>(hpPointer, 2500);
    }
}
```

**Read/Write local process memory using pattern and offsets**
```csharp
public static void Main(string[] args)
{
    // Create new LocalProcess to interact with our process (used if you dll is injected into process)
    using (var process = new LocalProcess())
    {
        // Get process main module
        IModule module = process.MainModule;
        
        // Get pointer using pattern and offsets
        IntPtr mpPointer = module.GetPointer(new Pattern("8D 55 E0 A1 ?? ?? ?? ?? 8B 00 8B 80", 4), 0xC8, 0x4C);
        
        // Read value from pointer
        int mp = module.ReadMemory<int>(mpPointer);

        // Write value to pointer
        module.WriteMemory<int>(mpPointer, 2500);
    }
}
```

**Interact with window/keyboard/mouse**
```csharp
public static void Main(string[] args)
{
    // Find our target process
    Process source = Process.GetProcessesByName("NostaleClientX").FirstOrDefault();
    if (source == null)
    {
        return;
    }

    using (IProcess process = new RemoteProcess(source))
    {
        // Get window using window name
        IWindow window = process.GetWindow("NosTale");
        if (window == null)
        {
            return;
        }
        
        // Change window title
        window.Title = "NProcess";
        
        // Press enter key and release it directly
        window.Keyboard.Press(Key.Enter);
        
        // Hold A key pressed for 3 seconds
        window.Keyboard.Hold(Key.A, TimeSpan.FromSeconds(3));
        
        // Click using left button at 200/200 position in window
        window.Mouse.LeftClick(200, 200);
    }
}
```
