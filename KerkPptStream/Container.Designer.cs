using System.ComponentModel;
using System.Windows.Forms;

namespace KerkPptStream
{
    partial class Container
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.BtnRegionSelection = new System.Windows.Forms.Button();
            this.DdlScreens = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxBoundsX = new System.Windows.Forms.TextBox();
            this.TextboxBoundsY = new System.Windows.Forms.TextBox();
            this.TextboxBoundsWidth = new System.Windows.Forms.TextBox();
            this.TextboxBoundsHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnRegionSelection
            // 
            this.BtnRegionSelection.Location = new System.Drawing.Point(12, 141);
            this.BtnRegionSelection.Name = "BtnRegionSelection";
            this.BtnRegionSelection.Size = new System.Drawing.Size(114, 26);
            this.BtnRegionSelection.TabIndex = 1;
            this.BtnRegionSelection.Text = "Select region";
            this.BtnRegionSelection.UseVisualStyleBackColor = true;
            this.BtnRegionSelection.Click += new System.EventHandler(this.RegionSelectClick);
            // 
            // DdlScreens
            // 
            this.DdlScreens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DdlScreens.FormattingEnabled = true;
            this.DdlScreens.Location = new System.Drawing.Point(255, 47);
            this.DdlScreens.Name = "DdlScreens";
            this.DdlScreens.Size = new System.Drawing.Size(278, 21);
            this.DdlScreens.TabIndex = 2;
            this.DdlScreens.SelectedIndexChanged += new System.EventHandler(this.DdlScreens_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(255, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Target location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Available screens:";
            // 
            // TextboxBoundsX
            // 
            this.TextboxBoundsX.Location = new System.Drawing.Point(275, 74);
            this.TextboxBoundsX.Name = "TextboxBoundsX";
            this.TextboxBoundsX.Size = new System.Drawing.Size(83, 20);
            this.TextboxBoundsX.TabIndex = 6;
            // 
            // TextboxBoundsY
            // 
            this.TextboxBoundsY.Location = new System.Drawing.Point(275, 100);
            this.TextboxBoundsY.Name = "TextboxBoundsY";
            this.TextboxBoundsY.Size = new System.Drawing.Size(83, 20);
            this.TextboxBoundsY.TabIndex = 7;
            // 
            // TextboxBoundsWidth
            // 
            this.TextboxBoundsWidth.Location = new System.Drawing.Point(428, 74);
            this.TextboxBoundsWidth.Name = "TextboxBoundsWidth";
            this.TextboxBoundsWidth.Size = new System.Drawing.Size(105, 20);
            this.TextboxBoundsWidth.TabIndex = 8;
            // 
            // TextboxBoundsHeight
            // 
            this.TextboxBoundsHeight.Location = new System.Drawing.Point(428, 100);
            this.TextboxBoundsHeight.Name = "TextboxBoundsHeight";
            this.TextboxBoundsHeight.Size = new System.Drawing.Size(105, 20);
            this.TextboxBoundsHeight.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Width:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Height:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Screen selection:";
            // 
            // btnRecord
            // 
            this.btnRecord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRecord.Location = new System.Drawing.Point(12, 12);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(114, 51);
            this.btnRecord.TabIndex = 15;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnStop
            // 
            this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStop.Location = new System.Drawing.Point(12, 105);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(114, 30);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPause.Location = new System.Drawing.Point(12, 69);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(114, 30);
            this.btnPause.TabIndex = 17;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 183);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextboxBoundsHeight);
            this.Controls.Add(this.TextboxBoundsWidth);
            this.Controls.Add(this.TextboxBoundsY);
            this.Controls.Add(this.TextboxBoundsX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DdlScreens);
            this.Controls.Add(this.BtnRegionSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Container";
            this.Text = "Screen Stream";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button BtnRegionSelection;
        private ComboBox DdlScreens;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox TextboxBoundsX;
        private TextBox TextboxBoundsY;
        private TextBox TextboxBoundsWidth;
        private TextBox TextboxBoundsHeight;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnRecord;
        private Button btnStop;
        private Button btnPause;
    }
}

