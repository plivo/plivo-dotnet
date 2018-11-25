# The Plivo-dotnet SDK assemblies are NOT Strong Named.

For the most part, the majority of applications and libraries do not need strong-names. 

Strong-names are left over from previous eras of .NET where sandboxing needed to differentiate between code that was trusted, 
versus code that was untrusted. However in recent years, sandboxing via AppDomains, especially to [isolate ASP.NET web applications] 
(http://support.microsoft.com/kb/2698981), is no longer guaranteed and is not recommended.

However, strong-names are still required in some situations.
https://docs.microsoft.com/en-us/dotnet/framework/app-domains/strong-named-assemblies

## Running multiple versions of the Plivo SDK

If you need to run multiple versions of the Plivo SDK you will need to Strong Name the Plivo SDK Assemblies.

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

### How to Strong-Name the Plivo-dotnet SDK


