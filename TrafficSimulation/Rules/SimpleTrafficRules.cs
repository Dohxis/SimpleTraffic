﻿using System;
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
                bool canMove = true;
                bool lightstrue = true;
                TileAction nextAction = new NoAction();

                if (tile.Actions.Count > 0)
                {
                    nextAction = tile.Actions[0];
                }
                // bool canUp = (checkTrafficLight(tile.Position.X + 1, tile.Position.Y, initialTiles) && checkTrafficLight(tile.Position.X + 2, tile.Position.Y, initialTiles));
                // bool canDown = (checkTrafficLight(tile.Position.X - 1, tile.Position.Y, initialTiles) && checkTrafficLight(tile.Position.X - 2, tile.Position.Y, initialTiles));
                // bool canLeft = (checkTrafficLight(tile.Position.X, tile.Position.Y - 1, initialTiles) && checkTrafficLight(tile.Position.X, tile.Position.Y - 2, initialTiles));
                // bool canRight = (checkTrafficLight(tile.Position.X, tile.Position.Y + 1, initialTiles) && checkTrafficLight(tile.Position.X, tile.Position.Y + 2, initialTiles));
                if (nextAction.GetType() == typeof(MoveAction))
                {
                    switch (((MoveAction)nextAction).direction)
                    {
                        case Direction.Up:
                            canMove = checkFront(tile.Position.X, tile.Position.Y - 1, initialTiles);
                            lightstrue = (checkTrafficLight(tile.Position.X + 1, tile.Position.Y, initialTiles) &&/* checkTrafficLight(tile.Position.X + 2, tile.Position.Y, initialTiles) &&*/ checkRightLight(tile.Position.X + 1, tile.Position.Y - 1, initialTiles));

                            break;
                        case Direction.Down:
                            canMove = checkFront(tile.Position.X, tile.Position.Y + 1, initialTiles);
                            lightstrue = (checkTrafficLight(tile.Position.X - 1, tile.Position.Y, initialTiles) && /*checkTrafficLight(tile.Position.X - 2, tile.Position.Y, initialTiles) &&*/ checkRightLight(tile.Position.X - 1, tile.Position.Y + 1, initialTiles));
                            break;
                        case Direction.Left:
                            canMove = checkFront(tile.Position.X - 1, tile.Position.Y, initialTiles);
                            lightstrue = (checkTrafficLight(tile.Position.X, tile.Position.Y - 1, initialTiles) && /*checkTrafficLight(tile.Position.X, tile.Position.Y - 2, initialTiles) &&*/ checkRightLight(tile.Position.X - 1, tile.Position.Y - 1, initialTiles));
                            break;
                        case Direction.Right:
                            canMove = checkFront(tile.Position.X + 1, tile.Position.Y, initialTiles);
                            lightstrue = (checkTrafficLight(tile.Position.X, tile.Position.Y + 1, initialTiles) && /*checkTrafficLight(tile.Position.X, tile.Position.Y + 2, initialTiles) &&*/ checkRightLight(tile.Position.X + 1, tile.Position.Y + 1, initialTiles));
                            break;
                    }
                }

                if (!tile.Dirty /*&&canDown &&canLeft &&canRight &&canUp*/&& lightstrue && canMove)
                {
                    updatedTiles = action.Handle(tile, initialTiles);
                }
                else
                {
                    tile.Actions.Insert(0, action);
                }

                tiles = updatedTiles;
            }

            return tiles;
        }

        private bool checkTrafficLight(int x, int y, List<Tile> tiles)
        {
            Tile tile = tiles.Find(t => t.Position.X == x && t.Position.Y == y);

            return tile == null || (tile != null && tile.Type != TileType.TrafficLightRed);
        }
        private bool checkFront(int x, int y, List<Tile> tiles)
        {
            Tile tile = tiles.Find(t => t.Position.X == x && t.Position.Y == y);

            return tile == null || (tile != null && tile.Type != TileType.Car);
        }
        private bool checkRightLight(int x, int y, List<Tile> tiles)
        {
            Tile tile = tiles.Find(t => t.Position.X == x && t.Position.Y == y);

            return tile == null || (tile != null && tile.Type != TileType.Grass);
        }
        public void ChangeTrafficLights(List<Tile> tiles)
        {
            foreach (Tile t in tiles)
            {
                if (t.Type == TileType.TrafficLightGreen)
                {
                    t.Type = TileType.TrafficLightRed;
                }
                else if (t.Type == TileType.TrafficLightRed)
                {
                    t.Type = TileType.TrafficLightGreen;
                }
            }

        }
    }
}
