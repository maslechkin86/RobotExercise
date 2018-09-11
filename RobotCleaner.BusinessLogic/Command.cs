using RobotCleaner.BusinessLogic.Enums;

namespace RobotCleaner.BusinessLogic {

	/// <summary>
	/// Represents the robot command.
	/// </summary>
	public class Command {

		/// <summary>
		/// Gets or sets the compass direction.
		/// </summary>
		/// <value>
		/// The compass direction.
		/// </value>
		public CompassDirection Direction { get; set; }

		/// <summary>
		/// Gets or sets the steps number.
		/// </summary>
		/// <value>
		/// The steps number.
		/// </value>
		public int StepsNumber { get; set; }

	}

}
