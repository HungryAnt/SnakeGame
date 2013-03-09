using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodsSnakeGame.Game;

namespace GodsSnakeGame
{
    public partial class FormSnakeGame : Form
    {
        public FormSnakeGame()
        {
            InitializeComponent();
        }

        SnakeGame _game = new SnakeGame();
        SnakeMoveDirection _snakeDirection;

        private void FormSnakeGame_Load(object sender, EventArgs e)
        {
            _game.DisplayRectangle = labelSnakeScene.ClientRectangle;
            _game.Start();
            timerSnakeMove.Start();
        }

//         private void panelScene_Paint(object sender, PaintEventArgs e)
//         {
//             _game.Draw(e.Graphics);
//         }
// 
//         private void panelScene_Resize(object sender, EventArgs e)
//         {
//             _game.DisplayRectangle = panelScene.ClientRectangle;
//             Invalidate();
//         }

        private void FormSnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _snakeDirection = SnakeMoveDirection.Left;
                    break;
                case Keys.Right:
                    _snakeDirection = SnakeMoveDirection.Right;
                    break;
                case Keys.Up:
                    _snakeDirection = SnakeMoveDirection.Up;
                    break;
                case Keys.Down:
                    _snakeDirection = SnakeMoveDirection.Down;
                    break;
            }
        }

        private void timerSnakeMove_Tick(object sender, EventArgs e)
        {
            _game.SnakeMove(_snakeDirection);
            //Invalidate(true);
            labelSnakeScene.Invalidate();
        }

        private void labelSnakeScene_Paint(object sender, PaintEventArgs e)
        {
            _game.Draw(e.Graphics);
        }

        private void labelSnakeScene_Resize(object sender, EventArgs e)
        {
            _game.DisplayRectangle = labelSnakeScene.ClientRectangle;
            labelSnakeScene.Invalidate();
        }
    }
}
