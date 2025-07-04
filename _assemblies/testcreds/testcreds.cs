// Source
//     - https://stackoverflow.com/questions/8949501/why-does-active-directory-validate-last-password
//     - LDAP Result Codes - https://ldapwiki.com/wiki/LDAP%20Result%20Codes

// To Compile:
//   C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /reference:"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" /t:exe /out:.\test\testcreds.exe .\testcreds.cs

using System;
using System.Net;
using System.DirectoryServices.Protocols;

class TestCreds {
    public static void PrintUsage() {
        Console.WriteLine(@"Given an Active Directory domain, username, and password, returns whether the credentials are valid. Can optionally specify a specific server with '/S'. Does not work on local accounts.

USAGE:
    test_ad_creds.exe [/S <server>] <domain> <username> <password>");
        Console.WriteLine("\nDONE");
    }
    
    private const int ERROR_LOGON_FAILURE = 0x31;

    public static void Main(string[] args) {
        string domain = "";
        string username = "";
        string password = "";
        string server = "";
        string arg;
        int argCount = 0;
        
        // Parse arguments
        for (int i = 0; i < args.Length; i++) {
            arg = args[i];
            
            switch (arg.ToUpper()) {
                case "/?":
                    PrintUsage();
                    return;
                case "-S":
                case "/S":
                    i++;
                    server = args[i];
                    break;
                default:
                    // Handle positional arguments
                    switch(argCount) {
                        case 0:
                            domain = arg;
                            break;
                        case 1:
                            username = arg;
                            break;
                        case 2:
                            password = arg;
                            break;
                    }
                    argCount++;
                    break;
            }
        }
        
        // Print help and abort if domain, username, or password are missing
        if (string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
            PrintUsage();
            return;
        }
        
        // Use the domain as the server if one is not specified
        if (string.IsNullOrEmpty(server)) {
            server = domain;
        }
        
        NetworkCredential credentials = new NetworkCredential(username, password, domain);
        LdapDirectoryIdentifier id = new LdapDirectoryIdentifier(server);
        
        // Automatically negotiates the best authentication type
        using (LdapConnection connection = new LdapConnection(id, credentials)) {
            try {
                connection.Bind();
            } catch (LdapException lEx) {
                if (lEx.ErrorCode == ERROR_LOGON_FAILURE) {
                    Console.WriteLine("Invalid");
                    Console.WriteLine("\nDONE");
                    return;
                }
                
                Console.WriteLine("[-] LDAP Error (" + lEx.ErrorCode.ToString("X") + "): " + lEx.Message);
                Console.WriteLine("\nDONE");
                return;
            }
        }
        
        Console.WriteLine("Valid");
        Console.WriteLine("\nDONE");
        return;
    }
}