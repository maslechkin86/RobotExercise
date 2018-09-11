using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.BusinessLogic.Interfaces {

	/// <summary>
	/// Represents logic for parse instruction string to the commands.
	/// </summary>
	public interface ICommandParser {

		/// <summary>
		/// Parses the specified instruction string.
		/// </summary>
		/// <param name="instructionString">The instruction string.</param>
		/// <returns>The commands.</returns>
		Command Parse(string instructionString);

	}

}
