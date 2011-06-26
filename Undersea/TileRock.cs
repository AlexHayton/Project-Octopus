using System;
namespace Undersea
{
	public class TileRock : Tile
	{
		public TileRock ()
		{
			
		}
		
		public override void Draw()
		{
			MainWindow.GetRenderer().DrawText(new GridCoord(this.GridPosX + .4f, this.GridPosY + .4f), 8, "Rock");
		}
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
	}
}

