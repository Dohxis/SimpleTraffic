using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TrafficSimulation.Actions;
using TrafficSimulation.Rules;

namespace TrafficSimulation
{
    public partial class Form2 : Form
    {
        //List<List<PictureBox>> grid = new List<List<PictureBox>>();
        private Grid grid;
        private List<PictureBox> pictureBoxes;
        private int _intersectionCounter = 0;
        private int simuationUpdateInterval = 1000;
        private int pictureBoxSize = 20;
        private int pictureBoxGap = 1;
        private int timesUpdated = 0;
        System.Timers.Timer timer;
        private int carsspawned = 0;
        

        private List<PictureBox> comparePoints = new List<PictureBox>();
        

        List<PictureBox> exitPoints = new List<PictureBox>();

        public Form2()
        {
            InitializeComponent();
            this.grid = CreateInitialGrid();
            this.pictureBoxes = new List<PictureBox>();
            //createTimer();
            CreateGrid(grid);
            btnStop.Enabled = false;
        }

        private void createTimer()
        {
            timer = new System.Timers.Timer(this.simuationUpdateInterval);
            timer.Elapsed += this.updateSimulation;
            timer.Enabled = true;
        }

        private void StopTimer()
        {
            timer.Stop();
        }


        private void updateSimulation(object source, ElapsedEventArgs e)
        {
            this.grid.Tick();
            CreateGrid(this.grid);
            this.timesUpdated++;           
            // For demo purposes I will spawn a new car with random
            // actions every 3 ticks
            if (this.timesUpdated % 3 == 0)
            {
                //tbSpawnedCars.Text = carsspawned++.ToString();                    //pops up a cross-threading error, probably need an event to listen to carsspawned changes, and update tbSpawnedCars effectively.
                this.spawnDemoCar();
            }
        }


        private void spawnDemoCar()
        {
            List<TileAction> actions;
            Random random = new Random();
            Random ran = new Random();

            int i = ran.Next(grid.spawnPoints.Count);
            Tile point = grid.spawnPoints[i];

            if (grid.LeftSpawnPoints.Contains(point))                    //spawnpoint is on the left edge of the map                                          
            {
                //this pseudo-random is very weird, it always does the same shit
                switch (random.Next(4))
                {
                    //car turns right
                    case 0:
                        actions = new List<TileAction>() { 
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down)
                    };
                        break;

                    //car turns left
                    case 1:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up)
                    };
                        break;

                    //car turns back
                    case 3:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left)
                    };
                        break;

                    //car goes forward
                    default:
                    case 2:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right)
                    };
                        break;
                }
            }
            else if (grid.UpSpawnPoints.Contains(point))                 //spawnpoint is on the upper edge of the map
            {
                switch (random.Next(4))
                {
                    //car turns right
                    case 0:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left)
                    };
                        break;

                    //car turns left
                    case 1:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right)
                    };
                        break;

                    //car turns back
                    case 3:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up)
                    };
                        break;

                    //car goes forward
                    default:
                    case 2:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down)
                    };
                        break;
                }
            }
            else if (grid.RightSpawnPoints.Contains(point))                 //spawnpoint is on the right edge of the map
            {
                switch (random.Next(4))
                {
                    //car turns right
                    case 0:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up)
                    };
                        break;

                    //car turns left
                    case 1:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down)
                    };
                        break;

                    //car turns back
                    case 3:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right)
                    };
                        break;

                    //car goes forward
                    default:
                    case 2:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left)
                    };
                        break;
                }
            }
            else                                                           //spawnpoint is on the bottom edge of the map
            {
                switch (random.Next(4))
                {
                    //car turns right
                    case 0:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right)
                    };
                        break;

                    //car turns left
                    case 1:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),

                    };
                        break;

                    //car turns back
                    case 3:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down),
                        new MoveAction(Direction.Down)
                    };
                        break;

                    //car goes forward
                    default:
                    case 2:
                        actions = new List<TileAction>() {
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up)
                    };
                        break;
                }
            }                        

            this.grid.UpdateTile(grid.spawnPoints[i].Position.X, grid.spawnPoints[i].Position.Y, TileType.Car, actions);
            this.CreateGrid(this.grid);
        }

        private Grid CreateInitialGrid()
        {
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            return new Grid(tiles);
        }

        private void CreateGrid(Grid grid)
        {
            bool isFirstTime = this.pictureBoxes.Count() == 0;

            foreach (Tile tile in grid.Tiles)
            {
                if (isFirstTime)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(
                        tile.Position.X * (this.pictureBoxSize + this.pictureBoxGap),
                        tile.Position.Y * (this.pictureBoxSize + this.pictureBoxGap)
                    );
                    pictureBox.Size = new Size(this.pictureBoxSize, this.pictureBoxSize);
                    pictureBox.BackColor = this.getTileColor(tile.Type);
                    pictureBox.Click += new EventHandler(this.pictureBoxClick);
                    this.pictureBoxes.Add(pictureBox);
                    this.Controls.Add(pictureBox);
                }
                else
                {
                    PictureBox pictureBox = this.pictureBoxes.Find(box =>
                        box.Location.X == tile.Position.X * (this.pictureBoxSize + this.pictureBoxGap) &&
                        box.Location.Y == tile.Position.Y * (this.pictureBoxSize + this.pictureBoxGap)
                    );
                    pictureBox.BackColor = this.getTileColor(tile.Type);
                }

            }
        }

        private Color getTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Grass:
                    return Color.LightGreen;
                case TileType.Car:
                    return Color.Black;
                case TileType.Road:
                    return Color.LightGray;
                case TileType.Empty:
                    return Color.Blue;
                case TileType.SpawnPoint:
                    return Color.Red;
                case TileType.ExitPoint:
                    return Color.Black;

                // Compiler is stupid and cannot realize that
                // there is no other type, so this will
                // never happen
                default:
                    return Color.Red;
            }
        }

        public void RestoreGrid()
        {
            foreach (Tile t in grid.Tiles)
            {
                if (t.Type == TileType.SpawnPoint)
                {
                    t.Type = TileType.Road;
                }
            }
        }

        public void pictureBoxClick(object sender, EventArgs e) //Click event
        {
            PictureBox p = sender as PictureBox;
            //MessageBox.Show(p.Location.X.ToString() + " " + p.Location.Y.ToString() + " clicked");
            if (rbPlusIntersection.Checked == true)
            {
                RestoreGrid();
                grid.Draw_PlusIntersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
                
            }
            else if (rbTUp.Checked == true)
            {
                RestoreGrid();
                grid.Draw_TIntersectionUp(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
                
            }
            else if (rbTDown.Checked == true)
            {
                RestoreGrid();
                grid.Draw_TIntersectionDown(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
                
            }
            else if (rbTLeft.Checked == true)
            {
                RestoreGrid();
                grid.Draw_TIntersectionLeft(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbTRight.Checked == true)
            {
                RestoreGrid();
                grid.Draw_TIntersectionRight(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else
            {
                MessageBox.Show("Please choose a type of intersection");
            }

        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (grid.spawnPoints != null)
            {
                createTimer();
            }
            else
            {
                MessageBox.Show("Cars would drown.");
            }
            btnStop.Enabled = true;
            btnLaunch.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopTimer();
            btnStop.Enabled = false;
            btnLaunch.Enabled = true;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)                           //Can't seem to be able to close both forms simultaneously, needs looking into.
        {            
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                    Application.OpenForms[i].Close();
            }
        }
    }
}









// Controls used for hover
/*public void pictureBoxEnter(object sender, EventArgs e)
{
    try
    {
        PictureBox p = sender as PictureBox;
        if (rbPlusIntersection.Checked)
        {
            PlusHover(p.Location.X / 21, p.Location.Y / 21);
        }
    }
    catch (Exception ArgumentOutOfRangeException)
    {
        MessageBox.Show("Out of boundaries! Hover from the upper side to use again!");
    }

}

public void pictureBoxLeave(object sender, EventArgs e)
{
    try
    {
        PictureBox p = sender as PictureBox;
        this.RestoreEmpty(p.Location.X / 21, p.Location.Y / 21);
    }
    catch (Exception ArgumentOutOfRangeException)
    {
        MessageBox.Show("Out of boundaries! Hover from the upper side to use again!");
    }

}

public void PlusHover(int x, int y)
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

    foreach (Tile t in tiles)
    {
        grid[t.Position.X][t.Position.Y].BackColor = this.getTileColor(t.Type);
    }
}

public void RestoreEmpty(int x, int y)
{
    List<Tile> tiles = new List<Tile>();
    for (int a = x; a < x + 8; a++)
    {
        for (int b = y; b < y + 8; b++)
        {
              tiles.Add(new Tile(a, b, TileType.Empty, new List<TileAction>()));
        }
    }

    foreach (Tile t in tiles)
    {
        grid[t.Position.X][t.Position.Y].BackColor = this.getTileColor(t.Type);
    }
}*/

