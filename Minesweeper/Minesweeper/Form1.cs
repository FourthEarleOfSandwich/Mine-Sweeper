using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Grid Grid1;
        
        //int[,] Grid1.space;
        //private bool[,] data;

        public Form1()
        {
            InitializeComponent();
            Grid1 = new Grid(canvas);
            Grid1.bombcount = 10;
            //Grid1.dimension = 30;
            Grid1.space = new int[Grid1.dimension, Grid1.dimension];
            Grid1.flag = new bool[Grid1.dimension, Grid1.dimension];

            PlaceBombs();
            MakeBlankSpaces();
            MakeProximityNumbers();
            CountRemainingBombs();

        }

        private void PlaceBombs()
        {
            int xCoordinate;
            int yCoordinate;
            Random Rand = new Random();
            for (int x = 1; x <= Grid1.bombcount; x++)
            {
                xCoordinate = Rand.Next(0, Grid1.dimension);
                yCoordinate = Rand.Next(0, Grid1.dimension);
                if (Grid1.space[xCoordinate, yCoordinate] != -1)
                {
                    Grid1.space[xCoordinate, yCoordinate] = -1;
                }
                else
                {
                    x -= 1;
                }
            }
        }
        
        private void MakeBlankSpaces()
        {
            for (int ii = 0; ii < Grid1.dimension; ii++)
            {
                for (int jj = 0; jj < Grid1.dimension; jj++)
                {
                    if (Grid1.space[jj, ii] != -1)
                    {
                        Grid1.space[jj, ii] = 0;
                    }
                }
            }
        }


        private void MakeProximityNumbers()
        {
            for (int ii = 0; ii < Grid1.dimension; ii++)
            {
                for (int jj = 0; jj < Grid1.dimension; jj++)
                {
                    if (Grid1.space[jj, ii] == -1)
                    {
                        for (int y = ii - 1; y <= ii + 1; y++)
                        {
                            for (int x = jj - 1; x <= jj + 1; x++)
                            {
                                if(x < 0 || x >= Grid1.dimension)
                                {
                                    continue;
                                }
                                if(y < 0 || y >= Grid1.dimension)
                                {
                                    continue;
                                }
                                if (Grid1.space[x, y] != -1)
                                {
                                    Grid1.space[x, y] += 1;
                                }
                            }
                        }
                    }
                } 
            }
        }
        private void CheckIfWin()
        {
            int x = 0;
            for(int ii = 0; ii < Grid1.dimension; ii++)
            {
                for (int jj = 0; jj < Grid1.dimension; jj++)
                {
                    if (Grid1.data[jj, ii] == false)
                    {
                        x += 1;
                    }
                    if (Grid1.flag[jj, ii] && Grid1.data[jj, ii])
                    {
                        Grid1.flag[jj, ii] = !Grid1.flag[jj, ii];
                    }
                }
            }
            if (x == Grid1.bombcount)
            {
                MessageBox.Show("You Win");
            }
            
               
        }
        private void CountRemainingBombs()
        {
            int x = 0;
            for (int ii = 0; ii < Grid1.dimension; ii++)
            {
                for (int jj = 0; jj < Grid1.dimension; jj++)
                {
                    if(Grid1.flag[jj,ii] == true)
                    {
                        x += 1;
                        
                    }
                }
            }
            lblBombsRemaining.Text = ((Grid1.bombcount - x).ToString());
        }
        private void OpenGrid(int X, int Y)
        {
            if(X >= 0 && X < Grid1.dimension && Y >= 0 && Y < Grid1.dimension && !Grid1.data[X,Y])
            {
                if(Grid1.space[X,Y] == -1)
                {
                    MessageBox.Show("You Lose");
                    Application.Exit();
                }
                else if (Grid1.space[X,Y] == 0)
                {
                    Grid1.MakeFalse(X, Y);
                    
                    OpenGrid(X + 1, Y);
                    OpenGrid(X - 1, Y);
                    OpenGrid(X, Y + 1);
                    OpenGrid(X, Y - 1);
                }
                else
                {
                    Grid1.MakeFalse(X, Y);
                }
            }
        }
        private void PlaceFlag(int X, int Y)
        {
            if(!Grid1.data[X,Y])
            Grid1.flag[X, Y] = !Grid1.flag[X,Y];
        }

       // private bool[,] data;

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) 
            {
                int r = Grid1.CalcCellPosition(e.Location.Y);
                int c = Grid1.CalcCellPosition(e.Location.X);
                PlaceFlag(r, c);
                CountRemainingBombs();
                //CheckIfWin();
                Grid1.UpdateGUI();

                

            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int r = Grid1.CalcCellPosition(e.Location.Y);
                int c = Grid1.CalcCellPosition(e.Location.X);
                //Grid1.MakeFalse(r, c);
                if (!Grid1.flag[r,c])
                    OpenGrid(r, c);
                CheckIfWin();
                Grid1.UpdateGUI();
                CountRemainingBombs();
            }
            

        }
        
       
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Grid1.DrawGrid(e);
        }
    }
}
