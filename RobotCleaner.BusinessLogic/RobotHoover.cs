using RobotCleaner.BusinessLogic.Enums;
using RobotCleaner.BusinessLogic.Interfaces;

namespace RobotCleaner.BusinessLogic {

	/// <summary>
	/// Represents logic of a cleaner robot.
	/// </summary>
	/// <seealso cref="RobotCleaner.BusinessLogic.Interfaces.IRobotHoover" />
	public class RobotHoover : IRobotHoover {

		private readonly IOfficeArea office;

		private readonly ICommandParser commandParser;

		/// <summary>
		/// Initializes a new instance of the <see cref="RobotHoover"/> class.
		/// </summary>
		/// <param name="office">The office.</param>
		/// <param name="commandParser">The command parser.</param>
		public RobotHoover(IOfficeArea office, ICommandParser commandParser) {
			this.office = office;
			this.commandParser = commandParser;
			Position = new Coordinate();
		}

		/// <inheritdoc />
		public Coordinate Position { get; private set; }

		private void ExecuteCommand(Command command) {
			var steps = command.StepsNumber;
			office.Clean(Position.X, Position.Y);
			while (steps > 0) {
				switch (command.Direction) {
					case CompassDirection.East:
						Position.X = office.GetValidCoordinate(Position.X + 1);
						break;
					case CompassDirection.West:
						Position.X = office.GetValidCoordinate(Position.X - 1);
						break;
					case CompassDirection.South:
						Position.Y = office.GetValidCoordinate(Position.Y - 1);
						break;
					default:
						Position.Y = office.GetValidCoordinate(Position.Y + 1);
						break;
				}
				office.Clean(Position.X, Position.Y);
				steps--;
			}
		}

		/// <inheritdoc />
		public void SetStartPosition(int x, int y) {
			Position = new Coordinate {
				X = office.GetValidCoordinate(x),
				Y = office.GetValidCoordinate(y)
			};
		}

		/// <inheritdoc />
		public int DoInstruction(string instructions) {
			var command = commandParser.Parse(instructions);
			ExecuteCommand(command);
			return office.CleanedPlaces;
		}

	}

}
