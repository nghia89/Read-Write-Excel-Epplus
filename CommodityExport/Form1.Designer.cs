namespace CommodityExport
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.TextFileName = new System.Windows.Forms.TextBox();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProcess = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbListAddresPepot = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextFileName
            // 
            this.TextFileName.Location = new System.Drawing.Point(12, 95);
            this.TextFileName.Name = "TextFileName";
            this.TextFileName.ReadOnly = true;
            this.TextFileName.Size = new System.Drawing.Size(247, 20);
            this.TextFileName.TabIndex = 0;
            this.TextFileName.Text = " Vui lòng chọn File";
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.AllowDrop = true;
            this.BtnOpenFile.Location = new System.Drawing.Point(265, 95);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(82, 20);
            this.BtnOpenFile.TabIndex = 1;
            this.BtnOpenFile.Text = "Chọn File";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Trạng thái xử lý";
            // 
            // TxtProcess
            // 
            this.TxtProcess.Location = new System.Drawing.Point(105, 244);
            this.TxtProcess.Name = "TxtProcess";
            this.TxtProcess.ReadOnly = true;
            this.TxtProcess.Size = new System.Drawing.Size(184, 20);
            this.TxtProcess.TabIndex = 3;
            this.TxtProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phần mềm Suport Export Hóa Đơn ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chú ý: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(47, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhớ đóng File trước khi chọn.";
            // 
            // cbListAddresPepot
            // 
            this.cbListAddresPepot.FormattingEnabled = true;
            this.cbListAddresPepot.Location = new System.Drawing.Point(12, 121);
            this.cbListAddresPepot.Name = "cbListAddresPepot";
            this.cbListAddresPepot.Size = new System.Drawing.Size(247, 21);
            this.cbListAddresPepot.TabIndex = 7;
            this.cbListAddresPepot.Text = "Chọn xuất theo kho";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnApply.Location = new System.Drawing.Point(100, 188);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 39);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(12, 148);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(105, 20);
            this.txtNumber.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cộng ngày xuất kho";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(359, 271);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbListAddresPepot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOpenFile);
            this.Controls.Add(this.TextFileName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox TextFileName;
        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbListAddresPepot;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label5;
    }
}

