# NativeAppDotNetLib

Example of interaction native application with dotnet dll.

ClassLibWinForms - C# dll project with winForms

CppWrapper - executable project  

Short instruction:
  1. Write a Managed DLL.
      a. From Dveloper Command Promt in solution folder run *sn.exe -k MyKeyFile.SNK*.
      
      b. Replace the following lines of code in the AssemblyInfo.cs file  
          `[assembly: ComVisible(false)]`    
          `[assembly: AssemblyDelaySign(false)]`  
          `[assembly: AssemblyKeyFile("")]`    
         with the following.  
          `[assembly: ComVisible(true)]`   
          `[assembly: AssemblyDelaySign(false)]`   
          `[assembly: AssemblyKeyFile("..\\..\\MyKeyFile.SNK")]`  
  
  2. Register the Managed DLL for Use with COM or with Native C++.
      From Dveloper Command Promt in folder with .dll file run *RegAsm.exe ClassLibWinForms.dll /tlb:ClassLibWinForms.tlb /codebase*
  3. Call the Managed DLL from Native C++ Code.
  
  See for help: https://support.microsoft.com/en-us/help/828736/how-to-call-a-managed-dll-from-native-visual-c-code-in-visual-studio-n 

## 4 type interactions:
### 1. Sending data from dll windows form to native application. 
### 2. Dll windows form call data from native application.
### 3. Sending data from native application to dll windows form.
### 4. Native application call data from dll windows form.
