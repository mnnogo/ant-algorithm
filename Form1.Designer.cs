namespace AntAlgorithm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            drawPanel = new Panel();
            resetButton = new Button();
            startButton = new Button();
            aTextBox = new TextBox();
            bTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            qTextBox = new TextBox();
            label4 = new Label();
            pTextBox = new TextBox();
            label5 = new Label();
            startingPheramoneTextBox = new TextBox();
            label6 = new Label();
            roadLengthTextBox = new TextBox();
            SuspendLayout();
            // 
            // drawPanel
            // 
            drawPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            drawPanel.BackColor = SystemColors.ControlLightLight;
            drawPanel.Location = new Point(168, 0);
            drawPanel.Name = "drawPanel";
            drawPanel.Size = new Size(657, 603);
            drawPanel.TabIndex = 0;
            drawPanel.MouseDoubleClick += drawPanel_MouseDoubleClick;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(12, 304);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(150, 23);
            resetButton.TabIndex = 1;
            resetButton.Text = "Стереть поле";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(12, 275);
            startButton.Name = "startButton";
            startButton.Size = new Size(150, 23);
            startButton.TabIndex = 2;
            startButton.Text = "Запустить";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // aTextBox
            // 
            aTextBox.Location = new Point(12, 33);
            aTextBox.Name = "aTextBox";
            aTextBox.Size = new Size(134, 23);
            aTextBox.TabIndex = 3;
            aTextBox.Text = "1";
            // 
            // bTextBox
            // 
            bTextBox.Location = new Point(12, 82);
            bTextBox.Name = "bTextBox";
            bTextBox.Size = new Size(134, 23);
            bTextBox.TabIndex = 4;
            bTextBox.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(135, 15);
            label1.TabIndex = 5;
            label1.Text = "Значимость феромона";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(128, 15);
            label2.TabIndex = 6;
            label2.Text = "Значимость близости";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 8;
            label3.Text = "Коэффициент Q";
            // 
            // qTextBox
            // 
            qTextBox.Location = new Point(12, 135);
            qTextBox.Name = "qTextBox";
            qTextBox.Size = new Size(134, 23);
            qTextBox.TabIndex = 7;
            qTextBox.Text = "4";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 171);
            label4.Name = "label4";
            label4.Size = new Size(129, 15);
            label4.TabIndex = 10;
            label4.Text = "Испарение феромона";
            // 
            // pTextBox
            // 
            pTextBox.Location = new Point(12, 189);
            pTextBox.Name = "pTextBox";
            pTextBox.Size = new Size(134, 23);
            pTextBox.TabIndex = 9;
            pTextBox.Text = "0,6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 224);
            label5.Name = "label5";
            label5.Size = new Size(126, 15);
            label5.TabIndex = 12;
            label5.Text = "Начальный феромон";
            // 
            // startingPheramoneTextBox
            // 
            startingPheramoneTextBox.Location = new Point(12, 242);
            startingPheramoneTextBox.Name = "startingPheramoneTextBox";
            startingPheramoneTextBox.Size = new Size(134, 23);
            startingPheramoneTextBox.TabIndex = 11;
            startingPheramoneTextBox.Text = "0,2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(46, 484);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 13;
            label6.Text = "Длина пути:";
            // 
            // roadLengthTextBox
            // 
            roadLengthTextBox.Font = new Font("Segoe UI", 10F);
            roadLengthTextBox.Location = new Point(29, 502);
            roadLengthTextBox.Name = "roadLengthTextBox";
            roadLengthTextBox.ReadOnly = true;
            roadLengthTextBox.Size = new Size(108, 25);
            roadLengthTextBox.TabIndex = 14;
            roadLengthTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(824, 601);
            Controls.Add(roadLengthTextBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(startingPheramoneTextBox);
            Controls.Add(label4);
            Controls.Add(pTextBox);
            Controls.Add(label3);
            Controls.Add(qTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bTextBox);
            Controls.Add(aTextBox);
            Controls.Add(startButton);
            Controls.Add(resetButton);
            Controls.Add(drawPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(840, 640);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Алгоритм муравья в задаче Коммивояжера";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel drawPanel;
        private Button resetButton;
        private Button startButton;
        private TextBox aTextBox;
        private TextBox bTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox qTextBox;
        private Label label4;
        private TextBox pTextBox;
        private Label label5;
        private TextBox startingPheramoneTextBox;
        private Label label6;
        private TextBox roadLengthTextBox;
    }
}
