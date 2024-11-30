#include <windows.h>
#include <memory.h>


BOOL toggle = FALSE;
float resource_boost = 1000.0f;


struct map {
    byte reveal_map;                            // Reveal Map
    byte no_fog;                                // No fog
};


struct resource {                               // Struct for resource hack
    float food;
    float wood;
    float gold;
    float stone;
};


struct population {                            // Struct for population hack
    float population;
};


struct memory_ptr {
    DWORD base_address;
    int total_offset;
    int offsets[];
};


struct memory_ptr resource_hack_ptr = {
    0x00188144,
    6,
    {0x110, 0x224, 0xc, 0x40, 0x14, 0x500}    // Offset to get at food resource
};


struct map* map_hack;                         // Pointer to map hack struct
struct resource* resource_hack;               // Pointer to resource hack struct


// Function to get the base address of the module
HMODULE getBaseAddress() {
    return GetModuleHandle(NULL);
}


DWORD* trace_pointer(struct memory_ptr* hack) {
    // Start from the base address of the module
    DWORD* address = (DWORD*)((DWORD)getBaseAddress() + hack->base_address);

    // Loop through each offset to trace the pointer
    for (int i = 0; i < hack->total_offset; i++) {
        DWORD temp;
        // Update the address to the new address with the offset applied
        address = (DWORD*)(temp + hack->offsets[i]);
    }

    return address;
}


void initialize_hacks() {
    // Allocate memory for hacks
    map_hack = (struct map*)malloc(sizeof(struct map));
    resource_hack = (struct resource*)malloc(sizeof(struct resource));

    if (map_hack == NULL || resource_hack == NULL) {
        MessageBoxA(NULL, "Memory allocation failed for hacks.", "Error", MB_OK | MB_ICONERROR);
        return;
    }

    // Trace the resource hack pointer
    DWORD* resource_address = trace_pointer(&resource_hack_ptr);
    if (resource_address) {
        // Set resource hack pointer to the correct address
        resource_hack = (struct resource*)resource_address;

        // For debugging, show message box to confirm the address is valid
        MessageBoxA(NULL, "Resource hack pointer successfully traced.", "Success", MB_OK | MB_ICONINFORMATION);
    }
    else {
        MessageBoxA(NULL, "Failed to trace resource hack pointer.", "Error", MB_OK | MB_ICONERROR);
    }
}



void update_resources() {
    if (resource_hack) {
        resource_hack->food = resource_boost;
        resource_hack->wood = resource_boost;
        resource_hack->gold = resource_boost;
        resource_hack->stone = resource_boost;

        // Show MessageBox with updated resources for debugging
        char msg[256];
        snprintf(msg, sizeof(msg), "Food: %.2f, Wood: %.2f, Gold: %.2f, Stone: %.2f",
            resource_hack->food, resource_hack->wood, resource_hack->gold, resource_hack->stone);
        MessageBoxA(NULL, msg, "Resource Hack Applied", MB_OK | MB_ICONINFORMATION);
    }
}
