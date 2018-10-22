#pragma hdrstop
#pragma argsused

#ifdef _WIN32
#include <tchar.h>
#else
  typedef char _TCHAR;
  #define _tmain main
#endif


#include <System.Classes.hpp>
#include <iostream>

typedef int __cdecl (*IntReturnFunc)();

const wchar_t* library = L"..\\..\\..\\WrapperLib\\Debug\\WrapperLib.dll";

extern "C" __declspec(dllimport) int __cdecl Run();

int _tmain(int argc, _TCHAR* argv[])
{
	 char lib[100];
	 size_t len = wcstombs(lib, library, wcslen(library));
	 if(len > 0u)
		lib[len] = '\0';

	 HINSTANCE load = LoadLibrary(lib);

	 if (load)
	 {
		std::cout<<"Library loaded" << std::endl;
		IntReturnFunc func = (IntReturnFunc)GetProcAddress(load,"Run");

		if(func)
		{
			std::cout<<func()<<std::endl;
		}
		else
		{
			std::cout<<"Imposible find function"<<std::endl;
		}

		FreeLibrary(load);
	 }

	return 0;
}

