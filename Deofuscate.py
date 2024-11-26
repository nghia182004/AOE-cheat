obfuscation_dict = {
    "hx": ["A", "Q"],  # Ambiguous mapping: hx could mean A or Q
    "*_": "B",
    "3C": "C",
    "?>": "D",
    "Am": "E",
    "Jm": "F",
    "1Z": "G",
    "@)": "H",
    "#L": "I",
    "}{": "J",
    "cW": "K",
    "+!": "L",
    "%c": "M",
    "dW": "N",
    "%^": "O",
    "w>": "P",
    "%%": "R",
    "1$": "S",
    " ^": "T",
    "_j": "U",
    "&T": "V",
    "43": "W",
    ")(": "X",
    "::": "Y",
    "S?": "Z",
    "=": "=",
    " ": " "
}

def resolve_ambiguity(ambiguous_pair, context):
    """
    Resolve ambiguous mappings based on context.
    """

    if ambiguous_pair == "hx":
        if "%%" in context:
            return "Q"
        else:
            return "A"
    return None

def deobfuscate_string(obfuscated_string):
    """
    Deobfuscate a string by checking pairs of characters in the dictionary.
    If a pair doesn’t match, treat it as a space.
    """
    deobfuscated_result = ""
    i = 0

    while i < len(obfuscated_string):

        current_pair = obfuscated_string[i:i+2]

        if current_pair in obfuscation_dict:

            if isinstance(obfuscation_dict[current_pair], list):

                resolved_char = resolve_ambiguity(current_pair, deobfuscated_result)
                if resolved_char:
                    deobfuscated_result += resolved_char
                else:
                    deobfuscated_result += "?"
            else:

                deobfuscated_result += obfuscation_dict[current_pair]
            i += 2
        else:
            deobfuscated_result += current_pair[0]
            i += 1

    return deobfuscated_result

def main():

    print('''
██████╗ ███████╗ ██████╗ ██████╗ ███████╗██╗   ██╗███████╗ ██████╗ █████╗ ████████╗███████╗     █████╗  ██████╗ ███████╗██████╗ 
██╔══██╗██╔════╝██╔═══██╗██╔══██╗██╔════╝██║   ██║██╔════╝██╔════╝██╔══██╗╚══██╔══╝██╔════╝    ██╔══██╗██╔═══██╗██╔════╝╚════██╗
██║  ██║█████╗  ██║   ██║██████╔╝█████╗  ██║   ██║███████╗██║     ███████║   ██║   █████╗      ███████║██║   ██║█████╗   █████╔╝
██║  ██║██╔══╝  ██║   ██║██╔══██╗██╔══╝  ██║   ██║╚════██║██║     ██╔══██║   ██║   ██╔══╝      ██╔══██║██║   ██║██╔══╝  ██╔═══╝ 
██████╔╝███████╗╚██████╔╝██████╔╝██║     ╚██████╔╝███████║╚██████╗██║  ██║   ██║   ███████╗    ██║  ██║╚██████╔╝███████╗███████╗
╚═════╝ ╚══════╝ ╚═════╝ ╚═════╝ ╚═╝      ╚═════╝ ╚══════╝ ╚═════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝    ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝
\033[32mAuthor: Kiendt19\033[0m\n--------------------------------------------------------------------------------------------------------------------------------                                                                                                                         
    ''')
    cheats = [
        "dW%^ Jm%^1Z",
        "%%Am&TAmhx+! %chxw>",
        "1$ ^Am%%%^#L?>1$",
        "hx_jhx%%%%::",
        "43%^%^?>1$ ^%^3CcW",
        "3C%^#LdWhx1ZAm",
        "w>Amw>w>Am%%%^dW#L w>#LS?S?hx",
        "1Zhx#Lhx",
        "%%Am1$#L1ZdW",
        "@)hx%%#L cWhx%%#L",
        "?>#LAm?>#LAm?>#LAm",
        "#L3C*_%c",
        "%cAm?>_j1$hx",
        "*_+!hx3CcW %%#L?>Am%%",
        "?>hx%%cW %%hx#LdW",
        "@)%^::%^@)%^::%^",
        "_jw>1$#L?>Jm+!#LdW ^%c%^*_#L+!Am",
        "Jm+!::#LdW1Z ?>_j ^3C@)%chxdW",
        "*_#L1Z *_Am%% ^@)hx",
        "}{hx3CcW *_Am dW#L%c*_+!Am",
        "Am=%c3C2  ^%%%^%^w>Am%%",
        "w>@)%^ ^%^dW %chxdW",
        "@)%^%cAm %%_jdW",
        "KING ARTHUR",
        "GRANTLINKSPENCE",
        "BIG MOMMA",
        "CONVERT THIS!",
        "STORMBILLY"
    ]
    i = "+"
    input("\033[31m[!] Press anything to display the cheat..........................\033[0m")
    for cheat in cheats:
        result = deobfuscate_string(cheat)
        if result == "AUARRY":
            print(f"[{i}]   Deofuscating of \033[31m{cheat} .....\033[0m")
            print(f"[Inf] Result: \033[32mQUARRY\033[0m\n")
            print("============================================\n")
        else:
            print(f"[{i}]   Deofuscating of \033[31m{cheat}.....\033[0m")
            print(f"[Inf] Result: \033[32m{result}\033[0m\n")
            print("============================================\n")


if __name__ == '__main__':
    main()
