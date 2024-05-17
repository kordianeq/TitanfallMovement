using System.Runtime.CompilerServices;

#if DISTRIBUTE_ASSEMBLIES
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("Visual Scripting Core (Runtime)")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Unity")]
[assembly: AssemblyProduct("Visual Scripting")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("0fe89c0a-b748-486b-aedc-1aadb2d1fc31")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
#endif

[assembly: InternalsVisibleTo("Unity.VisualScripting.Core.Editor")]
[assembly: InternalsVisibleTo("Unity.VisualScripting.Flow.Editor")]
[assembly: InternalsVisibleTo("Unity.VisualScripting.Flow")]
[assembly: InternalsVisibleTo("Unity.VisualScripting.State.Editor")]
[assembly: InternalsVisibleTo("Unity.VisualScripting.State")]
[assembly: InternalsVisibleTo("Unity.VisualScripting.SettingsProvider.Editor")]
[assembly: InternalsVisibleTo("Unity.VisualScripting.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.VisualScripting.Tests")]

