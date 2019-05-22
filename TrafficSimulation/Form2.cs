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

        private List<PictureBox> comparePoints = new List<PictureBox>();
        

        List<PictureBox> exitPoints = new List<PictureBox>();

        public Form2()
        {
            InitializeComponent();
            this.grid = createInitialGrid();
            this.pictureBoxes = new List<PictureBox>();
            createTimer();
            CreateGrid(grid);
        }

        private void createTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer(this.simuationUpdateInterval);
            timer.Enabled = true;
        }


        private Grid createInitialGrid()
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

