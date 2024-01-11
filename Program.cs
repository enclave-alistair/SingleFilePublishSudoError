using System.Runtime.InteropServices;

var libSodiumVersion = GetSodiumVersion();

// See https://aka.ms/new-console-template for more information
Console.WriteLine($"Loaded libsodium: {libSodiumVersion}");

[DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
[DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
static extern IntPtr sodium_version_string();

static string GetSodiumVersion()
{
    var marshalledString = Marshal.PtrToStringAnsi(sodium_version_string());

    if (marshalledString is null)
    {
        throw new InvalidOperationException("Cannot retrieve libsodium version");
    }

    return marshalledString;
}