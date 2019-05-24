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

        public List<TileAction> getRoute(Tile spawn, List<Tile> Tiles, Tile exit)
        {
            List<Tile> routeList = new List<Tile>();
             
            MoveAction LeadAction = new MoveAction(Direction.Up);
            Tile currentTile = spawn;
            Tile nextTile;
            do
            {
                nextTile = Tiles.Find(box =>
                            box.Position.X == currentTile.Position.X &&
                            box.Position.Y == currentTile.Position.Y - 1
                        );
                currentTile = nextTile;
                Actions.Add(LeadAction);
            } while (currentTile.Position.Y != exit.Position.Y);

            if (exit.Position.X < currentTile.Position.X)
            {
                LeadAction = new MoveAction(Direction.Left);

                do
                {
                    nextTile = Tiles.Find(box =>
                                box.Position.X == currentTile.Position.X - 1 &&
                                box.Position.Y == currentTile.Position.Y
                            );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                } while (currentTile.Position.X != exit.Position.X);

            }
            else
            {
                LeadAction = new MoveAction(Direction.Right);
                do
                {
                    nextTile = Tiles.Find(box =>
                                box.Position.X == currentTile.Position.X + 1 &&
                                box.Position.Y == currentTile.Position.Y
                            );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                } while (currentTile.Position.X != exit.Position.X);
            }

            

            return Actions;

            /*for(int i = 0; i < routeList.Count(); i++)
            {
                if (routeList[i].Type == TileType.DownControlPoint && routeList[i+1].Type == TileType.DownControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                }
                else if (routeList[i].Type == TileType.RightControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                }
                else if (routeList[i].Type == TileType.LeftControlPoint)
                {
                    MoveAction up = new MoveAction(Direction.Up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                }
                else if (routeList[i].Type == TileType.UpControlPoint)
                {
                    MoveAction down = new MoveAction(Direction.Up);
                    actionList.Add(up);
                    actionList.Add(up);
                    actionList.Add(up);
                }
                else if ()
                {

                }
            }*/
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
                return new RemoveCar();
            }

            return new NoAction();
        }
    }
}
