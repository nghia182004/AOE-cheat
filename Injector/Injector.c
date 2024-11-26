#include <Windows.h>
#include <stdio.h>
#include <TlHelp32.h>

// Set the console text color
void SetConsoleColor(WORD color) {
    HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleTextAttribute(hConsole, color);
}

// Get Process ID by name
int getProcId(const wchar_t* process) {
    DWORD PID = 0;
    PROCESSENTRY32 pe32;
    pe32.dwSize = sizeof(PROCESSENTRY32);
    HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

    if (Process32First(hSnapshot, &pe32)) {
        do {
            if (wcscmp(pe32.szExeFile, process) == 0) {
                PID = pe32.th32ProcessID;
                break;
            }
        } while (Process32Next(hSnapshot, &pe32));
    }
    else {
        printf("[!!] Failed to retrieve processes, error: 0x%lx\n", GetLastError());
    }

    CloseHandle(hSnapshot);
    return PID;
}

// Inject DLL into target process
int RemoteProcessInjector() {
    // Target Process Name to inject 
    const wchar_t* process = L"Empiresx.exe";
    SIZE_T bytesWritten = 0;
    HANDLE hProcess = NULL, hThread = NULL;
    LPVOID remoteBuffer = NULL;
    HMODULE hKernel32 = GetModuleHandleW(L"kernel32");
    DWORD PID = getProcId(process);

    // DLL path
    wchar_t dllName[] = L"cheat-32bit.dll";
    wchar_t dllPath[MAX_PATH] = { 0 };
    wchar_t exePath[MAX_PATH] = { 0 };

    // Get the path of the current executable
    if (GetModuleFileNameW(NULL, exePath, MAX_PATH) == 0) {
        printf("[!!] Failed to get module file name, error: 0x%lx\n", GetLastError());
        return 1;
    }

    // Remove the executable name from the path
    wchar_t* lastSlash = wcsrchr(exePath, L'\\');
    if (lastSlash) {
        *(lastSlash + 1) = L'\0'; // Null-terminate the string after the last slash
    }
    else {
        printf("[!!] Failed to parse executable path.\n");
        return 1;
    }

    // Append the DLL name to the path
    wcscat_s(exePath, MAX_PATH, dllName);
    wcscpy_s(dllPath, MAX_PATH, exePath); 

    // Output the DLL path
    wprintf(L"[+] Full DLL Path: %ls\n", dllPath);


    if (PID == 0) {
        printf("[!!] Process not found: %ls\n", process);
        return EXIT_FAILURE;
    }

    printf("[+] Found Process %ls (PID: %ld)\n", process, PID);


    // Open process -> return Handle to process 
    hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, PID);
    if (!hProcess) {
        printf("[!!] Failed to open process, error: 0x%lx\n", GetLastError());
        return EXIT_FAILURE;
    }

    
    // Allocate memory in remote process -> return base address of alocated memory region
    remoteBuffer = VirtualAllocEx(hProcess, NULL, sizeof(dllPath), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
    if (!remoteBuffer) {
        printf("[!!] Failed to allocate memory, error: 0x%lx\n", GetLastError());
        CloseHandle(hProcess);
        return EXIT_FAILURE;
    }


    // Write DLL path into remote process memory -> Write Allocated memory to another process memory  
    if (!WriteProcessMemory(hProcess, remoteBuffer, dllPath, sizeof(dllPath), &bytesWritten)) {
        printf("[!!] Failed to write to process memory, error: 0x%lx\n", GetLastError());
        goto CLEANUP;
    }


    // Get address of LoadLibraryW
    LPTHREAD_START_ROUTINE kawLoadLibrary = (LPTHREAD_START_ROUTINE)GetProcAddress(hKernel32, "LoadLibraryW");
    if (!kawLoadLibrary) {
        printf("[!!] Failed to get address of LoadLibraryW, error: 0x%lx\n", GetLastError());
        goto CLEANUP;
    }

    DWORD threadId = 0;
    // Create remote thread to load DLL
    hThread = CreateRemoteThread(hProcess, NULL, 0, kawLoadLibrary, remoteBuffer, 0, &threadId);
    printf("[+] Remote thread created successfully with Thread ID: %lu\n", threadId);
    if (!hThread) {
        printf("[!!] Failed to create remote thread, error: 0x%lx\n", GetLastError());
        goto CLEANUP;
    }

    WaitForSingleObject(hThread, INFINITE);
    printf("[+] DLL injected successfully.\n");


CLEANUP:
    if (hThread) CloseHandle(hThread);
    if (hProcess) CloseHandle(hProcess);
    if (remoteBuffer) VirtualFreeEx(hProcess, remoteBuffer, 0, MEM_RELEASE);

    return EXIT_SUCCESS;
}

void banner() {
    printf(
        "====================================================================\n"
        "     ______                               __                       \n"
        "    /\\__  _\\            __               /\\ \\__                    \n"
        "    \\/_/\\ \\/     ___   /\\_\\     __    ___\\ \\ ,_\\   ___   _ __      \n"
        "       \\ \\ \\   /' _ `\\ \\/\\ \\  /'__`\\ /'___\\ \\ \\/  / __`\\/\\`'__\\   \n"
        "        \\_\\ \\__/\\ \\/\\ \\ \\ \\ \\/\\  __//\\ \\__/\\ \\ \\_/\\ \\L\\ \\ \\ \\/    \n"
        "        /\\_____\\ \\_\\ \\_\\_\\ \\ \\ \\____\\ \\____\\\\ \\__\\ \\____/\\ \\_\\   \n"
        "        \\/_____/\\/_/\\/_/\\ \\_\\ \\/____/\\/____/ \\/__/\\/___/  \\/_/   \n"
        "                       \\ \\____/                                   \n"
        "                        \\/___/                                    \n"
        "====================================================================\n"
        "Author: Kiendt19\n"
        "====================================================================\n");
        printf("[!!] REMEMBER TO START THE GAME, START IT NOW THEN PROCEED\n");
        printf("[+] Press <ENTER> to start");
        getchar();
}



int main(int argc, char* argv[]) {
    SetConsoleColor(FOREGROUND_GREEN | FOREGROUND_INTENSITY);
    banner();
    SetConsoleColor(FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
    RemoteProcessInjector();
    printf("[+] Injection complete. Press <Enter> to quit...");
    getchar();
    return 0;
}
