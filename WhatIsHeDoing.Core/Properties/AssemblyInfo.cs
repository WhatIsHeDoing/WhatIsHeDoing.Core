using System;
using System.Reflection;
using System.Resources;

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyDescription
    ("A library of extensions of .Net core functionality.")]

[assembly: AssemblyProduct("WhatIsHeDoing.Core")]
[assembly: AssemblyTitle("WhatIsHeDoing.Core")]
[assembly: AssemblyVersion("0.1.0")]
[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguage("en")]
