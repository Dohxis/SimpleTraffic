using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TrafficSimulation.Actions;
using TrafficSimulation.Rules;
using System.Reflection;

namespace TrafficSimulation
{
    public partial class Form_Simulation : Form
    {
        private Grid grid;
        private List<PictureBox> pictureBoxes;
        private int _intersectionCounter = 0;
        private int simuationUpdateInterval = 1000;
        private int pictureBoxSize = 20;
        private int pictureBoxGap = 1;
        private int timesUpdated = 0;        
        private int carsspawned = 0;
        private bool simIsLaunched = false;
        private bool carsTurnBlack = false;
        System.Windows.Forms.Timer timer;
        private DateTime dt;
        private TimeSpan ts = TimeSpan.Zero;

        private int timered;
        private int timegreen;

        private List<PictureBox> comparePoints = new List<PictureBox>();
        

        List<PictureBox> exitPoints = new List<PictureBox>();

        public Form_Simulation()
        {
            InitializeComponent();
            this.grid = CreateInitialGrid();
            this.pictureBoxes = new List<PictureBox>();
            string ImagesDirectory =
                    Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Resources"
                );
            this.PlusIntersection.Image = Properties.Resources.plus_intersection;
            this.TrafficPlusIntersection.Image = Properties.Resources.TrafficPlus;
            this.TUp.Image = Properties.Resources.TUp;
            this.TDown.Image = Properties.Resources.TDown;
            this.TLeft.Image = Properties.Resources.TLeft;
            this.TRight.Image = Properties.Resources.TRight;
            this.Corner1.Image = Properties.Resources.Corner3;
            this.Corner2.Image = Properties.Resources.Corner2;
            this.Corner3.Image = Properties.Resources.Corner1;
            this.Corner4.Image = Properties.Resources.Corner4;

            tbSpawnedCars.Text = "0";

            this.FormClosed += new FormClosedEventHandler(Form_Simulation_Closed);

            //createTimer();
            CreateGrid(grid);
            btnStop.Enabled = false;
        }
        

        void Form_Simulation_Closed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            Form_Stats f = new Form_Stats(carsspawned,Tile.Cars_Removed,ts);
            f.ShowDialog();
        }

        private void createTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(updateSimulation);
            timer.Interval = simuationUpdateInterval;
            timer.Enabled = true;
        }

        private void StopTimer()
        {
            timer.Stop();
            btnStop.Enabled = false;
            btnLaunch.Enabled = true;
        }

        void updateSimulation(object sender, EventArgs e)
        {
            this.grid.Tick(timered,timegreen,timesUpdated);
            CreateGrid(this.grid);
            this.timesUpdated++;
            tbCarsQuit.Text = Tile.Cars_Removed.ToString();
            ts = DateTime.Now - dt;
            tbTimeElapsed.Text = ts.ToString(@"hh\:mm\:ss");
             if (this.timesUpdated >= timered + timegreen + (timered - timegreen))
            {
                timesUpdated = 0;
            }
            if (this.timesUpdated % 2 == 0)
            {
                if (grid.spawnPoints.Count != 0)
                {
                    this.spawnDemoCar();
                    carsspawned++;
                    tbSpawnedCars.Text = carsspawned.ToString();
                }
                else
                {
                    StopTimer();
                    MessageBox.Show("No spawn Points!");
                }
            }
        }

        private void spawnDemoCar()
        {
            List<TileAction> actions = new List<TileAction>();
            Random random = new Random();
            Random ran = new Random();

            int i = ran.Next(grid.spawnPoints.Count);
            Tile point = grid.spawnPoints[i];

            int r = ran.Next(3);

            int a = 0;
            int b = 0;

            Tile spawn = grid.spawnPoints[0];
            Tile exit = grid.exitPoints[0];


            switch (r)
            {
                case 0:
                    a = ran.Next(grid.DownSpawnPoints.Count);
                    spawn = grid.DownSpawnPoints[a];

                    r = ran.Next(3);
                    switch(r)
                    {
                        case 0:
                            b = ran.Next(grid.UpExitPoints.Count);
                            exit = grid.UpExitPoints[b];
                            break;
                        case 1:
                            b = ran.Next(grid.RightExitPoints.Count);
                            exit = grid.RightExitPoints[b];
                            break;
                        case 2:
                            b = ran.Next(grid.LeftExitPoints.Count);
                            exit = grid.LeftExitPoints[b];
                            break;

                    }
                    break;
                case 1:
                    a = ran.Next(grid.LeftSpawnPoints.Count);
                    spawn = grid.LeftSpawnPoints[a];

                    r = ran.Next(3);
                    switch (r)
                    {
                        case 0:
                            b = ran.Next(grid.RightExitPoints.Count);
                            exit = grid.RightExitPoints[b];
                            break;
                        case 1:
                            b = ran.Next(grid.UpExitPoints.Count);
                            exit = grid.UpExitPoints[b];
                            break;
                        case 2:
                            b = ran.Next(grid.DownExitPoints.Count);
                            exit = grid.DownExitPoints[b];
                            break;
                    }

                    break;
                case 2:
                    a = ran.Next(grid.RightSpawnPoints.Count);
                    spawn = grid.RightSpawnPoints[a];

                    r = ran.Next(3);
                    switch (r)
                    {
                        case 0:
                            b = ran.Next(grid.LeftExitPoints.Count);
                            exit = grid.LeftExitPoints[b];
                            break;
                        case 1:
                            b = ran.Next(grid.UpExitPoints.Count);
                            exit = grid.UpExitPoints[b];
                            break;
                        case 2:
                            b = ran.Next(grid.DownExitPoints.Count);
                            exit = grid.DownExitPoints[b];
                            break;
                    }


                    break;
                case 3:
                    a = ran.Next(grid.UpSpawnPoints.Count);
                    spawn = grid.UpSpawnPoints[a];

                    r = ran.Next(3);
                    switch (r)
                    {
                        case 0:
                            b = ran.Next(grid.RightExitPoints.Count);
                            exit = grid.RightExitPoints[b];
                            break;
                        case 1:
                            b = ran.Next(grid.LeftExitPoints.Count);
                            exit = grid.LeftExitPoints[b];
                            break;
                        case 2:
                            b = ran.Next(grid.DownExitPoints.Count);
                            exit = grid.DownExitPoints[b];
                            break;
                    }
                    break;

            }
                    
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, new List<TileAction>());
            car.Actions = car.getRoute(spawn, grid.Tiles, this.grid, exit);
            car.AdjustRouteBySpeed();

            this.grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);
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


                    if (tile.Type == TileType.Car && !carsTurnBlack)
                    {
                        Direction d;

                        if (tile.Actions.Count > 0)
                        {
                            if (!(tile.Actions[0] is NoAction)) {
                                d = ((MoveAction)tile.Actions[0]).direction;
                                pictureBox.Image = Properties.Resources.thumbnail;                      // default down

                                if (d == Direction.Up)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                }
                                else if (d == Direction.Left)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                                else if (d == Direction.Right)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                }
                            }
                        }
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox.Image = null;
                        pictureBox.BackColor = this.getTileColor(tile.Type);
                    }
                                       
                    
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

                    if (tile.Type == TileType.Car && !carsTurnBlack)
                    {
                        Direction d;

                        if (tile.Actions.Count > 0)
                        {
                            if (!(tile.Actions[0] is NoAction))
                            {
                                d = ((MoveAction)tile.Actions[0]).direction;
                                pictureBox.Image = Properties.Resources.thumbnail;                      // default down

                                if (d == Direction.Up)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                }
                                else if (d == Direction.Left)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                                else if (d == Direction.Right)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                }
                            }
                        }                                     
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox.Image = null;
                        pictureBox.BackColor = this.getTileColor(tile.Type);
                    }

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
                    return Color.Pink;
                case TileType.TrafficLightRed:
                    return Color.DarkRed;
                case TileType.TrafficLightGreen:
                    return Color.DarkGreen;
                case TileType.TrafficLightYellow:
                    return Color.Yellow;
                case TileType.UpControlPoint:
                case TileType.DownControlPoint:
                case TileType.LeftControlPoint:
                case TileType RightControlPoint:
                    return Color.Purple;
            }
        }

        public void RestoreGrid()
        {
            foreach (Tile t in grid.Tiles)
            {
                if (t.Type == TileType.SpawnPoint || t.Type == TileType.ExitPoint)
                {
                    t.Type = TileType.Road;
                }
            }
        }

        public void pictureBoxClick(object sender, EventArgs e) //Click event
        {
            PictureBox p = sender as PictureBox;
            if (rbPlusIntersection.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Plus);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
                
            }
            else if (rbTrafficPlus.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TrafficPlus);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbTUp.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TUp);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
                
            }
            else if (rbTDown.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TDown);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
                
            }
            else if (rbTLeft.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TLeft);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbTRight.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TRight);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbCorner1.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Corner1);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbCorner2.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Corner2);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbCorner3.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Corner3);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbCorner4.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Corner4);
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
            if (grid.TrafficLightsNeeded)
            {
                try
                {
                    timegreen = Convert.ToInt32(tb_greenlight.Text);
                    timered = Convert.ToInt32(tb_redlight.Text);
                    if (timered <= timegreen)
                    {
                        simIsLaunched = true;
                        btnStop.Enabled = true;
                        btnLaunch.Enabled = false;
                        createTimer();
                        dt = DateTime.Now;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("please enter valid values for both green and red light time");
                }
            }
            if (grid.spawnPoints != null)
            {
                simIsLaunched = true;
                btnStop.Enabled = true;
                btnLaunch.Enabled = false;
                createTimer();
                dt = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Cars would drown.");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            simIsLaunched = false;
            StopTimer();
            btnStop.Enabled = false;
            btnLaunch.Enabled = true;
            timesUpdated = 0;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)                           
        {            
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                    Application.OpenForms[i].Close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            simIsLaunched = false;
            _intersectionCounter = 0;
            grid.Clear();
            grid.comparePoints.Clear();
            grid.spawnPoints.Clear();
            carsspawned = 0;
            Tile.Cars_Removed = 0;
            tbSpawnedCars.Text = carsspawned.ToString();
            tbCarsQuit.Text = Tile.Cars_Removed.ToString();
            this.CreateGrid(grid);
            grid.TrafficLightsNeeded = false;
            ts = TimeSpan.Zero;
        }

        private void tbTickFrequency_Scroll(object sender, EventArgs e)
        {
            switch (tbTickFrequency.Value)
            {
                case 0:
                    simuationUpdateInterval = 4000;
                    carsTurnBlack = false;
                    break;

                case 1:
                    simuationUpdateInterval = 2000;
                    carsTurnBlack = false;
                    break;

                case 2:
                    simuationUpdateInterval = 1000;
                    carsTurnBlack = false;
                    break;

                case 3:
                    simuationUpdateInterval = 500;
                    carsTurnBlack = false;
                    break;

                case 4:
                    simuationUpdateInterval = 200;
                    carsTurnBlack = true;
                    break;

                case 5:
                    simuationUpdateInterval = 100;
                    carsTurnBlack = true;
                    break;

                case 6:
                    simuationUpdateInterval = 50;
                    carsTurnBlack = true;
                    break;

                default:
                    break;
            }

            if (simIsLaunched)
            {
                timer.Interval = simuationUpdateInterval;
            }
        }
    }
}









