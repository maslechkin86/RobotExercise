using System.Collections.Generic;
using FluentAssertions;
using Moq;
using RobotCleaner.BusinessLogic.Interfaces;
using Xunit;

namespace RobotCleaner.BusinessLogic.Tests {

	public class CleanProgramTestCase {

		private readonly Mock<IDataSource> source;

		private readonly Mock<IOfficeArea> office;

		private readonly Mock<IRobotHoover> robot;

		private readonly CleanProgram program;

		public CleanProgramTestCase() {
			source = new Mock<IDataSource>();
			office = new Mock<IOfficeArea>();
			robot = new Mock<IRobotHoover>();
			program = new CleanProgram(source.Object, office.Object, robot.Object);
		}

		[Fact]
		public void GetCleanedPlaces_ReturnExpectedValue_IfCall() {
			// Arrange
			var coordinate = new Coordinate {X = 10, Y = 22};
			const int moqCleanedPlaces = 3;
			source
				.Setup(_ => _.GetStartCoordinate())
				.Returns(coordinate);
			var instructions = new List<string> {
				"instruction 1",
				"instruction 2"
			};
			source
				.Setup(_ => _.GetCommandsCount())
				.Returns(instructions.Count);
			source
				.SetupSequence(_ => _.GetInstruction())
				.Returns(instructions[0])
				.Returns(instructions[1]);
			office
				.Setup(_ => _.CleanedPlaces)
				.Returns(moqCleanedPlaces);

			// Act
			var response = program.GetCleanedPlaces();

			// Assert
			response.Should().Be(moqCleanedPlaces);
			robot.Verify(_=>_.DoInstruction(instructions[0]), Times.Once);
			robot.Verify(_=>_.DoInstruction(instructions[1]), Times.Once);
			source.Verify(_ => _.GetCommandsCount(), Times.Once);
			source.Verify(_ => _.GetStartCoordinate(), Times.Once);
			source.Verify(_ => _.GetInstruction(), Times.Exactly(2));
		}
	}
}
