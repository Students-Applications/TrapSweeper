namespace AtlasCopco.App.Emulator.Console
{
	internal static class ApplicationSettings
	{
		static ApplicationSettings()
		{
		}

		private static int? healthPoint;

		public static int HealthPoint
		{
			get
			{
				if (healthPoint.HasValue == false)
				{
					string healthPointString =
						System.Configuration.ConfigurationManager.AppSettings["HealthPoint"];

					if (string.IsNullOrWhiteSpace(healthPointString))
					{
						healthPoint = 2;
					}
					else
					{
						try
						{
							healthPoint =
								System.Convert.ToInt32(healthPointString);
						}
						catch
						{
							healthPoint = 2;
						}
					}
				}

				return (healthPoint.Value);
			}
		}
	}
}
