using FluentAssertions;
using RobotCleaner.BusinessLogic.Enums;
using Xunit;

namespace RobotCleaner.BusinessLogic.Tests {

	public class CommandParserTestCase {

		[Fact]
		public void Parse_ReturnEmptyCollection_IfInstrunctionIsEmpty() {
			// Arrange
			var parser = new CommandParser();

			// Act
			var result = parser.Parse("");

			// Assert
			result.Should().BeNull();
		}

		[Theory]
		[InlineData("E 5", CompassDirection.East, 5)]
		[InlineData("S 2", CompassDirection.South, 2)]
		[InlineData("W 7", CompassDirection.West, 7)]
		[InlineData("N 9", CompassDirection.North, 9)]
		[InlineData("S 0", CompassDirection.South, 0)]
		[InlineData("N 100000", CompassDirection.North, 100000)]
		public void Parse_ReturnExpectedResponse_IfSet(string instructionString, CompassDirection expectedDirection,
				int expectedStepsNumber) {
			// Arrange
			var parser = new CommandParser();

			// Act
			var result = parser.Parse(instructionString);

			// Assert
			result.Should().NotBeNull();
			result.Direction.Should().Be(expectedDirection);
			result.StepsNumber.Should().Be(expectedStepsNumber);
		}

		[Fact]
		public void Parse_DetermineAsNorthDirection_IfDirectionIsUnknown() {
			// Arrange
			var parser = new CommandParser();
			const int expectedStepsNumber = 55;

			// Act
			var result = parser.Parse($"X {expectedStepsNumber}");

			// Assert
			result.Should().NotBeNull();
			result.Direction.Should().Be(CompassDirection.North);
			result.StepsNumber.Should().Be(expectedStepsNumber);
		}

		[Fact]
		public void Parse_DetermineAsZeroStepsCount_IfNumberOfStepsIsNotInteger() {
			// Arrange
			var parser = new CommandParser();
			const int expectedStepsNumber = 0;

			// Act
			var result = parser.Parse($"E xxx");

			// Assert
			result.Should().NotBeNull();
			result.Direction.Should().Be(CompassDirection.East);
			result.StepsNumber.Should().Be(expectedStepsNumber);
		}

	}

}