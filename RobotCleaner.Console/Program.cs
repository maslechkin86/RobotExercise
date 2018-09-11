using RobotCleaner.BusinessLogic;
using RobotCleaner.BusinessLogic.Interfaces;

namespace RobotCleaner.Console {

	class Program {

		static void Main(string[] args) {
			var source = new ConsoleDataSource();
			var office = new OfficeArea();
			var parser = new CommandParser();
			var robot = new RobotHoover(office, parser);
			var program = new CleanProgram(source, office, robot);
			var cleanedPlaces = program.GetCleanedPlaces();
			System.Console.WriteLine($"=> Cleaned: {cleanedPlaces}");
			System.Console.ReadKey();
		}

	}
}
