namespace GodsSnakeGame
{
    partial class FormSnakeGame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerSnakeMove = new System.Windows.Forms.Timer(this.components);
            this.labelSnakeScene = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerSnakeMove
            // 
            this.timerSnakeMove.Tick += new System.EventHandler(this.timerSnakeMove_Tick);
            // 
            // labelSnakeScene
            // 
            this.labelSnakeScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeScene.Location = new System.Drawing.Point(0, 0);
            this.labelSnakeScene.Name = "labelSnakeScene";
            this.labelSnakeScene.Size = new System.Drawing.Size(570, 300);
            this.labelSnakeScene.TabIndex = 1;
            this.labelSnakeScene.Paint += new System.Windows.Forms.PaintEventHandler(this.labelSnakeScene_Paint);
            this.labelSnakeScene.Resize += new System.EventHandler(this.labelSnakeScene_Resize);
            // 
            // FormSnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(570, 300);
            this.Controls.Add(this.labelSnakeScene);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "FormSnakeGame";
            this.Text = "Snake  - by Gods";
            this.Load += new System.EventHandler(this.FormSnakeGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSnakeGame_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerSnakeMove;
        private System.Windows.Forms.Label labelSnakeScene;
    }
}

