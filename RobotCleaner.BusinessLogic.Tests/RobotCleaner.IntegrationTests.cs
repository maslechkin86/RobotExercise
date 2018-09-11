using FluentAssertions;
using Xunit;

namespace RobotCleaner.BusinessLogic.Tests {

	public class RobotCleanerIntegrationTests {

		[Theory]
		[InlineData(4, 5)]
		[InlineData(55, 105)]
		[InlineData(0, 0)]
		[InlineData(100000, 100000)]
		[InlineData(-100000, -100000)]
		public void SetStartPosition_StorePosition_IfCellNotCleaned(int x, int y) {
			// Arrange
			var office = new OfficeArea();
			var robot = new RobotHoover(office, new CommandParser());

			// Act
			robot.SetStartPosition(x, y);

			// Assert
			robot.Position.X.Should().Be(x);
			robot.Position.Y.Should().Be(y);
		}

		[Theory]
		[InlineData(-100001, 5, -100000, 5)]
		[InlineData(5, -100001, 5, -100000)]
		[InlineData(5, 100001, 5, 100000)]
		[InlineData(100001, 5, 100000, 5)]
		public void SetStartPosition_StorePosition_IfStepOutOfBonds(int x, int y, int expectedX, int expectedY) {
			// Arrange
			var office = new OfficeArea();
			var robot = new RobotHoover(office, new CommandParser());

			// Act
			robot.SetStartPosition(x, y);

			// Assert
			robot.Position.X.Should().Be(expectedX);
			robot.Position.Y.Should().Be(expectedY);
		}

		[Fact]
		public void DoInstructions_ReturnCleanedPlaces_IfCall() {
			// Arrange
			var office = new OfficeArea();
			var robot = new RobotHoover(office, new CommandParser());
			robot.SetStartPosition(0, 0);
			const int stepsNumber = 5;

			// Act
			robot.DoInstruction($"E {stepsNumber}");

			// Assert
			const int initialPosition = 1;
			const int command1 = stepsNumber;
			const int expectedCleanedPlaces = command1 + initialPosition;
			office.CleanedPlaces.Should().Be(expectedCleanedPlaces);
		}

		[Fact]
		public void DoInstructions_ReturnCleanedPlaces_IfCleadTwiceSeveralCells() {
			// Arrange
			var office = new OfficeArea();
			var robot = new RobotHoover(office, new CommandParser());
			robot.SetStartPosition(0, 0);
			const int stepsNumber = 5;

			// Act
			robot.DoInstruction($"E {stepsNumber}");
			robot.DoInstruction($"W {stepsNumber + 1}");

			// Assert
			const int initialPosition = 1;
			const int command1 = stepsNumber;
			const int command2 = 1;
			const int expectedCleanedPlaces = command1 + command2 + initialPosition;
			office.CleanedPlaces.Should().Be(expectedCleanedPlaces);
		}

		[Fact]
		public void DoInstructions_ReturnCleanedPlaces_IfMoveFromOneBondToAnother() {
			// Arrange
			var office = new OfficeArea();
			var robot = new RobotHoover(office, new CommandParser());
			robot.SetStartPosition(-100000, 0);
			const int iterations = 2;

			// Act
			robot.SetStartPosition(-100000, 0);
			for(var i = 0; i < iterations; i++) {
				robot.DoInstruction($"E {office.MaxCoordinate}");
				robot.DoInstruction($"E {office.MaxCoordinate}");
				robot.DoInstruction("S 1");
				robot.DoInstruction($"W {office.MaxCoordinate}");
				robot.DoInstruction($"W {office.MaxCoordinate}");
				robot.DoInstruction("S 1");
			}

			// Assert
			const int initialPosition = 1;
			var command1 = office.MaxCoordinate * 2 + 1;
			var command2 = office.MaxCoordinate * 2 + 1;
			var expectedCleanedPlaces = (command1 + command2 ) * iterations + initialPosition;
			office.CleanedPlaces.Should().Be(expectedCleanedPlaces);
		}
	}
}
