namespace wfHuffmanCode
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
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnDecompress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbInput
            // 
            this.rtbInput.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rtbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbInput.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbInput.Location = new System.Drawing.Point(12, 87);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(600, 491);
            this.rtbInput.TabIndex = 2;
            this.rtbInput.Text = "";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Zilla Slab", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHeader.Location = new System.Drawing.Point(188, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(229, 32);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Huffman encoding";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Zilla Slab", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblText.Location = new System.Drawing.Point(235, 56);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(137, 24);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "Enter text here";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadFile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLoadFile.Location = new System.Drawing.Point(88, 584);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(134, 23);
            this.btnLoadFile.TabIndex = 6;
            this.btnLoadFile.Text = "load from file";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveFile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveFile.Location = new System.Drawing.Point(404, 584);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(107, 23);
            this.btnSaveFile.TabIndex = 7;
            this.btnSaveFile.Text = "save to file";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCompress.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCompress.Location = new System.Drawing.Point(228, 584);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(75, 23);
            this.btnCompress.TabIndex = 9;
            this.btnCompress.Text = "compress";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // btnDecompress
            // 
            this.btnDecompress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDecompress.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDecompress.Location = new System.Drawing.Point(309, 584);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(89, 23);
            this.btnDecompress.TabIndex = 10;
            this.btnDecompress.Text = "decompress";
            this.btnDecompress.UseVisualStyleBackColor = true;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(626, 611);
            this.Controls.Add(this.btnDecompress);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.rtbInput);
            this.Name = "Form1";
            this.Text = "Huffman Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RichTextBox rtbInput;
        private Label lblHeader;
        private Label lblText;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button btnLoadFile;
        private Button btnSaveFile;
        private Button btnCompress;
        private Button btnDecompress;
    }
}