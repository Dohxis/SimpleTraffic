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
            //нужно добавить условие для проверки самих spawn точек и отредактировать направление в зависимости от начальной и конечной точек
            if (grid.DownSpawnPoints.Contains(spawn))
            { 
                LeadAction = new MoveAction(Direction.Up);
                /*do
                {
                    nextTile = Tiles.Find(box =>
                                box.Position.X == currentTile.Position.X &&
                                box.Position.Y == currentTile.Position.Y - 1
                            );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                } while (currentTile.Position.Y != exit.Position.Y);*/

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

                    /*do
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X - 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    } while (currentTile.Position.X != exit.Position.X);*/

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
                    /*do
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X + 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    } while (currentTile.Position.X != exit.Position.X);*/

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
                // Here we could return RemoveCarAction if tile 
                // type is Car, which would allow us to simply 
                // calculate all statistics
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

/*List<Tile> routeList = new List<Tile>();
            List<TileAction> actionList = new List<TileAction>();
            MoveAction LeadAction = new MoveAction(Direction.Up);
            Tile currentTile = spawn;
            routeList.Add(exit);
            //Tiles.Remove(exit);
            // Добавить enum для exit points
            // смысл в том, чтобы в зависимости от точки выхода определялось направление поиска маршрута, а после, в зависимости от направления
            // control point точно также определять дальнейшее направление маршрута
            // контролировать расстояние до травы
            for(int i = 0; i < Tiles.Count; i++)
            {
                if(routeList[i].Type == TileType.LeftExitPoint || routeList[i].Type == TileType.RightControlPoint)
                {
                    for (int t = 0; t < Tiles.Count; t++)
                    {
                        if (Tiles[t].Type != TileType.Grass)
                        { 
                            if (Tiles[t].Position.X == spawn.Position.X && routeList[i].Position.Y == Tiles[t].Position.Y)
                            {
                                if (Tiles[t].Position.Y < spawn.Position.Y)
                                {
                                    if (Tiles[t + 2].Type != TileType.Grass)
                                    {
                                        routeList.Add(Tiles[t + 2]);
                                        Tiles.Remove(Tiles[t + 2]);
                                    }
                                }
                                else
                                {
                                    if (Tiles[t - 1].Type != TileType.Grass)
                                    {
                                        routeList.Add(Tiles[t - 1]);
                                        Tiles.Remove(Tiles[t - 1]);
                                    }
                                }
                            }
                            if (Tiles[t].Position.Y == routeList[i].Position.Y && routeList[i].Position.X < Tiles[t].Position.X && Tiles[t].Type == TileType.RightControlPoint)
                            {
                                routeList.Add(Tiles[t]);
                                Tiles.Remove(Tiles[t]);
                            }
                        }
                    }
                }
                if (routeList[i].Type == TileType.RightExitPoint || routeList[i].Type == TileType.LeftControlPoint)
                {
                    for (int t = 0; t < Tiles.Count; t++)
                    {
                        if (Tiles[t].Type != TileType.Grass)
                        {
                            if (Tiles[t].Position.X == spawn.Position.X && routeList[i].Position.Y == Tiles[t].Position.Y)
                            {
                                if (Tiles[t].Position.Y < spawn.Position.Y)
                                {
                                    if (Tiles[t + 1].Type != TileType.Grass)
                                    {
                                        routeList.Add(Tiles[t + 1]);
                                        Tiles.Remove(Tiles[t + 1]);
                                    }
                                }
                                else
                                {
                                    if (Tiles[t - 2].Type != TileType.Grass)
                                    {
                                        routeList.Add(Tiles[t - 2]);
                                        Tiles.Remove(Tiles[t - 2]);
                                    }
                                }
                            }
                            if (Tiles[t].Position.Y == routeList[i].Position.Y && routeList[i].Position.X > Tiles[t].Position.X && Tiles[t].Type == TileType.LeftControlPoint)
                            {
                                routeList.Add(Tiles[t]);
                                Tiles.Remove(Tiles[t]);
                            }
                        }
                    }
                }
                if (routeList[i].Type == TileType.DownExitPoint || routeList[i].Type == TileType.UpControlPoint)
                {
                    for (int t = 0; t < Tiles.Count; t++)
                    {
                        if (Tiles[t].Type != TileType.Grass)
                        {
                            if (Tiles[t].Position.Y == spawn.Position.Y && routeList[i].Position.X == Tiles[t].Position.X)
                            {
                                if (Tiles[t].Position.X < spawn.Position.X)
                                {
                                    if (Tiles[t - (Tiles[Tiles.Count - 1].Position.Y + 1)].Type != TileType.Grass)
                                    {
                                        routeList.Add(Tiles[t - (Tiles[Tiles.Count-1].Position.Y + 1)]);
                                        Tiles.Remove(Tiles[t - (Tiles[Tiles.Count - 1].Position.Y + 1)]);
                                    }
                                }
                                else
                                {
                                    if (Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1) + (Tiles[Tiles.Count - 1].Position.Y + 1)].Type != TileType.Grass)
                                    {
                                        routeList.Add(Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1) + (Tiles[Tiles.Count - 1].Position.Y + 1)]);
                                        Tiles.Remove(Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1) + (Tiles[Tiles.Count - 1].Position.Y + 1)]);
                                    }
                                }
                            }
                            if (Tiles[t].Position.X == routeList[i].Position.X && routeList[i].Position.Y < Tiles[t].Position.Y && Tiles[t].Type == TileType.UpControlPoint)
                            {
                                routeList.Add(Tiles[t]);
                                Tiles.Remove(Tiles[t]);
                            }
                        }
                    }
                }
                if (routeList[i].Type == TileType.UpExitPoint || routeList[i].Type == TileType.DownControlPoint)
                {
                    for (int t = 0; t < Tiles.Count; t++)
                    {
                        if (Tiles[t].Type != TileType.Grass)
                        {
                            if (Tiles[t].Position.Y == spawn.Position.Y && routeList[i].Position.X == Tiles[t].Position.X)
                            {
                                if (Tiles[t].Position.X < spawn.Position.X)
                                {
                                    if (Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1)].Type != TileType.Grass)
                                    {
                                        routeList.Add(Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1)]);
                                        Tiles.Remove(Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1)]);
                                    }
                                }
                                else
                                {
                                    if (Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1) + (Tiles[Tiles.Count - 1].Position.Y + 1)].Type != TileType.Grass)
                                    {
                                        routeList.Add(Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1) + (Tiles[Tiles.Count - 1].Position.Y + 1)]);
                                        Tiles.Remove(Tiles[t + (Tiles[Tiles.Count - 1].Position.Y + 1) + (Tiles[Tiles.Count - 1].Position.Y + 1)]);
                                    }
                                }
                            }
                            if (Tiles[t].Position.X == routeList[i].Position.X && routeList[i].Position.Y > Tiles[t].Position.Y && Tiles[t].Type == TileType.DownControlPoint)
                            {
                                routeList.Add(Tiles[t]);
                                Tiles.Remove(Tiles[t]);
                            }
                        }
                    }
                }
            }



            for(int i = 0; i < routeList.Count(); i++)
            {
                if (routeList[i].Type == TileType.DownControlPoint && routeList[i+1].Type == TileType.DownControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                }
                else if (routeList[i].Type == TileType.DownControlPoint && routeList[i+1].Type == TileType.RightControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    MoveAction left = new MoveAction(Direction.Left);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                }
                else if (routeList[i].Type == TileType.DownControlPoint && routeList[i + 1].Type == TileType.LeftControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    MoveAction right = new MoveAction(Direction.Right);
                    actionList.Add(up);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                }
                else if (routeList[i].Type == TileType.DownControlPoint && routeList[i + 1].Type == TileType.UpControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    MoveAction down = new MoveAction(Direction.Down);
                    MoveAction left = new MoveAction(Direction.Left);
                    actionList.Add(up);
                    actionList.Add(left);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(down);
                }
                else if (routeList[i].Type == TileType.LeftControlPoint && routeList[i + 1].Type == TileType.LeftControlPoint)
                {
                    MoveAction right = new MoveAction(Direction.Right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                }
                else if (routeList[i].Type == TileType.LeftControlPoint && routeList[i + 1].Type == TileType.RightControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    MoveAction right = new MoveAction(Direction.Right);
                    MoveAction left = new MoveAction(Direction.Left);
                    actionList.Add(right);
                    actionList.Add(up);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                }
                else if (routeList[i].Type == TileType.LeftControlPoint && routeList[i + 1].Type == TileType.UpControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    MoveAction right = new MoveAction(Direction.Right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(up);
                    actionList.Add(up);
                }
                else if (routeList[i].Type == TileType.LeftControlPoint && routeList[i + 1].Type == TileType.DownControlPoint)
                {
                    MoveAction right = new MoveAction(Direction.Right);
                    MoveAction down = new MoveAction(Direction.Down);
                    actionList.Add(right);
                    actionList.Add(down);
                }
                else if (routeList[i].Type == TileType.RightControlPoint && routeList[i + 1].Type == TileType.LeftControlPoint)
                {
                    MoveAction right = new MoveAction(Direction.Right);
                    MoveAction down = new MoveAction(Direction.Down);
                    MoveAction left = new MoveAction(Direction.Left);
                    actionList.Add(left);
                    actionList.Add(down);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                }
                else if (routeList[i].Type == TileType.RightControlPoint && routeList[i + 1].Type == TileType.RightControlPoint)
                {
                    MoveAction left = new MoveAction(Direction.Left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                }
                else if (routeList[i].Type == TileType.RightControlPoint && routeList[i + 1].Type == TileType.UpControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    MoveAction left = new MoveAction(Direction.Left);
                    actionList.Add(left);                    
                    actionList.Add(up);
                }
                else if (routeList[i].Type == TileType.RightControlPoint && routeList[i + 1].Type == TileType.DownControlPoint)
                {
                    MoveAction right = new MoveAction(Direction.Right);
                    MoveAction down = new MoveAction(Direction.Down);
                    actionList.Add(right);
                    actionList.Add(down);
                }
                else if (routeList[i].Type == TileType.UpControlPoint && routeList[i + 1].Type == TileType.LeftControlPoint)
                {
                    MoveAction right = new MoveAction(Direction.Right);
                    MoveAction down = new MoveAction(Direction.Down);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                    actionList.Add(right);
                }
                else if (routeList[i].Type == TileType.UpControlPoint && routeList[i + 1].Type == TileType.RightControlPoint)
                {
                    MoveAction left = new MoveAction(Direction.Left);
                    MoveAction down = new MoveAction(Direction.Down);
                    actionList.Add(down);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                    actionList.Add(left);
                }
                else if (routeList[i].Type == TileType.UpControlPoint && routeList[i + 1].Type == TileType.UpControlPoint)
                {
                    MoveAction down = new MoveAction(Direction.Down);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(down);
                    actionList.Add(down);
                }
                else if (routeList[i].Type == TileType.UpControlPoint && routeList[i + 1].Type == TileType.DownControlPoint)
                {
                    MoveAction right = new MoveAction(Direction.Right);
                    MoveAction down = new MoveAction(Direction.Down);
                    MoveAction up = new MoveAction(Direction.Up);
                    actionList.Add(down);
                    actionList.Add(right);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                }
            }
            return actionList;*/
