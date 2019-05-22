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
using System.Windows.Forms;
using TrafficSimulation.Actions;

namespace TrafficSimulation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CreateGrid();

        }

        List<List<PictureBox>> grid = new List<List<PictureBox>>();
        private int _intersectionCounter = 0;
        List<PictureBox> comparePoints = new List<PictureBox>();
        private List<PictureBox> _selectedOnes;

        List<PictureBox> exitPoints = new List<PictureBox>();

        public void CreateGrid()
        {
            for (int x = 0; x < 40; x++)
            {
                grid.Add(new List<PictureBox>());
                for (int y = 0; y < 40; y++)
                {
                    Tile t = new Tile(x*21,y*21,TileType.Empty, new List<TileAction>());

                    PictureBox p = new PictureBox();
                    p.Name = "pictureBox";
                    p.Location = new Point(x * 21, y * 21);
                    p.Size = new Size(20, 20);
                    p.BackColor = this.getTileColor(t.Type);
                    p.Click += new EventHandler(this.pictureBoxClick);
                    //p.MouseEnter += new EventHandler(this.pictureBoxEnter);
                    //p.MouseLeave += new EventHandler(this.pictureBoxLeave);
                    grid[x].Add(p);
                    this.Controls.Add(p);
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
               
                // Compiler is stupid and cannot realize that
                // there is no other type, so this will
                // never happen
                default:
                    return Color.Red;
            }
        }

        public void pictureBoxClick(object sender, EventArgs e) //Click event
        {
            PictureBox p = sender as PictureBox;
            //MessageBox.Show(p.Location.X.ToString() + " " + p.Location.Y.ToString() + " clicked");
            if (rbPlusIntersection.Checked == true)
            {
                Draw_PlusIntersection(p.Location.X / 21, p.Location.Y / 21);
            }
            else if (rbTUp.Checked == true)
            {
                Draw_TIntersectionUp(p.Location.X/21, p.Location.Y / 21);
            }
            else if (rbTDown.Checked == true)
            {
                Draw_TIntersectionDown(p.Location.X/21, p.Location.Y / 21);
            }
            else if (rbTLeft.Checked == true)
            {
                Draw_TIntersectionLeft(p.Location.X/21, p.Location.Y / 21);
            }
            else if (rbTRight.Checked == true)
            {
                Draw_TIntersectionRight(p.Location.X / 21, p.Location.Y / 21);
            }
            else
            {
                MessageBox.Show("Please choose a type of intersection");
            }

        }

        public void Draw_PlusIntersection(int x, int y)
        {
            if (_intersectionCounter == 0)
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count)
                {
                    AddPlusToGrid(x,y);
                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries or already ocupied tiles!");
                }
            }
            else
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count && grid[x][y].BackColor == this.getTileColor(TileType.Empty) && grid[x+7][y+7].BackColor == this.getTileColor(TileType.Empty))
                {
                    int _distance;
                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;
                    PictureBox _closest = new PictureBox();

                    int _closestX = 0;
                    int _closestY = 0;

                    foreach (var a in comparePoints)
                    {
                        _distance = Math.Abs(a.Location.X / 21  - grid[x][y].Location.X / 21);

                        if (_distance < _newValueX)
                        {
                            _closestX = a.Location.X / 21;
                        }
                    }

                    foreach (var a in comparePoints)
                    {
                        if (a.Location.X == _closestX * 21)
                        {
                            _distance = Math.Abs(a.Location.Y / 21 - grid[x][y].Location.Y / 21);

                            if (_distance < _newValueX)
                            {
                                _closestY = a.Location.Y / 21;
                                _closest = grid[_closestX][_closestY];
                            }
                        }
                    }

                    
                    if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X < _closest.Location.X) // Add Left
                    {
                        AddPlusToGrid(_closestX - 8, _closestY );
                    }
                    else if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X > _closest.Location.X) // Add Right
                    {
                        AddPlusToGrid(_closestX + 8, _closestY);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y < _closest.Location.Y) // Add up
                    {
                        AddPlusToGrid(_closestX, _closestY - 8);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y > _closest.Location.Y) // Add Down
                    {
                        AddPlusToGrid(_closestX, _closestY + 8);
                    }

                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries!");
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

            comparePoints.Add(grid[x][y]);

            foreach (Tile t in tiles)
            {
                grid[t.Position.X][t.Position.Y].BackColor = this.getTileColor(t.Type);
            }

            _intersectionCounter++;
        }

        public void Draw_TIntersectionUp(int x, int y)
        {
            if (_intersectionCounter == 0)
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count)
                {
                    AddT_UpToGrid(x, y);
                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries or already ocupied tiles!");
                }
            }
            else
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count && grid[x][y].BackColor == this.getTileColor(TileType.Empty) && grid[x + 7][y + 7].BackColor == this.getTileColor(TileType.Empty))
                {
                    int _distance;
                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;
                    PictureBox _closest = new PictureBox();

                    int _closestX = 0;
                    int _closestY = 0;

                    foreach (var a in comparePoints)
                    {
                        _distance = Math.Abs(a.Location.X / 21 - grid[x][y].Location.X / 21);

                        if (_distance < _newValueX)
                        {
                            _closestX = a.Location.X / 21;
                        }
                    }

                    foreach (var a in comparePoints)
                    {
                        if (a.Location.X == _closestX * 21)
                        {
                            _distance = Math.Abs(a.Location.Y / 21 - grid[x][y].Location.Y / 21);

                            if (_distance < _newValueX)
                            {
                                _closestY = a.Location.Y / 21;
                                _closest = grid[_closestX][_closestY];
                            }
                        }
                    }


                    if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X < _closest.Location.X) // Add Left
                    {
                        AddT_UpToGrid(_closestX - 8, _closestY);
                    }
                    else if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X > _closest.Location.X) // Add Right
                    {
                        AddT_UpToGrid(_closestX + 8, _closestY);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y < _closest.Location.Y) // Add up
                    {
                        AddT_UpToGrid(_closestX, _closestY - 8);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y > _closest.Location.Y) // Add Down
                    {
                        AddT_UpToGrid(_closestX, _closestY + 8);
                    }

                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries!");
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

            comparePoints.Add(grid[x][y]);

            foreach (Tile t in tiles)
            {
                grid[t.Position.X][t.Position.Y].BackColor = this.getTileColor(t.Type);
            }

            _intersectionCounter++;
        }

        public void Draw_TIntersectionDown(int x, int y)
        {
            if (_intersectionCounter == 0)
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count)
                {
                    AddT_DownToGrid(x, y);
                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries or already ocupied tiles!");
                }
            }
            else
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count && grid[x][y].BackColor == this.getTileColor(TileType.Empty) && grid[x + 7][y + 7].BackColor == this.getTileColor(TileType.Empty))
                {
                    int _distance;
                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;
                    PictureBox _closest = new PictureBox();

                    int _closestX = 0;
                    int _closestY = 0;

                    foreach (var a in comparePoints)
                    {
                        _distance = Math.Abs(a.Location.X / 21 - grid[x][y].Location.X / 21);

                        if (_distance < _newValueX)
                        {
                            _closestX = a.Location.X / 21;
                        }
                    }

                    foreach (var a in comparePoints)
                    {
                        if (a.Location.X == _closestX * 21)
                        {
                            _distance = Math.Abs(a.Location.Y / 21 - grid[x][y].Location.Y / 21);

                            if (_distance < _newValueX)
                            {
                                _closestY = a.Location.Y / 21;
                                _closest = grid[_closestX][_closestY];
                            }
                        }
                    }


                    if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X < _closest.Location.X) // Add Left
                    {
                        AddT_DownToGrid(_closestX - 8, _closestY);
                    }
                    else if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X > _closest.Location.X) // Add Right
                    {
                        AddT_DownToGrid(_closestX + 8, _closestY);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y < _closest.Location.Y) // Add up
                    {
                        AddT_DownToGrid(_closestX, _closestY - 8);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y > _closest.Location.Y) // Add Down
                    {
                        AddT_DownToGrid(_closestX, _closestY + 8);
                    }

                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries!");
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

            comparePoints.Add(grid[x][y]);

            foreach (Tile t in tiles)
            {
                grid[t.Position.X][t.Position.Y].BackColor = this.getTileColor(t.Type);
            }

            _intersectionCounter++;
        }

        public void Draw_TIntersectionLeft(int x, int y)
        {
            if (_intersectionCounter == 0)
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count)
                {
                    AddT_LeftToGrid(x, y);
                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries or already ocupied tiles!");
                }
            }
            else
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count && grid[x][y].BackColor == this.getTileColor(TileType.Empty) && grid[x + 7][y + 7].BackColor == this.getTileColor(TileType.Empty))
                {
                    int _distance;
                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;
                    PictureBox _closest = new PictureBox();

                    int _closestX = 0;
                    int _closestY = 0;

                    foreach (var a in comparePoints)
                    {
                        _distance = Math.Abs(a.Location.X / 21 - grid[x][y].Location.X / 21);

                        if (_distance < _newValueX)
                        {
                            _closestX = a.Location.X / 21;
                        }
                    }

                    foreach (var a in comparePoints)
                    {
                        if (a.Location.X == _closestX * 21)
                        {
                            _distance = Math.Abs(a.Location.Y / 21 - grid[x][y].Location.Y / 21);

                            if (_distance < _newValueX)
                            {
                                _closestY = a.Location.Y / 21;
                                _closest = grid[_closestX][_closestY];
                            }
                        }
                    }


                    if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X < _closest.Location.X) // Add Left
                    {
                        AddT_LeftToGrid(_closestX - 8, _closestY);
                    }
                    else if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X > _closest.Location.X) // Add Right
                    {
                        AddT_LeftToGrid(_closestX + 8, _closestY);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y < _closest.Location.Y) // Add up
                    {
                        AddT_LeftToGrid(_closestX, _closestY - 8);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y > _closest.Location.Y) // Add Down
                    {
                        AddT_LeftToGrid(_closestX, _closestY + 8);
                    }

                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries!");
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

            comparePoints.Add(grid[x][y]);

            foreach (Tile t in tiles)
            {
                grid[t.Position.X][t.Position.Y].BackColor = this.getTileColor(t.Type);
            }

            _intersectionCounter++;
        }

        public void Draw_TIntersectionRight(int x, int y)
        {
            if (_intersectionCounter == 0)
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count)
                {
                    AddT_LeftToGrid(x, y);
                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries or already ocupied tiles!");
                }
            }
            else
            {
                if (x + 7 < grid[0].Count && y + 7 < grid.Count && grid[x][y].BackColor == this.getTileColor(TileType.Empty) && grid[x + 7][y + 7].BackColor == this.getTileColor(TileType.Empty))
                {
                    int _distance;
                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;
                    PictureBox _closest = new PictureBox();

                    int _closestX = 0;
                    int _closestY = 0;

                    foreach (var a in comparePoints)
                    {
                        _distance = Math.Abs(a.Location.X / 21 - grid[x][y].Location.X / 21);

                        if (_distance < _newValueX)
                        {
                            _closestX = a.Location.X / 21;
                        }
                    }

                    foreach (var a in comparePoints)
                    {
                        if (a.Location.X == _closestX * 21)
                        {
                            _distance = Math.Abs(a.Location.Y / 21 - grid[x][y].Location.Y / 21);

                            if (_distance < _newValueX)
                            {
                                _closestY = a.Location.Y / 21;
                                _closest = grid[_closestX][_closestY];
                            }
                        }
                    }


                    if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X < _closest.Location.X) // Add Left
                    {
                        AddT_LeftToGrid(_closestX - 8, _closestY);
                    }
                    else if (grid[x][y].Location.Y >= _closest.Location.Y && grid[x][y].Location.Y < _closest.Location.Y + 8 && grid[x][y].Location.X > _closest.Location.X) // Add Right
                    {
                        AddT_LeftToGrid(_closestX + 8, _closestY);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y < _closest.Location.Y) // Add up
                    {
                        AddT_LeftToGrid(_closestX, _closestY - 8);
                    }
                    else if (grid[x][y].Location.X >= _closest.Location.X &&
                             grid[x][y].Location.X < _closest.Location.X + 8 &&
                             grid[x][y].Location.Y > _closest.Location.Y) // Add Down
                    {
                        AddT_LeftToGrid(_closestX, _closestY + 8);
                    }

                }
                else
                {
                    MessageBox.Show("Construction denied! Out of boundaries!");
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
                    if (a >= x + 5 && a < x + 8)
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

                    if (b == x + 3 || b == x + 4)
                    {
                        tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                    }

                    if (a >= x && a <= x + 3)
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }
                }
            }

            comparePoints.Add(grid[x][y]);

            foreach (Tile t in tiles)
            {
                grid[t.Position.X][t.Position.Y].BackColor = this.getTileColor(t.Type);
            }

            _intersectionCounter++;
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

