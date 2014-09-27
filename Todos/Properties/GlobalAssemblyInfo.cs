using System;
using System.Reflection;

[assembly: AssemblyCompany("Talento90")]
[assembly: AssemblyProduct("Todos")]
[assembly: AssemblyCopyright("Copyright © Talento90 2014")]
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/Talento90/Todos")]
[assembly: AssemblyMetadata("Authors", "Marco Talento")]
[assembly: AssemblyMetadata("Tags", "Task manager")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion(Todos.Info.VersionDescriptor)]
[assembly: AssemblyInformationalVersion(Todos.Info.VersionDescriptor)]


namespace Todos
{

    // Version information for an assembly consists of the following four values:
    //
    //      Major Version
    //      Minor Version 
    //      Build Number
    //      Revision

    internal static class Info
    {
        public const string VersionDescriptor = "1.0.0";
        public static Version Version = Assembly.GetExecutingAssembly().GetName().Version;
    }
}

