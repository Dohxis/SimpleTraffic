﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation.Actions
{
    class RemoveCar : TileAction
    {
        public override List<Tile> Handle(Tile tile, List<Tile> tiles)
        {
            int removeIndex = tiles.IndexOf(tile);
            int n = 1;
            List<TileAction> actions;
            actions = null;
            tiles[removeIndex] = new Tile(tile.Position.X, tile.Position.Y, TileType.Road, actions);
            Console.WriteLine(n);
            return tiles;
        }
    }
}
