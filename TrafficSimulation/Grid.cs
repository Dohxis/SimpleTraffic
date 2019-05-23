using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSimulation.Rules;
using TrafficSimulation.Actions;

namespace TrafficSimulation
{
    // There are multiple problems with this approach:
    // 1. Instead of using List<Tile> we should really use List<List<Tile>> 
    //    for easier access to the actual grid.
    //
    // 2. Merging roads/grass and cars into one variable. Thats very convienent for
    //    the form because we can just loop over tiles and render them, but it 
    //    creates a need of "Dirty" tiles. I think we should still have a function 
    //    "GetTiles()" for the form to render the map, but internally separate these
    //    to two entities.

    class Grid
    {
        private TrafficRules trafficRules;

        public List<Tile> Tiles { get; private set; }
        public List<Tile> CarTiles { get; private set; }
        public List<Tile> RoadGrassTiles { get; private set; }
        public List<Tile> comparePoints { get; private set; }
        public List<Tile> selectedOnes { get; private set; }
        public List<Tile> spawnPoints { get; private set; }
        public List<Tile> DownSpawnPoints { get; private set; }
        public List<Tile> UpSpawnPoints { get; private set; }
        public List<Tile> LeftSpawnPoints { get; private set; }
        public List<Tile> RightSpawnPoints { get; private set; }

        public List<Tile> exitPoints { get; private set; }
        public List<Tile> DownExitPoints { get; private set; }
        public List<Tile> UpExitPoints { get; private set; }
        public List<Tile> LeftExitPoints { get; private set; }
        public List<Tile> RightExitPoints { get; private set; }

        public Grid(List<Tile> tiles, TrafficRules trafficRules)
        {
            this.Tiles = tiles;
            this.trafficRules = trafficRules;
            for(int i = 0; i <= this.Tiles.Count; i++)
            {
                if(this.Tiles[i].Type == TileType.Road || this.Tiles[i].Type == TileType.Grass)
                {
                    RoadGrassTiles.Add(this.Tiles[i]);
                }
                else
                {
                    CarTiles.Add(this.Tiles[i]);
                }
            }
        }

        public Grid(List<Tile> tiles)
        {
            this.Tiles = tiles;
            comparePoints = new List<Tile>();
            trafficRules = new SimpleTrafficRules();
        }

        public void Tick()
        {
            this.Tiles = this.trafficRules.Handle(this.Tiles);
            this.Tiles = this.trafficRules.CleanDirtyTiles(this.Tiles);
        }

        // We should remove this when Grid class can spawn cars itself
        public void UpdateTile(int x, int y, TileType type, List<TileAction> actions)
        {
            Tile newTile = new Tile(x, y, type, actions);
            int tileIndex = this.Tiles.FindIndex(tile => tile.Position.X == x && tile.Position.Y == y);
            this.Tiles[tileIndex] = newTile;
        }

        public void Draw_PlusIntersection(int x, int y, int intersectionCounter)
        {
            if (x + 7 <= Tiles[Tiles.Count - 1].Position.X && y + 7 <= Tiles[Tiles.Count - 1].Position.Y && Tiles[Tiles.Count - 1].Type == TileType.Empty)
            {
                if (intersectionCounter == 0)
                {
                    AddPlusToGrid(x,y);
                }
                else
                {
                    int _distance;

                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;

                    int _closestX = 0;
                    int _closestY = 0;

                    Tile e = this.Tiles.Find(tile => tile.Position.X == x && tile.Position.Y == y);

                    

                    foreach (Tile t in comparePoints)
                    {
                        _distance = Math.Abs(t.Position.X - e.Position.X);

                        if (_distance < _newValueX)
                        {
                            _newValueX = _distance;
                            _closestX = t.Position.X;
                        }
                    }

                    foreach (Tile a in comparePoints)
                    {
                        if (a.Position.X == _closestX)
                        {
                            _distance = Math.Abs(a.Position.Y - e.Position.Y);

                            if (_distance < _newValueY)
                            {
                                _newValueY = _distance;
                                _closestY = a.Position.Y;
                            }
                        }
                    }

                    Tile _closest = this.Tiles.Find(tile => tile.Position.X == _closestX && tile.Position.Y == _closestY);

                    if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X < _closest.Position.X) // Add Left
                    {
                        AddPlusToGrid(_closestX - 8, _closestY);
                    }
                    else if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X > _closest.Position.X) // Add Right
                    {
                        AddPlusToGrid(_closestX + 8, _closestY);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y < _closest.Position.Y) // Add up
                    {
                        AddPlusToGrid(_closestX, _closestY - 8);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y > _closest.Position.Y) // Add Down
                    {
                        AddPlusToGrid(_closestX, _closestY + 8);
                    }
                }
            }
            else
            {
                Console.WriteLine("Out of boundaries!");
            }
        }

        public void Draw_TIntersectionUp(int x, int y, int intersectionCounter)
        {
            if (x + 7 < Tiles[Tiles.Count - 1].Position.X && y + 7 < Tiles[Tiles.Count - 1].Position.Y)
            {
                if (intersectionCounter == 0)
                {
                    AddPlusToGrid(x, y);
                }
                else
                {
                    int _distance;

                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;

                    int _closestX = 0;
                    int _closestY = 0;

                    Tile e = this.Tiles.Find(tile => tile.Position.X == x && tile.Position.Y == y);



                    foreach (Tile t in comparePoints)
                    {
                        _distance = Math.Abs(t.Position.X - e.Position.X);

                        if (_distance < _newValueX)
                        {
                            _newValueX = _distance;
                            _closestX = t.Position.X;
                        }
                    }

                    foreach (Tile a in comparePoints)
                    {
                        if (a.Position.X == _closestX)
                        {
                            _distance = Math.Abs(a.Position.Y - e.Position.Y);

                            if (_distance < _newValueY)
                            {
                                _newValueY = _distance;
                                _closestY = a.Position.Y;
                            }
                        }
                    }

                    Tile _closest = this.Tiles.Find(tile => tile.Position.X == _closestX && tile.Position.Y == _closestY);


                    if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X < e.Position.X) // Add Left
                    {
                        AddT_UpToGrid(_closestX - 8, _closestY);
                    }
                    else if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X > _closest.Position.X) // Add Right
                    {
                        AddT_UpToGrid(_closestX + 8, _closestY);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y < _closest.Position.Y) // Add up
                    {
                        AddT_UpToGrid(_closestX, _closestY - 8);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y > _closest.Position.Y) // Add Down
                    {
                        AddT_UpToGrid(_closestX, _closestY + 8);
                    }
                }
            }
        }

        public void Draw_TIntersectionDown(int x, int y,int intersectionCounter)
        {
            if (x + 7 < Tiles[Tiles.Count - 1].Position.X && y + 7 < Tiles[Tiles.Count - 1].Position.Y)
            {
                if (intersectionCounter == 0)
                {
                    AddT_DownToGrid(x, y);
                }
                else
                {
                    int _distance;

                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;

                    int _closestX = 0;
                    int _closestY = 0;

                    Tile e = this.Tiles.Find(tile => tile.Position.X == x && tile.Position.Y == y);



                    foreach (Tile t in comparePoints)
                    {
                        _distance = Math.Abs(t.Position.X - e.Position.X);

                        if (_distance < _newValueX)
                        {
                            _newValueX = _distance;
                            _closestX = t.Position.X;
                        }
                    }

                    foreach (Tile a in comparePoints)
                    {
                        if (a.Position.X == _closestX)
                        {
                            _distance = Math.Abs(a.Position.Y - e.Position.Y);

                            if (_distance < _newValueY)
                            {
                                _newValueY = _distance;
                                _closestY = a.Position.Y;
                            }
                        }
                    }

                    Tile _closest = this.Tiles.Find(tile => tile.Position.X == _closestX && tile.Position.Y == _closestY);


                    if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X < _closest.Position.X) // Add Left
                    {
                        AddT_DownToGrid(_closestX - 8, _closestY);
                    }
                    else if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X > _closest.Position.X) // Add Right
                    {
                        AddT_DownToGrid(_closestX + 8, _closestY);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y < _closest.Position.Y) // Add up
                    {
                        AddT_DownToGrid(_closestX, _closestY - 8);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y > _closest.Position.Y) // Add Down
                    {
                        AddT_DownToGrid(_closestX, _closestY + 8);
                    }
                }
            }
        }

        public void Draw_TIntersectionLeft(int x, int y, int intersectionCounter)
        {
            if (x + 7 < Tiles[Tiles.Count - 1].Position.X && y + 7 < Tiles[Tiles.Count - 1].Position.Y)
            {
                if (intersectionCounter == 0)
                {
                    AddT_DownToGrid(x, y);
                }
                else
                {
                    int _distance;

                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;

                    int _closestX = 0;
                    int _closestY = 0;

                    Tile e = this.Tiles.Find(tile => tile.Position.X == x && tile.Position.Y == y);



                    foreach (Tile t in comparePoints)
                    {
                        _distance = Math.Abs(t.Position.X - e.Position.X);

                        if (_distance < _newValueX)
                        {
                            _newValueX = _distance;
                            _closestX = t.Position.X;
                        }
                    }

                    foreach (Tile a in comparePoints)
                    {
                        if (a.Position.X == _closestX)
                        {
                            _distance = Math.Abs(a.Position.Y - e.Position.Y);

                            if (_distance < _newValueY)
                            {
                                _newValueY = _distance;
                                _closestY = a.Position.Y;
                            }
                        }
                    }

                    Tile _closest = this.Tiles.Find(tile => tile.Position.X == _closestX && tile.Position.Y == _closestY);


                    if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X < _closest.Position.X) // Add Left
                    {
                        AddT_LeftToGrid(_closestX - 8, _closestY);
                    }
                    else if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X > _closest.Position.X) // Add Right
                    {
                        AddT_LeftToGrid(_closestX + 8, _closestY);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y < _closest.Position.Y) // Add up
                    {
                        AddT_LeftToGrid(_closestX, _closestY - 8);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y > _closest.Position.Y) // Add Down
                    {
                        AddT_LeftToGrid(_closestX, _closestY + 8);
                    }
                }
            }
        }

        public void Draw_TIntersectionRight(int x, int y, int intersectionCounter)
        {
            if (x + 7 < Tiles[Tiles.Count - 1].Position.X && y + 7 < Tiles[Tiles.Count - 1].Position.Y)
            {
                if (intersectionCounter == 0)
                {
                    AddT_RightToGrid(x, y);
                }
                else
                {
                    int _distance;

                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;

                    int _closestX = 0;
                    int _closestY = 0;

                    Tile e = this.Tiles.Find(tile => tile.Position.X == x && tile.Position.Y == y);



                    foreach (Tile t in comparePoints)
                    {
                        _distance = Math.Abs(t.Position.X - e.Position.X);

                        if (_distance < _newValueX)
                        {
                            _newValueX = _distance;
                            _closestX = t.Position.X;
                        }
                    }

                    foreach (Tile a in comparePoints)
                    {
                        if (a.Position.X == _closestX)
                        {
                            _distance = Math.Abs(a.Position.Y - e.Position.Y);

                            if (_distance < _newValueY)
                            {
                                _newValueY = _distance;
                                _closestY = a.Position.Y;
                            }
                        }
                    }

                    Tile _closest = this.Tiles.Find(tile => tile.Position.X == _closestX && tile.Position.Y == _closestY);


                    if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X < _closest.Position.X) // Add Left
                    {
                        AddT_RightToGrid(_closestX - 8, _closestY);
                    }
                    else if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X > _closest.Position.X) // Add Right
                    {
                        AddT_RightToGrid(_closestX + 8, _closestY);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y < _closest.Position.Y) // Add up
                    {
                        AddT_RightToGrid(_closestX, _closestY - 8);
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y > _closest.Position.Y) // Add Down
                    {
                        AddT_RightToGrid(_closestX, _closestY + 8);
                    }
                }
            }


        }

        public void AddPlusToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();

            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 3 || a >= x + 5 && a <= x + 8)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }

                    if (a == x + 3 || a == x + 4)
                    {
                        tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                    }

                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddT_UpToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 3 || a >= x + 5 && a <= x + 8)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }

                    if (a == x + 3 || a == x + 4)
                    {
                        if (b == y + 5 || b == y + 6 || b == y + 7)
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }

                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddT_DownToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 3 || a >= x + 5 && a <= x + 8)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }

                    if (a == x + 3 || a == x + 4)
                    {
                        if (b == y || b == y + 1 || b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }

                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddT_LeftToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 3)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }

                    if (a == x + 3 || a == x + 4)
                    {
                        tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                    }

                    if (a >= x + 5 && a <= x + 8)
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }
                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddT_RightToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 3)
                    {
                        tiles.Add(new Tile(a,b, TileType.Grass, new List<TileAction>()));
                    }
                    else if (a >= x + 3 && a < x + 5)
                    {
                        tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                    }
                    else if (a >= x+5 && a < x + 8)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void CheckGrid()
        {
            spawnPoints = new List<Tile>();
            exitPoints = new List<Tile>();
            LeftSpawnPoints = new List<Tile>();
            RightSpawnPoints = new List<Tile>();
            UpSpawnPoints = new List<Tile>();
            DownSpawnPoints = new List<Tile>();

            exitPoints = new List<Tile>();
            LeftExitPoints = new List<Tile>();
            RightExitPoints = new List<Tile>();
            UpExitPoints = new List<Tile>();
            DownExitPoints = new List<Tile>();


            foreach (Tile t in Tiles)
            {   //Finding all the spawnpoints
                Tile t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y + 1);
                Tile t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X - 1 && tile.Position.Y == t.Position.Y);
                if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty)
                {
                    t.Type = TileType.SpawnPoint;
                    spawnPoints.Add(t);
                    LeftSpawnPoints.Add(t);
                }

                t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X - 1 && tile.Position.Y == t.Position.Y);
                t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y - 1);
                if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty)
                {
                    t.Type = TileType.SpawnPoint;
                    spawnPoints.Add(t);
                    UpSpawnPoints.Add(t);
                }

                t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y - 1);
                t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X + 1 && tile.Position.Y == t.Position.Y);
                if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty)
                {
                    t.Type = TileType.SpawnPoint;
                    spawnPoints.Add(t);
                    RightSpawnPoints.Add(t);
                }

                t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X + 1 && tile.Position.Y == t.Position.Y);
                t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y + 1);
                if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty)
                {
                    t.Type = TileType.SpawnPoint;
                    spawnPoints.Add(t);
                    DownSpawnPoints.Add(t);
                }

                //Finding all the exitpoints
                t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X + 1 && tile.Position.Y == t.Position.Y);
                t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y - 1);
                if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty) // upper exitpoint
                {
                    t.Type = TileType.ExitPoint;
                    exitPoints.Add(t);
                    UpExitPoints.Add(t);
                }

                t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y - 1);
                t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X - 1 && tile.Position.Y == t.Position.Y);
                if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty) // left exitpoint
                {
                    t.Type = TileType.ExitPoint;
                    exitPoints.Add(t);
                    LeftExitPoints.Add(t);
                }

                t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X - 1 && tile.Position.Y == t.Position.Y);
                t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y + 1);
                if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty) // down exipoint
                {
                    t.Type = TileType.ExitPoint;
                    exitPoints.Add(t);
                    DownExitPoints.Add(t);
                }

                t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y + 1);
                t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X + 1 && tile.Position.Y == t.Position.Y);
                if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty) // right exitpoint
                {
                    t.Type = TileType.ExitPoint;
                    exitPoints.Add(t);
                    RightExitPoints.Add(t);
                }
            }
        }

        public void Clear()
        {
            foreach (Tile t in Tiles)
            {
                t.Type = TileType.Empty;
            }
        }
    }
}
