using System;
namespace Undersea
{
	public interface GridObject
	{
		GridCoord GetGridPosition();
		void SetGridPosition(GridCoord coord);
	}
}

