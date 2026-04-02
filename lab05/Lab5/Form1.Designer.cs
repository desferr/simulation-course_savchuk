namespace Lab5
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabControlChoseMode = new TabControl();
            tabPageYesNo = new TabPage();
            checkBoxTextToSeedYesNo = new CheckBox();
            labelYesNo = new Label();
            textBoxYesNo = new TextBox();
            buttonAskYesNo = new Button();
            tabPageEightBall = new TabPage();
            checkBoxTextToSeedEightBall = new CheckBox();
            labelEightBall = new Label();
            buttonAskEightBall = new Button();
            textBoxEightBall = new TextBox();
            tabPage1 = new TabPage();
            checkBoxTextToSeedCustom = new CheckBox();
            labelCustom = new Label();
            buttonAskCustom = new Button();
            textBoxCustom = new TextBox();
            tabPage2 = new TabPage();
            dataGridViewCustom = new DataGridView();
            Probability = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            contextMenuStripDataGridViewCustom = new ContextMenuStrip(components);
            deleteRowToolStripMenuItem = new ToolStripMenuItem();
            tabControlChoseMode.SuspendLayout();
            tabPageYesNo.SuspendLayout();
            tabPageEightBall.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustom).BeginInit();
            contextMenuStripDataGridViewCustom.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlChoseMode
            // 
            tabControlChoseMode.Controls.Add(tabPageYesNo);
            tabControlChoseMode.Controls.Add(tabPageEightBall);
            tabControlChoseMode.Controls.Add(tabPage1);
            tabControlChoseMode.Controls.Add(tabPage2);
            tabControlChoseMode.Dock = DockStyle.Fill;
            tabControlChoseMode.Font = new Font("Segoe UI", 9F);
            tabControlChoseMode.Location = new Point(0, 0);
            tabControlChoseMode.Name = "tabControlChoseMode";
            tabControlChoseMode.SelectedIndex = 0;
            tabControlChoseMode.Size = new Size(584, 361);
            tabControlChoseMode.TabIndex = 0;
            // 
            // tabPageYesNo
            // 
            tabPageYesNo.Controls.Add(checkBoxTextToSeedYesNo);
            tabPageYesNo.Controls.Add(labelYesNo);
            tabPageYesNo.Controls.Add(textBoxYesNo);
            tabPageYesNo.Controls.Add(buttonAskYesNo);
            tabPageYesNo.Location = new Point(4, 24);
            tabPageYesNo.Name = "tabPageYesNo";
            tabPageYesNo.Padding = new Padding(3);
            tabPageYesNo.Size = new Size(576, 333);
            tabPageYesNo.TabIndex = 0;
            tabPageYesNo.Text = "Да-Нет";
            tabPageYesNo.UseVisualStyleBackColor = true;
            // 
            // checkBoxTextToSeedYesNo
            // 
            checkBoxTextToSeedYesNo.AutoSize = true;
            checkBoxTextToSeedYesNo.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxTextToSeedYesNo.Font = new Font("Segoe UI", 15F);
            checkBoxTextToSeedYesNo.Location = new Point(440, 298);
            checkBoxTextToSeedYesNo.Name = "checkBoxTextToSeedYesNo";
            checkBoxTextToSeedYesNo.Size = new Size(128, 32);
            checkBoxTextToSeedYesNo.TabIndex = 3;
            checkBoxTextToSeedYesNo.Text = "TextToSeed";
            checkBoxTextToSeedYesNo.UseVisualStyleBackColor = true;
            // 
            // labelYesNo
            // 
            labelYesNo.Font = new Font("Segoe UI", 20F);
            labelYesNo.Location = new Point(238, 230);
            labelYesNo.Name = "labelYesNo";
            labelYesNo.Size = new Size(100, 37);
            labelYesNo.TabIndex = 2;
            labelYesNo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxYesNo
            // 
            textBoxYesNo.Font = new Font("Segoe UI", 15F);
            textBoxYesNo.Location = new Point(88, 80);
            textBoxYesNo.Name = "textBoxYesNo";
            textBoxYesNo.Size = new Size(400, 34);
            textBoxYesNo.TabIndex = 1;
            // 
            // buttonAskYesNo
            // 
            buttonAskYesNo.Font = new Font("Segoe UI", 15F);
            buttonAskYesNo.Location = new Point(198, 120);
            buttonAskYesNo.Name = "buttonAskYesNo";
            buttonAskYesNo.Size = new Size(180, 39);
            buttonAskYesNo.TabIndex = 0;
            buttonAskYesNo.Text = "Спросить";
            buttonAskYesNo.UseVisualStyleBackColor = true;
            buttonAskYesNo.Click += buttonAskYesNo_Click;
            // 
            // tabPageEightBall
            // 
            tabPageEightBall.Controls.Add(checkBoxTextToSeedEightBall);
            tabPageEightBall.Controls.Add(labelEightBall);
            tabPageEightBall.Controls.Add(buttonAskEightBall);
            tabPageEightBall.Controls.Add(textBoxEightBall);
            tabPageEightBall.Location = new Point(4, 24);
            tabPageEightBall.Name = "tabPageEightBall";
            tabPageEightBall.Padding = new Padding(3);
            tabPageEightBall.Size = new Size(576, 333);
            tabPageEightBall.TabIndex = 1;
            tabPageEightBall.Text = "Шар-Восьмёрка";
            tabPageEightBall.UseVisualStyleBackColor = true;
            // 
            // checkBoxTextToSeedEightBall
            // 
            checkBoxTextToSeedEightBall.AutoSize = true;
            checkBoxTextToSeedEightBall.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxTextToSeedEightBall.Font = new Font("Segoe UI", 15F);
            checkBoxTextToSeedEightBall.Location = new Point(440, 298);
            checkBoxTextToSeedEightBall.Name = "checkBoxTextToSeedEightBall";
            checkBoxTextToSeedEightBall.Size = new Size(128, 32);
            checkBoxTextToSeedEightBall.TabIndex = 3;
            checkBoxTextToSeedEightBall.Text = "TextToSeed";
            checkBoxTextToSeedEightBall.UseVisualStyleBackColor = true;
            // 
            // labelEightBall
            // 
            labelEightBall.Font = new Font("Segoe UI", 20F);
            labelEightBall.Location = new Point(8, 230);
            labelEightBall.Name = "labelEightBall";
            labelEightBall.Size = new Size(560, 37);
            labelEightBall.TabIndex = 2;
            labelEightBall.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonAskEightBall
            // 
            buttonAskEightBall.Font = new Font("Segoe UI", 15F);
            buttonAskEightBall.Location = new Point(198, 120);
            buttonAskEightBall.Name = "buttonAskEightBall";
            buttonAskEightBall.Size = new Size(180, 39);
            buttonAskEightBall.TabIndex = 1;
            buttonAskEightBall.Text = "Спросить";
            buttonAskEightBall.UseVisualStyleBackColor = true;
            buttonAskEightBall.Click += buttonAskEightBall_Click;
            // 
            // textBoxEightBall
            // 
            textBoxEightBall.Font = new Font("Segoe UI", 15F);
            textBoxEightBall.Location = new Point(88, 80);
            textBoxEightBall.Name = "textBoxEightBall";
            textBoxEightBall.Size = new Size(400, 34);
            textBoxEightBall.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(checkBoxTextToSeedCustom);
            tabPage1.Controls.Add(labelCustom);
            tabPage1.Controls.Add(buttonAskCustom);
            tabPage1.Controls.Add(textBoxCustom);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(576, 333);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Custom";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBoxTextToSeedCustom
            // 
            checkBoxTextToSeedCustom.AutoSize = true;
            checkBoxTextToSeedCustom.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxTextToSeedCustom.Font = new Font("Segoe UI", 15F);
            checkBoxTextToSeedCustom.Location = new Point(440, 298);
            checkBoxTextToSeedCustom.Name = "checkBoxTextToSeedCustom";
            checkBoxTextToSeedCustom.Size = new Size(128, 32);
            checkBoxTextToSeedCustom.TabIndex = 3;
            checkBoxTextToSeedCustom.Text = "TextToSeed";
            checkBoxTextToSeedCustom.UseVisualStyleBackColor = true;
            // 
            // labelCustom
            // 
            labelCustom.Font = new Font("Segoe UI", 20F);
            labelCustom.Location = new Point(8, 230);
            labelCustom.Name = "labelCustom";
            labelCustom.Size = new Size(560, 37);
            labelCustom.TabIndex = 2;
            labelCustom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonAskCustom
            // 
            buttonAskCustom.Font = new Font("Segoe UI", 15F);
            buttonAskCustom.Location = new Point(198, 120);
            buttonAskCustom.Name = "buttonAskCustom";
            buttonAskCustom.Size = new Size(180, 39);
            buttonAskCustom.TabIndex = 1;
            buttonAskCustom.Text = "Спросить";
            buttonAskCustom.UseVisualStyleBackColor = true;
            buttonAskCustom.Click += buttonAskCustom_Click;
            // 
            // textBoxCustom
            // 
            textBoxCustom.Font = new Font("Segoe UI", 15F);
            textBoxCustom.Location = new Point(88, 80);
            textBoxCustom.Name = "textBoxCustom";
            textBoxCustom.Size = new Size(400, 34);
            textBoxCustom.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridViewCustom);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(576, 333);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "Редактировать \"Custom\"";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCustom
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewCustom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCustom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustom.Columns.AddRange(new DataGridViewColumn[] { Probability, Message });
            dataGridViewCustom.ContextMenuStrip = contextMenuStripDataGridViewCustom;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewCustom.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCustom.Dock = DockStyle.Fill;
            dataGridViewCustom.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewCustom.Location = new Point(0, 0);
            dataGridViewCustom.Name = "dataGridViewCustom";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewCustom.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCustom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCustom.Size = new Size(576, 333);
            dataGridViewCustom.TabIndex = 0;
            // 
            // Probability
            // 
            Probability.DataPropertyName = "Probability";
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = "0";
            Probability.DefaultCellStyle = dataGridViewCellStyle2;
            Probability.HeaderText = "Вероятность";
            Probability.Name = "Probability";
            // 
            // Message
            // 
            Message.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Message.DataPropertyName = "Message";
            Message.HeaderText = "Сообщение";
            Message.Name = "Message";
            // 
            // contextMenuStripDataGridViewCustom
            // 
            contextMenuStripDataGridViewCustom.Items.AddRange(new ToolStripItem[] { deleteRowToolStripMenuItem });
            contextMenuStripDataGridViewCustom.Name = "contextMenuStripDataGridViewCustom";
            contextMenuStripDataGridViewCustom.Size = new Size(134, 26);
            // 
            // deleteRowToolStripMenuItem
            // 
            deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            deleteRowToolStripMenuItem.Size = new Size(133, 22);
            deleteRowToolStripMenuItem.Text = "Delete Row";
            deleteRowToolStripMenuItem.Click += deleteRowToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(tabControlChoseMode);
            MaximizeBox = false;
            MaximumSize = new Size(600, 400);
            MinimumSize = new Size(600, 400);
            Name = "Form1";
            Text = "Lab5";
            tabControlChoseMode.ResumeLayout(false);
            tabPageYesNo.ResumeLayout(false);
            tabPageYesNo.PerformLayout();
            tabPageEightBall.ResumeLayout(false);
            tabPageEightBall.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustom).EndInit();
            contextMenuStripDataGridViewCustom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlChoseMode;
        private TabPage tabPageYesNo;
        private TabPage tabPageEightBall;
        private Button buttonAskYesNo;
        private TextBox textBoxYesNo;
        private Label labelYesNo;
        private CheckBox checkBoxTextToSeedYesNo;
        private Label labelEightBall;
        private Button buttonAskEightBall;
        private TextBox textBoxEightBall;
        private CheckBox checkBoxTextToSeedEightBall;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label labelCustom;
        private Button buttonAskCustom;
        private TextBox textBoxCustom;
        private CheckBox checkBoxTextToSeedCustom;
        private DataGridView dataGridViewCustom;
        private DataGridViewTextBoxColumn Probability;
        private DataGridViewTextBoxColumn Message;
        private ContextMenuStrip contextMenuStripDataGridViewCustom;
        private ToolStripMenuItem deleteRowToolStripMenuItem;
    }
}
