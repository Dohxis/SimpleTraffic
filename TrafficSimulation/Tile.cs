﻿using System;
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

        public TileAction getNextAction()
        {
            if(this.Actions.Count() == 0)
            {
                // Here we could return RemoveCarAction if tile 
                // type is Car, which would allow us to simply 
                // calculate all statistics
                return new NoAction();
            }

            TileAction nextAction = this.Actions[0];
            this.Actions.RemoveAt(0);
            return nextAction;
        }
    }
}
