using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation.Actions
{
    public enum Direction
    {
        Up, Down, Right, Left 
    }

    class MoveAction : TileAction
    {
        private Direction direction;

        public MoveAction(Direction direction)
        {
            this.direction = direction;
        }

        public override List<Tile> Handle(Tile car, List<Tile> tiles)
        {
            List<Tile> updatedTiles;

            switch (this.direction)
            {
                case Direction.Up:
                    updatedTiles = this.MoveUp(car, tiles);
                    break;
                case Direction.Right:
                    updatedTiles = this.MoveRight(car, tiles);
                    break;
                case Direction.Left:
                    updatedTiles = this.MoveLeft(car, tiles);
                    break;
                // Need to do Down, but for this demo it was unnecessary
                default:
                    updatedTiles = tiles;
                    break;
            }

            return updatedTiles;
        }

        private List<Tile> MoveUp(Tile car, List<Tile> tiles)
        {
            int newCarIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y - 1 &&
                tile.Position.X == car.Position.X
            );

            return this.Move(newCarIndex, car, tiles);
        }

        private List<Tile> MoveRight(Tile car, List<Tile> tiles)
        {
            int newCarIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y &&
                tile.Position.X == car.Position.X + 1
            );

            return this.Move(newCarIndex, car, tiles);
        }

        private List<Tile> MoveLeft(Tile car, List<Tile> tiles)
        {
            int newCarIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y &&
                tile.Position.X == car.Position.X - 1
            );

            return this.Move(newCarIndex, car, tiles);
        }

        private List<Tile> Move(int newCarIndex, Tile car, List<Tile> tiles)
        {
            List<Tile> updatedTiles = tiles;

            int newRoadIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y &&
                tile.Position.X == car.Position.X
            );

            

            if (newCarIndex != -1)
            {
                updatedTiles[newCarIndex].Type = TileType.Car;
                updatedTiles[newCarIndex].Actions = car.Actions;
                updatedTiles[newCarIndex].Dirty = true;
            }

            updatedTiles[newRoadIndex].Actions = new List<TileAction>();
            updatedTiles[newRoadIndex].Type = TileType.Road;
            updatedTiles[newRoadIndex].Dirty = true;

            return updatedTiles;
        }
    }
}
