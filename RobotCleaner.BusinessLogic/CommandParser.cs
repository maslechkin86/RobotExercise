using RobotCleaner.BusinessLogic.Enums;
using RobotCleaner.BusinessLogic.Interfaces;

namespace RobotCleaner.BusinessLogic {

	/// <summary>
	/// Represents logic for parse instruction string to the commands.
	/// </summary>
	/// <seealso cref="RobotCleaner.BusinessLogic.Interfaces.ICommandParser" />
	public class CommandParser : ICommandParser {

		/// <inheritdoc />
		public Command Parse(string instructionString) {
			var instruction = instructionString.Split(' ');
			if (instruction.Length != 2) {
				return null;
			}
			var command = new Command();
			switch (instruction[0]) {
				case "E":
					command.Direction = CompassDirection.East;
					break;
				case "W":
					command.Direction = CompassDirection.West;
					break;
				case "S":
					command.Direction = CompassDirection.South;
					break;
				default:
					command.Direction = CompassDirection.North;
					break;
			}
			if (!int.TryParse(instruction[1], out var stepsNumber)) {
				stepsNumber = 0;
			}
			command.StepsNumber = stepsNumber;
			return command;
		}

	}

}
