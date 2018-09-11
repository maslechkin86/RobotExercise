using FluentAssertions;
using Moq;
using RobotCleaner.BusinessLogic.Enums;
using RobotCleaner.BusinessLogic.Interfaces;
using Xunit;

namespace RobotCleaner.BusinessLogic.Tests {

	public class RobotHooverTestCase {

		private readonly Mock<IOfficeArea> office;

		private readonly Mock<ICommandParser> commandParser;

		private readonly RobotHoover robot;

		public RobotHooverTestCase() {
			office = new Mock<IOfficeArea>();
			commandParser = new Mock<ICommandParser>();
			robot = new RobotHoover(office.Object, commandParser.Object);
		}

		[Fact]
		public void SetStartPosition_SetInitialCoordinates_IfCall() {
			// Arrange
			const int x = 5;
			const int y = 10;
			office
				.Setup(_ => _.GetValidCoordinate(It.IsAny<int>()))
				.Returns((int c) => c);

			// Act
			robot.SetStartPosition(x, y);

			// Assert
			robot.Position.Should().NotBeNull();
			robot.Position.X.Should().Be(x);
			robot.Position.Y.Should().Be(y);
			office.Verify(_ => _.GetValidCoordinate(x));
			office.Verify(_ => _.GetValidCoordinate(y));
		}

		[Fact]
		public void DoInstruction_CleanExpectedPlaces_IfRobotGoToEast() {
			// Arrange
			const string instrunction = "*do something*";
			const int x = 0;
			const int y = 0;
			const int moqCleanedPlaces = 6;
			var command = new Command {Direction = CompassDirection.East, StepsNumber = 3};
			commandParser
				.Setup(_ => _.Parse(instrunction))
				.Returns(command);
			office
				.Setup(_ => _.GetValidCoordinate(It.IsAny<int>()))
				.Returns((int c) => c);
			office
				.Setup(_ => _.CleanedPlaces)
				.Returns(moqCleanedPlaces);

			// Act
			robot.DoInstruction(instrunction);

			// Assert
			commandParser.Verify(_ => _.Parse(instrunction), Times.Once);
			office.Verify(_ => _.Clean(x, y), Times.Once);
			office.Verify(_ => _.Clean(x + 1, y), Times.Once);
			office.Verify(_ => _.Clean(x + 2, y), Times.Once);
			office.Verify(_ => _.Clean(x + 3, y), Times.Once);
			office.Verify(_ => _.CleanedPlaces, Times.Once);
		}

		[Fact]
		public void DoInstruction_CleanExpectedPlaces_IfRobotGoToWest() {
			// Arrange
			const string instrunction = "*do something*";
			const int x = 0;
			const int y = 0;
			const int moqCleanedPlaces = 3;
			var command = new Command {Direction = CompassDirection.West, StepsNumber = 2};
			commandParser
				.Setup(_ => _.Parse(instrunction))
				.Returns(command);
			office
				.Setup(_ => _.GetValidCoordinate(It.IsAny<int>()))
				.Returns((int c) => c);
			office
				.Setup(_ => _.CleanedPlaces)
				.Returns(moqCleanedPlaces);

			// Act
			robot.DoInstruction(instrunction);

			// Assert
			commandParser.Verify(_ => _.Parse(instrunction), Times.Once);
			office.Verify(_ => _.Clean(x, y), Times.Once);
			office.Verify(_ => _.Clean(x - 1, y), Times.Once);
			office.Verify(_ => _.Clean(x - 2, y), Times.Once);
			office.Verify(_ => _.CleanedPlaces, Times.Once);
		}

		[Fact]
		public void DoInstruction_CleanExpectedPlaces_IfRobotGoToSouth() {
			// Arrange
			const string instrunction = "*do something*";
			const int x = 0;
			const int y = 0;
			const int moqCleanedPlaces = 5;
			var command = new Command {Direction = CompassDirection.South, StepsNumber = 4};
			commandParser
				.Setup(_ => _.Parse(instrunction))
				.Returns(command);
			office
				.Setup(_ => _.GetValidCoordinate(It.IsAny<int>()))
				.Returns((int c) => c);
			office
				.Setup(_ => _.CleanedPlaces)
				.Returns(moqCleanedPlaces);

			// Act
			robot.DoInstruction(instrunction);

			// Assert
			commandParser.Verify(_ => _.Parse(instrunction), Times.Once);
			office.Verify(_ => _.Clean(x, y), Times.Once);
			office.Verify(_ => _.Clean(x, y - 1), Times.Once);
			office.Verify(_ => _.Clean(x, y - 2), Times.Once);
			office.Verify(_ => _.Clean(x, y - 3), Times.Once);
			office.Verify(_ => _.Clean(x, y - 4), Times.Once);
			office.Verify(_ => _.CleanedPlaces, Times.Once);
		}

		[Fact]
		public void DoInstruction_CleanExpectedPlaces_IfRobotGoToNorth() {
			// Arrange
			const string instrunction = "*do something*";
			const int x = 0;
			const int y = 0;
			const int moqCleanedPlaces = 5;
			var command = new Command {Direction = CompassDirection.North, StepsNumber = 3};
			commandParser
				.Setup(_ => _.Parse(instrunction))
				.Returns(command);
			office
				.Setup(_ => _.GetValidCoordinate(It.IsAny<int>()))
				.Returns((int c) => c);
			office
				.Setup(_ => _.CleanedPlaces)
				.Returns(moqCleanedPlaces);

			// Act
			robot.DoInstruction(instrunction);

			// Assert
			commandParser.Verify(_ => _.Parse(instrunction), Times.Once);
			office.Verify(_ => _.Clean(x, y), Times.Once);
			office.Verify(_ => _.Clean(x, y + 1), Times.Once);
			office.Verify(_ => _.Clean(x, y + 2), Times.Once);
			office.Verify(_ => _.Clean(x, y + 3), Times.Once);
			office.Verify(_ => _.CleanedPlaces, Times.Once);
		}

	}

}
