using FluentAssertions;
using RobotCleaner.BusinessLogic.Interfaces;
using Xunit;

namespace RobotCleaner.BusinessLogic.Tests {

	public class OfficeAreaTestCase {

		private readonly IOfficeArea office;

		public OfficeAreaTestCase() {
			office = new OfficeArea();
		}

		[Theory]
		[InlineData(0, 0)]
		[InlineData(-100, -100)]
		[InlineData(-100000, -100000)]
		[InlineData(-100001, -100000)]
		[InlineData(100000, 100000)]
		[InlineData(100001, 100000)]
		public void GetValidCoordinate_ReturnExpectedValue_IfCall(int value, int expectedReturnValue) {
			// Act
			var response = office.GetValidCoordinate(value);

			// Assert
			response.Should().Be(expectedReturnValue);
		}

		[Fact]
		public void Clean_ReturnExpectedValue_IfCellNotCleaned() {
			// Arrange
			const int x = 1;
			const int y = 1;

			// Act
			var response = office.Clean(x, y);

			// Assert
			response.Should().BeTrue();
		}

		[Fact]
		public void Clean_ReturnExpectedValue_IfCellWasCleaned() {
			// Arrange
			const int x = 1;
			const int y = 1;

			// Act
			office.Clean(x, y);
			var response = office.Clean(x, y);

			// Assert
			response.Should().BeTrue();
		}

		[Fact]
		public void Clean_CalculateUniqueCleanedCells_IfCall() {
			// Arrange
			const int x = 1;
			const int y = 0;

			// Act
			office.Clean(x, y);

			// Assert
			office.CleanedPlaces.Should().Be(1);
		}

		[Fact]
		public void Clean_CalculateUniqueCleanedCells_IfCleanSeveralTimes() {
			// Act
			office.Clean(1, 0);
			office.Clean(2, 0);
			office.Clean(3, 0);

			// Assert
			office.CleanedPlaces.Should().Be(3);
		}

		[Fact]
		public void Clean_CalculateUniqueCleanedCells_IfSetSamePositionSeveralTimes() {
			// Act
			office.Clean(0, 0); // +
			office.Clean(1, 0); // +
			office.Clean(2, 0); // +
			office.Clean(1, 0); // -
			office.Clean(1, 1); // +

			// Assert
			office.CleanedPlaces.Should().Be(4);
		}

	}
}
