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

        public Tile(int x, int y, TileType type, List<TileAction> actions)
        {
            this.Position = new Position(x, y);
            this.Actions = actions;
            this.Type = type;
            this.Dirty = false;
        }

        public List<TileAction> getRoute(Tile tile, List<Tile> tileLs)
        {
            Position Destination = new Position(this.Position.X, this.Position.Y);
            List<Tile> tileList = new List<Tile>();
            List<TileAction> actionList = new List<TileAction>();
            foreach (var item in tileLs)
            {
            if (item.Type == TileType.Road)
            {
                  if (item.Position.X < Destination.X && item.Position.Y < Destination.Y)
                  {
                        if (item.Position.Y == Destination.Y + 1)
                        {
                            tileList.Add(item);
                            tileLs.Remove(item);
                        }
                        else if (item.Position.X == Destination.X + 1)
                        {
                            tileList.Add(item);
                            tileLs.Remove(item);
                        }
                  }
                  else if (item.Position.X < Destination.X && item.Position.Y > Destination.Y)
                  {
                       if (item.Position.Y == Destination.Y - 1)
                       {
                            tileList.Add(item);
                            tileLs.Remove(item);
                       }
                       else if (item.Position.X == Destination.X + 1)
                       {
                            tileList.Add(item);
                            tileLs.Remove(item);
                       }
                  }
                  else if (item.Position.X > Destination.X && item.Position.Y > Destination.Y)
                  {
                       if (item.Position.Y == Destination.Y - 1)
                       {
                            tileList.Add(item);
                            tileLs.Remove(item);
                       }
                       else if (item.Position.X == Destination.X + 1)
                       {
                            tileList.Add(item);
                            tileLs.Remove(item);
                       }
                  }
                  else if (item.Position.X > Destination.X && item.Position.Y < Destination.Y)
                  {
                       if (item.Position.Y == Destination.Y + 1)
                       {
                            tileList.Add(item);
                            tileLs.Remove(item);
                       }
                       else if (item.Position.X == Destination.X + 1)
                       {
                       tileList.Add(item);
                       tileLs.Remove(item);
                       }
                  }
            }
            }
            tileList.Add(this);
            tileList.Reverse();
            for(int i = 0; i < tileList.Count() - 1; i++)
            {
                if(tileList[i + 1].Position.X > tileList[i].Position.X)
                {
                    actionList.Add(new MoveAction(Direction.Right));
                }
                else if(tileList[i + 1].Position.X < tileList[i].Position.X)
                {
                    actionList.Add(new MoveAction(Direction.Left));
                }
                else if (tileList[i + 1].Position.Y < tileList[i].Position.Y)
                {
                    actionList.Add(new MoveAction(Direction.Down));
                }
                else if (tileList[i + 1].Position.Y > tileList[i].Position.Y)
                {
                    actionList.Add(new MoveAction(Direction.Up));
                }
            }
            return actionList;
            //Car could be checking sides of the road by looking at distance from the grass
        }

        public TileAction getNextAction()
        {
            if(this.Actions.Count() == 0)
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

            TileAction nextAction = this.Actions[0];
            this.Actions.RemoveAt(0);
            return nextAction;
        }
    }
}
