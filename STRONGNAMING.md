# The Plivo-dotnet SDK assemblies are NOT Strong Named.

For the most part, the majority of applications and libraries do not need strong-names. 

Strong-names are left over from previous eras of .NET where sandboxing needed to differentiate between code that was trusted, 
versus code that was untrusted. However in recent years, sandboxing via AppDomains, especially to [isolate ASP.NET web applications] 
(http://support.microsoft.com/kb/2698981), is no longer guaranteed and is not recommended.

However, strong-names are still required in some situations.
https://docs.microsoft.com/en-us/dotnet/framework/app-domains/strong-named-assemblies

## Running multiple versions of the Plivo SDK

If you need to run multiple versions of the Plivo SDK you will need to Strong Name the Plivo SDK Assemblies.
This is a very rare edge case!  You should only need to reference multiple versions of the Plivo SDK if you are trying to upgrade to a new version and
have not yet completed the upgrade, so you need to span multiplt versions for awhile.  This scenario is not recommended!  You should upgrade and only use one version of the SDK at a time.

When you reference a strong-named assembly, you can expect certain benefits, such as versioning and naming protection. 
Strong-named assemblies can be installed in the Global Assembly Cache, which is required to enable some scenarios.

### Strong-named assemblies are useful in the following scenarios:

You want to enable your assemblies to be referenced by strong-named assemblies, or you want to give friend access to your 
assemblies from other strong-named assemblies.

An app needs access to different versions of the same assembly. This means you need different versions of an assembly to load 
side by side in the same app domain without conflict. For example, if different extensions of an API exist in assemblies that 
have the same simple name, strong-naming provides a unique identity for each version of the assembly.

You do not want to negatively affect performance of apps using your assembly, so you want the assembly to be domain neutral. 
This requires strong-naming because a domain-neutral assembly must be installed in the global assembly cache.

When you want to centralize servicing for your app by applying publisher policy, which means the assembly must be 
installed in the global assembly cache.

### How to: Sign an Assembly with a Strong Name

https://docs.microsoft.com/en-us/dotnet/framework/app-domains/how-to-sign-an-assembly-with-a-strong-name

### How to: Create and Use Strong Named Assemblies

https://docs.microsoft.com/en-us/dotnet/framework/app-domains/create-and-use-strong-named-assemblies

### Plivo SDK Strong Naming

Download the (source control) version of the Plivo-dotnet SDK that you want to strong name.
https://github.com/plivo/plivo-dotnet/releases

Open the code in Visual Studio 2017.  

Right click on the Plivo Project, choose Properties.
Click on the Signing tab, then select the checkbox "Sign the Assembly"

Under choose a strong name keyfile, choose <New>, Create a snk file by entering a name and password in the Create Strong Name Key dialog.

Uncheck the Delay sign Only checkbox!

#### Click Save and then Choose Build -> Build Solution.  The Pivo.dll assembly is now Strong-named.  

	C:\Users\Test\Documents\plivo-dotnet\src\Plivo\bin\Debug\netstandard2.0>sn -v Plivo.dll

	Microsoft (R) .NET Framework Strong Name Utility  Version 4.0.30319.0
	Copyright (c) Microsoft Corporation.  All rights reserved.

	Assembly 'Plivo.dll' is valid

#### Installing the Plivo SDK in the Global Assembly Cache 

	C:\Users\Test\Documents\plivo-dotnet\src\Plivo\bin\Debug\netstandard2.0>gacutil -i Plivo.dll
	Microsoft (R) .NET Global Assembly Cache Utility.  Version 4.0.30319.0
	Copyright (c) Microsoft Corporation.  All rights reserved.

	Assembly successfully added to the cache

	The Assembly is now in your Global Assembly Cache:

	(Example location on my machine)
	C:\Windows\Microsoft.NET\assembly\GAC_MSIL\Plivo\v4.0_1.0.0.0__9afe2f9ee267c412

This version of the Plivo dotnet SDK is now installed in your GAC and can be referenced by your project.
You can now download or use NuGet to download an additional version of the SDK and follow these instructions to strong name and install the new version.

Once both versions are strong named and installed in the GAC, you can reference both versions at the same time.

See this link for more info on Side by Side execution.

https://docs.microsoft.com/en-us/dotnet/framework/deployment/side-by-side-execution
