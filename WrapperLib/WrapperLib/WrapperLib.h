#pragma once
#define DllExport extern "C" __declspec(dllexport)
DllExport int __cdecl Run();