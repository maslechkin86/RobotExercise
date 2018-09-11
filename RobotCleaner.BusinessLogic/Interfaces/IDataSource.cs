namespace RobotCleaner.BusinessLogic.Interfaces {

	/// <summary>
	/// Represents source of data for setup robot.
	/// </summary>
	public interface IDataSource {

		/// <summary>
		/// Gets the commands count.
		/// </summary>
		/// <returns>The number of commands.</returns>
		int GetCommandsCount();

		/// <summary>
		/// Gets the robot start coordinate.
		/// </summary>
		/// <returns>The start coordinate.</returns>
		Coordinate GetStartCoordinate();

		/// <summary>
		/// Gets the instruction for the robot.
		/// </summary>
		/// <returns>The instruction</returns>
		string GetInstruction();

	}

}
