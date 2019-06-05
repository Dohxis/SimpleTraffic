using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation.Actions
{
    class LightAction: TileAction
    {
        public override List<Tile> Handle(Tile light, List<Tile> tiles)
        {
            List<Tile> updatedTiles;
            switch (light.Type)
            {
                case TileType.TrafficLightGreen:
                    updatedTiles = this.changeGreen(light,tiles);
                    break;
                case TileType.TrafficLightYellow:
                    updatedTiles = this.changeYellow(light, tiles);
                    break;
                case TileType.TrafficLightRed:
                    updatedTiles = this.changeRed(light, tiles);
                    break;
                default:
                    updatedTiles = tiles;
                    break;

            }
            return updatedTiles;
        }
        public List<Tile> changeGreen(Tile light, List<Tile> tiles)
        {
            int newlightIndex = tiles.FindIndex(tile =>
                tile.Position.Y == light.Position.Y &&
                tile.Position.X == light.Position.X
            );
            tiles[newlightIndex].Type = TileType.TrafficLightYellow;
            return tiles;
        }
        public List<Tile> changeRed(Tile light, List<Tile> tiles)
        {
            int newlightIndex = tiles.FindIndex(tile =>
                tile.Position.Y == light.Position.Y &&
                tile.Position.X == light.Position.X
            );
            tiles[newlightIndex].Type = TileType.TrafficLightGreen;
            return tiles;
        }
        public List<Tile> changeYellow(Tile light, List<Tile> tiles)
        {
            int newlightIndex = tiles.FindIndex(tile =>
                tile.Position.Y == light.Position.Y &&
                tile.Position.X == light.Position.X
            );
            tiles[newlightIndex].Type = TileType.TrafficLightRed;
            return tiles;
        }
    }
}
