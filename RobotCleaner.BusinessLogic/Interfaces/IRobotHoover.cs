namespace RobotCleaner.BusinessLogic.Interfaces {

	/// <summary>
	/// Represents logic of a cleaner robot.
	/// </summary>
	public interface IRobotHoover {

		/// <summary>
		/// Gets the current position of robot.
		/// </summary>
		/// <value>
		/// The current position.
		/// </value>
		Coordinate Position { get; }

		/// <summary>
		/// Does the instructions.
		/// </summary>
		/// <param name="instructions">The instructions.</param>
		/// <returns>The number of unique cleaned places.</returns>
		int DoInstruction(string instructions);

		/// <summary>
		/// Sets the start position of a robot.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		void SetStartPosition(int x, int y);

	}

}
