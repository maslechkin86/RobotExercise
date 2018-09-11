namespace RobotCleaner.BusinessLogic.Interfaces {

	/// <summary>
	/// Represents logic of cleaning an office area.
	/// </summary>
	public interface IOfficeArea {

		/// <summary>
		/// Gets the maximum coordinate (100.000).
		/// </summary>
		/// <value>
		/// The maximum coordinate (100.000).
		/// </value>
		int MaxCoordinate { get; }

		/// <summary>
		/// Gets the number of cleaned places.
		/// </summary>
		/// <value>
		/// The number of cleaned places.
		/// </value>
		int CleanedPlaces { get; }

		/// <summary>
		/// Gets the valid coordinate.
		/// </summary>
		/// <param name="coordinate">The coordinate.</param>
		/// <returns></returns>
		int GetValidCoordinate(int coordinate);

		/// <summary>
		/// Cleans the place.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <returns>The cleaned status of cell in the current position.</returns>
		bool Clean(int x, int y);
	}

}
