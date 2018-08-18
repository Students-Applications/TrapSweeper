using Autofac;
using System.Linq;

namespace SN.App.Emulator.Console
{
	internal static class ContainerConfig
	{
		static ContainerConfig()
		{
		}

		public static Autofac.IContainer Configure()
		{
			var builder =
				new Autofac.ContainerBuilder();

			//// Make sure process paths are sane...
			//System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);

			////  begin setup of autofac >>

			//// 1. Scan for assemblies containing dlls that implement IMazeIntegration in the bin folder
			//var assemblies =
			//	new System.Collections.Generic.List<System.Reflection.Assembly>();

			//assemblies.AddRange(
			//	System.IO.Directory.EnumerateFiles
			//	(System.IO.Directory.GetCurrentDirectory(), "*.dll", System.IO.SearchOption.AllDirectories)
			//	.Select(System.Reflection.Assembly.LoadFrom)
			//);

			////TODO
			//// Fix to handle multiple implementations/Load one implementation
			//foreach (var assembly in assemblies)
			//{
			//	builder.RegisterAssemblyTypes(assembly)
			//		.Where(t => t.GetInterfaces()
			//			.Any(i => i.IsAssignableFrom(typeof(Integration.Maze.IMazeIntegration))))
			//		.AsImplementedInterfaces()
			//		.InstancePerRequest();
			//}

			try
			{
				string path =
					System.AppDomain.CurrentDomain.BaseDirectory;

				string pathName =
					$"{ path }SahelMazeGame.dll";

				if (System.IO.File.Exists(pathName) == false)
				{
					System.Console.WriteLine("The [SahelMazeGame.dll] Does Not Exist!");
				}
				else
				{
					System.Reflection.Assembly assembly =
						System.Reflection.Assembly.LoadFile(path: pathName);

					//builder.RegisterAssemblyTypes(assembly)
					//.AsImplementedInterfaces()
					//.InstancePerRequest();

					builder.RegisterAssemblyTypes(assembly)
					.AsImplementedInterfaces();
				}
			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}

			builder.RegisterType<ASCIIConsole>().As<Integration.Maze.IEmulator>();

			return (builder.Build());
		}
	}
}