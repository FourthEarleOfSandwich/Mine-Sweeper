using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    public class Grid
    {
        public Grid(PictureBox passedCanvas)
        {
            Surface = passedCanvas;
            
            fillData();
        }
        public bool[,] data;
        public int[,] space;
        public bool[,] flag;
        public int dimension = 14;
        public int bombcount;
        public PictureBox Surface;

        
        public int CellWidth
        {
            get 
            {
                int w = Surface.Width;
                int dim = data.GetLength(0);
                int width = w / dim;
                return width;
            }
        }
        private void fillData()
        {
            data = new bool[dimension, dimension];
            
        }
       
        public void DrawGrid(PaintEventArgs e)
        {
            SolidBrush brushInactive = new SolidBrush(Color.Black);
            SolidBrush brushActive = new SolidBrush(Color.Gray);
            SolidBrush brushOne = new SolidBrush(Color.Blue);
            SolidBrush brushTwo = new SolidBrush(Color.Green);
            SolidBrush brushThree = new SolidBrush(Color.OrangeRed);
            SolidBrush brushFour = new SolidBrush(Color.Purple);
            SolidBrush brushFive = new SolidBrush(Color.Maroon);
            SolidBrush FlagBrush = new SolidBrush(Color.Magenta);
            SolidBrush Transparent = new SolidBrush(Color.Transparent);
            SolidBrush currentBrush;
            SolidBrush NumberColor;
            string Number;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            
            int margin = 1;
            FontFamily fontFamily = new FontFamily("Arial");
            int fontsize = CellWidth / 2;
            Font chosenfont = new Font(fontFamily, fontsize, FontStyle.Regular);
            for (int ii = 0; ii < data.GetLength(1); ii++)
            {
                for (int jj = 0; jj < data.GetLength(0); jj++)
                {
                    int x = jj * CellWidth + margin;
                    int y = ii * CellWidth + margin;
                    int w = CellWidth - margin * 2;
                    currentBrush = brushActive;
                    if (data[ii, jj] && this.space[ii, jj] == 0)
                    {
                        e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));

                    }
                    else if (data[ii, jj] && this.space[ii, jj] == 1)
                    {
                        Number = " 1";
                        NumberColor = brushOne;
                        e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));
                        e.Graphics.DrawString(Number, chosenfont, NumberColor, x, y);
                    }
                    else if (data[ii, jj] && this.space[ii, jj] == 2)
                    {
                        Number = " 2";
                        NumberColor = brushTwo;
                        e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));
                        e.Graphics.DrawString(Number, chosenfont, NumberColor, x, y);
                    }
                    else if (data[ii, jj] && this.space[ii, jj] == 3)
                    {
                        Number = " 3";
                        NumberColor = brushThree;
                        e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));
                        e.Graphics.DrawString(Number, chosenfont, NumberColor, x, y);
                    }
                    else if (data[ii, jj] && this.space[ii, jj] == 4)
                    {
                        Number = " 4";
                        NumberColor = brushFour;
                        e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));
                        e.Graphics.DrawString(Number, chosenfont, NumberColor, x, y);
                    }
                    else if (data[ii, jj] && this.space[ii, jj] == 5)
                    {
                        Number = " 5";
                        NumberColor = brushFive;
                        e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));
                        e.Graphics.DrawString(Number, chosenfont, NumberColor, x, y);
                    } 
                    else
                    {
                        currentBrush = brushInactive;
                        e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));
                        
                    }
                     
                    
                        
                    if (this.flag[ii, jj])
                        e.Graphics.FillEllipse(FlagBrush, new Rectangle(x, y, w, w));
                }
                
                
            }
            
            
            //SolidBrush currentBrush;

            
        }
       
        
        public int CalcCellPosition(int loc)
        {
            return (int)((double)loc / CellWidth);
        }
        public void UpdateGUI()
        {
            Surface.Refresh();
        }
        public void MakeFalse(int r, int c)
        {
            data[r, c] = true;
        }
    }
}
