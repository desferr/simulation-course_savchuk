namespace Lab3
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            button4 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            numericUpDown3 = new NumericUpDown();
            label2 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton3 = new RadioButton();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(600, 600);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(618, 15);
            button1.Name = "button1";
            button1.Size = new Size(184, 58);
            button1.TabIndex = 1;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(618, 79);
            button2.Name = "button2";
            button2.Size = new Size(184, 58);
            button2.TabIndex = 2;
            button2.Text = "Стоп";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 15F);
            button3.Location = new Point(618, 143);
            button3.Name = "button3";
            button3.Size = new Size(184, 58);
            button3.TabIndex = 3;
            button3.Text = "Шаг";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(618, 271);
            numericUpDown1.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(86, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(716, 271);
            numericUpDown2.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(86, 23);
            numericUpDown2.TabIndex = 5;
            numericUpDown2.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 15F);
            button4.Location = new Point(618, 207);
            button4.Name = "button4";
            button4.Size = new Size(184, 58);
            button4.TabIndex = 6;
            button4.Text = "Огонь";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(618, 297);
            label1.Name = "label1";
            label1.Size = new Size(114, 28);
            label1.TabIndex = 7;
            label1.Text = "Влажность:";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(734, 302);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(68, 23);
            numericUpDown3.TabIndex = 8;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(618, 328);
            label2.Name = "label2";
            label2.Size = new Size(162, 28);
            label2.TabIndex = 9;
            label2.Text = "Выбранный тип:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 15F);
            radioButton1.Location = new Point(618, 359);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(83, 32);
            radioButton1.TabIndex = 10;
            radioButton1.TabStop = true;
            radioButton1.Text = "Трава";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 15F);
            radioButton2.Location = new Point(618, 397);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(62, 32);
            radioButton2.TabIndex = 11;
            radioButton2.TabStop = true;
            radioButton2.Text = "Лес";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI", 15F);
            radioButton4.Location = new Point(618, 473);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(74, 32);
            radioButton4.TabIndex = 13;
            radioButton4.TabStop = true;
            radioButton4.Text = "Вода";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Font = new Font("Segoe UI", 15F);
            radioButton5.Location = new Point(618, 511);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(105, 32);
            radioButton5.TabIndex = 14;
            radioButton5.TabStop = true;
            radioButton5.Text = "Молния";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI", 15F);
            radioButton3.Location = new Point(618, 435);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(87, 32);
            radioButton3.TabIndex = 15;
            radioButton3.TabStop = true;
            radioButton3.Text = "Огонь";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Yellow;
            panel2.Location = new Point(702, 367);
            panel2.Name = "panel2";
            panel2.Size = new Size(21, 21);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Green;
            panel3.Location = new Point(680, 405);
            panel3.Name = "panel3";
            panel3.Size = new Size(21, 21);
            panel3.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.Location = new Point(702, 443);
            panel4.Name = "panel4";
            panel4.Size = new Size(21, 21);
            panel4.TabIndex = 18;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Blue;
            panel5.Location = new Point(691, 481);
            panel5.Name = "panel5";
            panel5.Size = new Size(21, 21);
            panel5.TabIndex = 19;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Purple;
            panel6.Location = new Point(719, 519);
            panel6.Name = "panel6";
            panel6.Size = new Size(21, 21);
            panel6.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 621);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(radioButton3);
            Controls.Add(radioButton5);
            Controls.Add(radioButton4);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label2);
            Controls.Add(numericUpDown3);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(830, 660);
            MinimumSize = new Size(830, 660);
            Name = "Form1";
            Text = "Lab3";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Button button4;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private NumericUpDown numericUpDown3;
        private Label label2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton3;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
    }
}
