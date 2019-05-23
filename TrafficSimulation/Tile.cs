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
