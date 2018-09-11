using System;
using System.Collections.Generic;
using RobotCleaner.BusinessLogic.Interfaces;

namespace RobotCleaner.BusinessLogic {

	/// <summary>
	/// Represents logic of cleaning an office area.
	/// </summary>
	/// <seealso cref="RobotCleaner.BusinessLogic.Interfaces.IOfficeArea" />
	public class OfficeArea : IOfficeArea {

		private const int sectorSize = 50;

		private readonly Dictionary<string, bool[,]> sectors = new Dictionary<string, bool[,]>();

		/// <inheritdoc />
		public int MaxCoordinate { get; } = 100000;

		/// <inheritdoc />
		public int CleanedPlaces { get; private set; }

		private string GetSectorName(int coordinate) {
			var sectorName = (coordinate < 0 && coordinate > -MaxCoordinate)
				? "-" + (coordinate / sectorSize)
				: (coordinate / sectorSize).ToString();
			return sectorName;
		}

		/// <inheritdoc />
		public int GetValidCoordinate(int coordinate) {
			if(coordinate < -MaxCoordinate) {
				coordinate = -MaxCoordinate;
			}
			if(coordinate > MaxCoordinate) {
				coordinate = MaxCoordinate;
			}
			return coordinate;
		}

		/// <inheritdoc />
		public bool Clean(int x, int y) {
			var areaIndex = $"{GetSectorName(x)}x{GetSectorName(y)}";
			bool[,] sector;
			if(!sectors.ContainsKey(areaIndex)) {
				sector = new bool[sectorSize, sectorSize];
				sectors.Add(areaIndex, sector);
			} else {
				sector = sectors[areaIndex];
			}
			var subX = Math.Abs(x % sectorSize);
			var subY = Math.Abs(y % sectorSize);
			if(!sector[subX, subY]) {
				sector[subX, subY] = true;
				CleanedPlaces++;
			}
			return sector[subX, subY];
		}
	}

}
