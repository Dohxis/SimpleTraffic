using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSimulation.Rules;
using TrafficSimulation.Actions;

namespace TrafficSimulation
{
    // There are multiple problems with this approach:
    // 1. Instead of using List<Tile> we should really use List<List<Tile>> 
    //    for easier access to the actual grid.
    //
    // 2. Merging roads/grass and cars into one variable. Thats very convienent for
    //    the form because we can just loop over tiles and render them, but it 
    //    creates a need of "Dirty" tiles. I think we should still have a function 
    //    "GetTiles()" for the form to render the map, but internally separate these
    //    to two entities.

    class Grid
    {
        private TrafficRules trafficRules;

        public List<Tile> Tiles { get; private set; }


        public Grid(List<Tile> tiles, TrafficRules trafficRules)
        {
            this.Tiles = tiles;
            this.trafficRules = trafficRules;
        }

        public void Tick()
        {
            this.Tiles = this.trafficRules.Handle(this.Tiles);
            this.Tiles = this.trafficRules.CleanDirtyTiles(this.Tiles);
        }

        // We should remove this when Grid class can spawn cars itself
        public void UpdateTile(int x, int y, TileType type, List<TileAction> actions)
        {
            Tile newTile = new Tile(x, y, type, actions);
            int tileIndex = this.Tiles.FindIndex(tile => tile.Position.X == x && tile.Position.Y == y);
            this.Tiles[tileIndex] = newTile;
        }
    }
}
