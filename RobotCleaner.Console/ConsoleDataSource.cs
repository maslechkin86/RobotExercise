using RobotCleaner.BusinessLogic;
using RobotCleaner.BusinessLogic.Interfaces;

namespace RobotCleaner.Console {

	/// <summary>
	/// Represents logic which read data for setup robot from the console.
	/// </summary>
	/// <seealso cref="RobotCleaner.BusinessLogic.Interfaces.IDataSource" />
	public class ConsoleDataSource : IDataSource {

		/// <inheritdoc />
		public int GetCommandsCount() {
			var commandsCountStr = System.Console.ReadLine();
			var commandsCount = int.Parse(commandsCountStr);
			return commandsCount;
		}

		/// <inheritdoc />
		public Coordinate GetStartCoordinate() {
			var startingCoordinatesStr = System.Console.ReadLine();
			var coordinates = startingCoordinatesStr.Split(' ');
			var coordinate = new Coordinate {
				X = int.Parse(coordinates[0]),
				Y = int.Parse(coordinates[1])
			};
			return coordinate;
		}

		/// <inheritdoc />
		public string GetInstruction() {
			var instruction = System.Console.ReadLine();
			return instruction;
		}

	}

}
