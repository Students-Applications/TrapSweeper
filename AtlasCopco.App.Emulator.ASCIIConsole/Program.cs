using Autofac;

namespace SN.App.Emulator.Console
{
	internal class Program
	{
		private static void Main()
		{
			// Thread to get (Escape) to exit application at anytime
			var closeConsole =
				new System.Threading.Thread(StartEmulator);

			closeConsole.SetApartmentState(System.Threading.ApartmentState.STA);

			closeConsole.Start();

			while (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
			{
				// do nothing until escape
			}

			System.Environment.Exit(0);
		}

		private static void StartEmulator()
		{
			// Autofac
			var container =
				ContainerConfig.Configure();

			using (var scope = container.BeginLifetimeScope())
			{
				var consolerEmulator =
					scope.Resolve<Integration.Maze.IEmulator>();

				consolerEmulator.EmulateMain();
			}
		}
	}
}
