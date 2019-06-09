using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSimulation.Actions;

namespace TrafficSimulation
{
    class Tile
    {

        public Position Position { get; }
        public List<TileAction> Actions { get; set; }
        public bool Dirty { get; set; }
        public TileType Type { get; set; }
        public int Id { get; set; }

        public static int Cars_Removed { get; set; }

        public Tile(int x, int y, TileType type, List<TileAction> actions)
        {
            this.Position = new Position(x, y);
            this.Actions = actions;
            this.Type = type;
            this.Dirty = false;
        }

        public Tile(TileType type)
        {
            this.Type = type;
            this.Dirty = false;
        }

        public Tile(int x, int y, TileType type)
        {
            Position.X = x;
            Position.Y = y;
            this.Type = type;
            this.Dirty = false;
        }

        public Tile(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
        }
        public List<TileAction> getRoute(Tile spawn, List<Tile> Tiles, Grid grid, Tile exit)
        {
            List<Tile> routeList = new List<Tile>();

            MoveAction LeadAction;
            Tile currentTile = spawn;
            Tile nextTile = currentTile;

            if (grid.DownSpawnPoints.Contains(spawn))
            { 
                LeadAction = new MoveAction(Direction.Up);

                while(currentTile.Position.Y != exit.Position.Y)
                {
                    nextTile = Tiles.Find(box =>
                                box.Position.X == currentTile.Position.X &&
                                box.Position.Y == currentTile.Position.Y - 1
                            );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                }

                if (exit.Position.X < currentTile.Position.X)
                {
                    LeadAction = new MoveAction(Direction.Left);

                    while(currentTile.Position.X != exit.Position.X)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X - 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }

                }
                else if (exit.Position.X > currentTile.Position.X)
                {
                    LeadAction = new MoveAction(Direction.Right);

                    while(currentTile.Position.X != exit.Position.X)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X + 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }
                }



                
            }
            else if (grid.RightSpawnPoints.Contains(spawn))
            {
                LeadAction = new MoveAction(Direction.Left);
                

                while (currentTile.Position.X != exit.Position.X)
                {
                    nextTile = Tiles.Find(box =>
                        box.Position.X == currentTile.Position.X - 1 &&
                        box.Position.Y == currentTile.Position.Y
                    );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                }

                if (exit.Position.Y < currentTile.Position.Y)
                {
                    LeadAction = new MoveAction(Direction.Up);

                    while (currentTile.Position.Y != exit.Position.Y) 
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X &&
                                    box.Position.Y == currentTile.Position.Y - 1
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    } 

                }
                else if (exit.Position.Y > currentTile.Position.Y)
                {
                    LeadAction = new MoveAction(Direction.Down);
                    while (currentTile.Position.Y != exit.Position.Y)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X &&
                                    box.Position.Y == currentTile.Position.Y + 1
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    } 
                }



                
            }
            else if (grid.LeftSpawnPoints.Contains(spawn))
            {
                LeadAction = new MoveAction(Direction.Right);

                while(currentTile.Position.X != exit.Position.X)
                {
                    nextTile = Tiles.Find(box =>
                        box.Position.X == currentTile.Position.X + 1 &&
                        box.Position.Y == currentTile.Position.Y
                    );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                }

                if (exit.Position.Y < currentTile.Position.Y)
                {
                    LeadAction = new MoveAction(Direction.Up);

                    while (currentTile.Position.Y != exit.Position.Y)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X &&
                                    box.Position.Y == currentTile.Position.Y - 1
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    } 

                }
                else if (exit.Position.Y > currentTile.Position.Y)
                {
                    LeadAction = new MoveAction(Direction.Down);
                    while (currentTile.Position.Y != exit.Position.Y) 
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X &&
                                    box.Position.Y == currentTile.Position.Y + 1
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    } 
                }



                
            }
            else if (grid.UpSpawnPoints.Contains(spawn))
            {
                LeadAction = new MoveAction(Direction.Down);
                while (currentTile.Position.Y != exit.Position.Y) 
                {
                    nextTile = Tiles.Find(box =>
                                box.Position.X == currentTile.Position.X &&
                                box.Position.Y == currentTile.Position.Y + 1
                            );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                } 

                if (exit.Position.X < currentTile.Position.X)
                {
                    LeadAction = new MoveAction(Direction.Left);

                    while (currentTile.Position.X != exit.Position.X) 
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X - 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    } 

                }
                else if (exit.Position.X < currentTile.Position.X)
                {
                    LeadAction = new MoveAction(Direction.Right);
                    while (currentTile.Position.X != exit.Position.X) 
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X + 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    } 
                }
            }


            return Actions;
            
        }

        public TileAction getNextAction()
        {
            if(this.Actions == null)
            {
                if(this.Type == TileType.Car)
                {
                    
                    return new RemoveCar();                    
                }
                return new NoAction();
            }

            if (this.Actions.Count != 0)
            {
                TileAction nextAction = this.Actions[0];
                this.Actions.RemoveAt(0);
                return nextAction;
            }

            if (this.Type == TileType.Car && this.Actions.Count == 0)
            {
                Cars_Removed++;
                return new RemoveCar();
            }

            return new NoAction();
        }
    }
}

