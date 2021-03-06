// CppWraper.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <thread>
#include <future>

#import "..//..//ClassLibWinForms//ClassLibWinForms//bin//Debug//ClassLibWinForms.tlb" raw_interfaces_only

using namespace ClassLibWinForms;

typedef  void(__stdcall *action1)(int, int);
void __stdcall  action11(int a, int b)//receive from dotnet (call from dotnet)
{
	std::cout << "x=" << a << " y=" << b << std::endl;
}

typedef  int(__stdcall *function1)();
int __stdcall  function11() //send to dotnet (call from dotnet)
{
	return 42;
}

int main()
{
	action1 act = action11;
	function1 func = function11;

	// Initialize COM.
	HRESULT hr = CoInitialize(NULL);

	// Create the interface pointer.
	IWindowAppPtr pIWindowApp(__uuidof(ManagedClass));

	

	// Call the run method.

	//simple call
	//pIWindowApp->Run((long)act, (long)func);

	//async call #1
	std::thread t([pIWindowApp, act, func]() {pIWindowApp->Run((long)act, (long)func); });

	//async call #2
	//std::future<int> fut = std::async([pIWindowApp, act, func]() 
	//{
	//	pIWindowApp->Run((long)act, (long)func); 
	//	return 1;
	//});
	//int i = fut.get();	
	
	long lResult = 0;
	long j = 0;
	while (true) 
	{
		Sleep(3000);
		pIWindowApp->ChangeValue(j); //change value at c# lib windows form (call from native)
		pIWindowApp->GetValue(&lResult);//get value from c# lib windows form (call from native)
		std::cout << "Value from C# lib windows form = " << lResult << std::endl;
		j++;
	};

	// Uninitialize COM.
	CoUninitialize();
	return 0;
}

