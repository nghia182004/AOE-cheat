#include <Windows.h>

void protected_read(void* dest, void* src, int n) {
	DWORD oldProtect = 0; 
	VirtualProtect(dest, n, PAGE_EXECUTE_READWRITE, &oldProtect); 
	memcpy(dest, src, n);
	VirtualProtect(dest, n, oldProtect, &oldProtect); 
}

void readBytes(void* read_address, void* read_buffer, int len) {
	protected_read(read_buffer, read_address, len); 
}

void writeBytes(void* dest, void* patch, int len) {
	protected_read(dest, patch, len); 
}
