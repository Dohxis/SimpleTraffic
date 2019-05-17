using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSimulation.Actions;

namespace TrafficSimulation.Rules
{
    // I have created an abstract class for traffic rules.
    // This allows us to have different implementations, for
    // example here I have implemented a simple traffic rules
    // which is basically no rules and allows cars to move
    // freely around the grid
    class SimpleTrafficRules : TrafficRules
    {
        public override List<Tile> Handle(List<Tile> initialTiles)
        {
            List<Tile> tiles = initialTiles;

            for (int i = 0; i < initialTiles.Count(); i++)
            {
                Tile tile = initialTiles[i];

                TileAction action = tile.getNextAction();
                List<Tile> updatedTiles = tiles;

                if (!tile.Dirty)
                {
                    updatedTiles = action.Handle(tile, initialTiles);
                }

                tiles = updatedTiles;
            }

            return tiles;
        }
    }
}
