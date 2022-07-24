using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public static Board myBoard = new Board(8);
        public Button[,] buttonGrid = new Button[myBoard.Size, myBoard.Size];
        public int queenCount = 0;
        public Form1()
        {
            InitializeComponent();
            displayBoard();
        }
        public void displayBoard()
        {
            int buttonSize = 50;
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {

                    buttonGrid[i, j] = new Button();
                    buttonGrid[i, j].Height = buttonSize;
                    buttonGrid[i, j].Width = buttonSize;

                    buttonGrid[i, j].MouseDown += panel1_MouseDown;


                    buttonGrid[i, j].Click += Grid_Button_Click;
                    buttonGrid[i, j].Click += checkBox1_CheckedChanged;

                    panel1.Controls.Add(buttonGrid[i, j]);

                    buttonGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    if ((i + j) % 2 == 0)
                    {
                        buttonGrid[i, j].BackColor = Color.White;
                        buttonGrid[i, j].ForeColor = Color.Black;
                    }
                    else if ((i + j) % 2 == 1)
                    {
                        buttonGrid[i, j].BackColor = Color.Black;
                        buttonGrid[i, j].ForeColor = Color.White;
                    }

                    buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    buttonGrid[i, j].FlatAppearance.BorderColor = Color.Black;

                    buttonGrid[i, j].Tag = new Point(i, j);
                }
            }
        }

        public void Grid_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            cell currentCell = myBoard.Grid[x, y];

            if (currentCell.Occupied == false)
            {
                clickedButton.Text = "Q";
            }

            if (myBoard.Grid[x, y].Occupied == true)
            {
                clickedButton.Enabled = false;
                System.Media.SystemSounds.Beep.Play();
            }

            if (myBoard.Grid[x, y].Occupied == false)
            {
                myBoard.MarknextLegalMoves(currentCell);
                queenCount++;
                if (queenCount == 8)
                {
                    MessageBox.Show("You did it!");
                }
                label1.Text = "you have " + queenCount + "  Queens on the board";
            }
        }

        public class cell
        {
            public int RowNum { get; set; }
            public int ColumnNum { get; set; }
            public bool Occupied { get; set; }
            public bool LegalNextMove { get; set; }

            public cell(int x, int y)
            {
                RowNum = x;
                ColumnNum = y;
            }

        }

        public class Board
        {
            //Initial Board size
            public int Size { get; set; }
            //2D array
            public cell[,] Grid { get; set; }

            //constructor
            public Board(int s)
            {
                Size = s;
                Grid = new cell[Size, Size];

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Grid[i, j] = new cell(i, j);
                        Grid[i, j].Occupied = false;
                    }
                }

            }

            public void MarknextLegalMoves(cell currentCell)
            {
                //move queen in the rows +
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.RowNum + i > 7)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum + i, currentCell.ColumnNum + 0].Occupied = true;
                    }
                }
                //Move queen in rows -
                for (int i = 0; i < 8; i++)
                {

                    if (currentCell.RowNum - i < 0)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum - i, currentCell.ColumnNum + 0].Occupied = true;
                    }

                }
                //move queen in columns +
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.ColumnNum + i > 7)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum + 0, currentCell.ColumnNum + i].Occupied = true;
                    }
                }
                //Move queens in columns -
                for (int i = 0; i < 8; i++)
                {

                    if (currentCell.ColumnNum - i < 0)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum, currentCell.ColumnNum - i].Occupied = true;
                    }

                }
                //move queen diagonally +/+

                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.RowNum + i > 7 || currentCell.ColumnNum + i > 7)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum + i, currentCell.ColumnNum + i].Occupied = true;
                    }
                }
                //Move Queen diagonally -/-
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.RowNum - i < 0 || currentCell.ColumnNum - i < 0)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum - i, currentCell.ColumnNum - i].Occupied = true;
                    }
                }
                //Move Queen Diagonally +/-
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.RowNum + i > 7 || currentCell.ColumnNum - i < 0)
                        break;
                    else
                    {
                        Grid[currentCell.RowNum + i, currentCell.ColumnNum - i].Occupied = true;
                    }
                }
                //move queen diagonally -/+
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.ColumnNum + i > 7 || currentCell.RowNum - i < 0)
                        break;
                    else
                    {
                        Grid[currentCell.RowNum - i, currentCell.ColumnNum + i].Occupied = true;
                    }
                }

            }
            public void ReverseMarknextLegalMoves(cell currentCell)
            {
                //issue is that when I call this function it marks grids that are true to false
                //move queen in the rows +
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.RowNum + i > 7)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum + i, currentCell.ColumnNum + 0].Occupied = false;
                    }
                }
                //Move queen in rows -
                for (int i = 0; i < 8; i++)
                {

                    if (currentCell.RowNum - i < 0)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum - i, currentCell.ColumnNum + 0].Occupied = false;
                    }

                }

                //move queen in columns +
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.ColumnNum + i > 7)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum + 0, currentCell.ColumnNum + i].Occupied = false;
                    }
                }

                //Move queens in columns -
                for (int i = 0; i < 8; i++)
                {

                    if (currentCell.ColumnNum - i < 0)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum, currentCell.ColumnNum - i].Occupied = false;
                    }

                }

                //move queen diagonally +/+

                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.RowNum + i > 7 || currentCell.ColumnNum + i > 7)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum + i, currentCell.ColumnNum + i].Occupied = false;
                    }
                }
                //Move Queen diagonally -/-
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.RowNum - i < 0 || currentCell.ColumnNum - i < 0)
                    {
                        break;
                    }
                    else
                    {
                        Grid[currentCell.RowNum - i, currentCell.ColumnNum - i].Occupied = false;
                    }
                }
                //Move Queen Diagonally +/-
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.RowNum + i > 7 || currentCell.ColumnNum - i < 0)
                        break;
                    else
                    {
                        Grid[currentCell.RowNum + i, currentCell.ColumnNum - i].Occupied = false;
                    }
                }

                //move queen diagonally -/+
                for (int i = 0; i < 8; i++)
                {
                    if (currentCell.ColumnNum + i > 7 || currentCell.RowNum - i < 0)
                        break;
                    else
                    {
                        Grid[currentCell.RowNum - i, currentCell.ColumnNum + i].Occupied = false;
                    }
                }
            }
        }









        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < myBoard.Size; i++)
                {
                    for (int j = 0; j < myBoard.Size; j++)
                    {
                        if (myBoard.Grid[i, j].Occupied == true)
                        {
                            buttonGrid[i, j].BackColor = Color.Red;
                            buttonGrid[i, j].ForeColor = Color.Black;
                        }
                    }
                }
            }

            else if (!checkBox1.Checked)
            {
                for (int i = 0; i < myBoard.Size; i++)
                {
                    for (int j = 0; j < myBoard.Size; j++)
                        if ((i + j) % 2 == 0)
                        {
                            buttonGrid[i, j].BackColor = Color.White;
                            buttonGrid[i, j].ForeColor = Color.Black;
                        }
                        else if ((i + j) % 2 == 1)
                        {
                            buttonGrid[i, j].BackColor = Color.Black;
                            buttonGrid[i, j].ForeColor = Color.White;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queenCount = 0;
            label1.Text = "you have " + queenCount + "  Queens on the board";
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    buttonGrid[i, j].Enabled = true;
                    myBoard.Grid[i, j].Occupied = false;
                    buttonGrid[i, j].Text = "";
                    if ((i + j) % 2 == 0)
                    {
                        buttonGrid[i, j].BackColor = Color.White;
                        buttonGrid[i, j].ForeColor = Color.Black;
                    }
                    else if ((i + j) % 2 == 1)
                    {
                        buttonGrid[i, j].BackColor = Color.Black;
                        buttonGrid[i, j].ForeColor = Color.White;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = " 8 Queens by Kfir Flank";
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    Button clickedButton = (Button)sender;
                    Point location = (Point)clickedButton.Tag;

                    int x = location.X;
                    int y = location.Y;
                    cell currentCell = myBoard.Grid[x, y];

                    if (clickedButton.Text == "Q")
                    {
                        buttonGrid[x, y].Text = "";
                        queenCount--;
                        label1.Text = "you have " + queenCount + "  Queens on the board";
                        myBoard.ReverseMarknextLegalMoves(currentCell);
                        for (int i = 0; i < myBoard.Size; i++)
                        {
                            for (int j = 0; j < myBoard.Size; j++)
                            {
                                if (myBoard.Grid[i, j].Occupied == false)
                                {
                                    checkBox1_CheckedChanged(sender, e);
                                    if ((i + j) % 2 == 0)
                                    {
                                        buttonGrid[i, j].BackColor = Color.White;
                                        buttonGrid[i, j].ForeColor = Color.Black;
                                    }
                                    else if ((i + j) % 2 == 1)
                                    {
                                        buttonGrid[i, j].BackColor = Color.Black;
                                        buttonGrid[i, j].ForeColor = Color.White;
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (buttonGrid[i, j].Text == "Q")
                                {
                                    buttonGrid[i, j].BackColor = Color.Green;
                                    myBoard.MarknextLegalMoves(myBoard.Grid[i, j]);
                                    checkBox1_CheckedChanged(sender, e);
                                }
                            }
                        }

                    }
                }
                catch (System.InvalidCastException)
                {
                    MessageBox.Show("click inside the grid area");
                }
            }
        }

       
    }


}
