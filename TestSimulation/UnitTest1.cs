using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficSimulation;
using System.Collections.Generic;
using TrafficSimulation.Actions;
using TrafficSimulation.Rules;

namespace TestSimulation
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void PathFindingTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }
            
            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.DownSpawnPoints[0]; 
            Tile exit = grid.LeftExitPoints[0];            
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X + 1;
            exitarr[1] = exit.Position.Y;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);
            
            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++) {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X + 1 && t.Position.Y == exit.Position.Y && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }
        [TestMethod]
        public void TrafficLightsRecognitionTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.DownSpawnPoints[0];
            Tile exit = grid.LeftExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            grid.Tick(5, 3, 0);
            grid.Tick(5, 3, 1);
            grid.Tick(5, 3, 2);
            grid.Tick(5, 3, 3);
            grid.Tick(5, 3, 4);
            grid.Tick(5, 3, 5);

            //Assert

            //This unit test should be checking position before car checked the red traffic light and position of the same car one tick after
        }

        public void TestMethod3()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }
            //Act
            Grid sosat = new Grid(tiles);

            sosat.Draw_Intersection(0, 0, 0, IntersectionType.Plus);
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = sosat.DownSpawnPoints[0];
            Tile exit = sosat.LeftExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);

            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));
            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));
            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));
            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));
            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));

            int[] cararr = new int[2];
            cararr[0] = car.Position.X;
            cararr[1] = car.Position.Y;
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X;
            exitarr[1] = exit.Position.Y;
            //Assert
        }
    }
}