using System.ComponentModel;
using System.Windows.Forms;

namespace KerkPptStream {
    sealed partial class StreamSelectionForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.StreamSelectionContent = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.StreamSelectionContent)).BeginInit();
            this.SuspendLayout();
            // 
            // StreamSelectionContent
            // 
            this.StreamSelectionContent.Location = new System.Drawing.Point(0, 0);
            this.StreamSelectionContent.Name = "StreamSelectionContent";
            this.StreamSelectionContent.Size = new System.Drawing.Size(100, 50);
            this.StreamSelectionContent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StreamSelectionContent.TabIndex = 0;
            this.StreamSelectionContent.TabStop = false;
            this.StreamSelectionContent.Paint += new System.Windows.Forms.PaintEventHandler(this.StreamSelectionPaint);
            // 
            // StreamSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.StreamSelectionContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StreamSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "StreamSelectionForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.StreamSelectionContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public PictureBox StreamSelectionContent;
    }
}