namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.label_Prompt1 = new System.Windows.Forms.Label();
            this.lblBombsRemaining = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(217, 69);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(600, 600);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // label_Prompt1
            // 
            this.label_Prompt1.AutoSize = true;
            this.label_Prompt1.Location = new System.Drawing.Point(217, 27);
            this.label_Prompt1.Name = "label_Prompt1";
            this.label_Prompt1.Size = new System.Drawing.Size(83, 17);
            this.label_Prompt1.TabIndex = 1;
            this.label_Prompt1.Text = "Bombs Left:";
            // 
            // lblBombsRemaining
            // 
            this.lblBombsRemaining.AutoSize = true;
            this.lblBombsRemaining.Location = new System.Drawing.Point(307, 27);
            this.lblBombsRemaining.Name = "lblBombsRemaining";
            this.lblBombsRemaining.Size = new System.Drawing.Size(0, 17);
            this.lblBombsRemaining.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 672);
            this.Controls.Add(this.lblBombsRemaining);
            this.Controls.Add(this.label_Prompt1);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label label_Prompt1;
        private System.Windows.Forms.Label lblBombsRemaining;
    }
}

