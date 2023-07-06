// using System.Reflection;
// using AutoMapper;
// using Microsoft.Extensions.DependencyModel;

// namespace DigitDuel.API.Configurations;

// public static class AutoMapperConfiguration
// {
//   private static void AddAutoMapperClasses(IServiceCollection services, IEnumerable<Assembly> assembliesToScan)
//   {
//     assembliesToScan = assembliesToScan as Assembly[] ?? assembliesToScan.ToArray();

//     var allTypes = assembliesToScan.SelectMany(a => a.ExportedTypes).ToArray();

//     var profiles =
//     allTypes
//         .Where(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo()))
//         .Where(t => !t.GetTypeInfo().IsAbstract);

//     Mapper.Initialize(cfg =>
//     {
//       foreach (var profile in profiles)
//       {
//         cfg.AddProfile(profile);
//       }
//     });
//   }

//   public static void AddAutoMapper(this IServiceCollection services)
//   {
//     services.AddAutoMapper(DependencyContext.Default);
//   }

//   public static void AddAutoMapper(this IServiceCollection services, DependencyContext dependencyContext)
//   {
//     services.AddAutoMapper(dependencyContext.RuntimeLibraries
//         .SelectMany(lib => lib.GetDefaultAssemblyNames(dependencyContext).Select(Assembly.Load)));
//   }
// }