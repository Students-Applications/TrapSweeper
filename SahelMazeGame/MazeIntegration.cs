namespace SahelMazeGame
{
	public class MazeIntegration : object, SN.Integration.Maze.IMazeIntegration
	{
		public void BuildMaze(int size)
		{
		}

		public bool CausesInjury(int roomId)
		{
			return (true);
		}

		public string GetDescription(int roomId)
		{
			return (string.Empty);
		}

		public int GetEntranceRoom()
		{
			return (1);
		}

		public int? GetRoom(int roomId, char direction)
		{
			return (1);
		}

		public bool HasTreasure(int roomId)
		{
			return (true);
		}
	}
}
