using RobotCleaner.BusinessLogic.Interfaces;

namespace RobotCleaner.BusinessLogic {

	/// <summary>
	/// Represents logic for calculate a number of unique cleaned places by a robot.
	/// </summary>
	public class CleanProgram {

		private readonly IDataSource source;

		private readonly IOfficeArea office;

		private readonly IRobotHoover robot;

		/// <summary>
		/// Initializes a new instance of the <see cref="CleanProgram" /> class.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="office">The office.</param>
		/// <param name="robot">The robot.</param>
		public CleanProgram(IDataSource source, IOfficeArea office, IRobotHoover robot) {
			this.source = source;
			this.office = office;
			this.robot = robot;
		}

		/// <summary>
		/// Gets the number of cleaned unique places.
		/// </summary>
		/// <returns>The number of cleaned unique places.</returns>
		public int GetCleanedPlaces() {
			var commandsCount = source.GetCommandsCount();
			var coordinate = source.GetStartCoordinate();
			robot.SetStartPosition(coordinate.X, coordinate.Y);
			while(commandsCount > 0) {
				var instructions = source.GetInstruction();
				robot.DoInstruction(instructions);
				commandsCount--;
			}
			return office.CleanedPlaces;
		}

	}

}
