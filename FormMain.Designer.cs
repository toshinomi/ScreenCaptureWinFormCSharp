namespace ScreenCaptureWinFormCSharp
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnMinimizedIcon = new System.Windows.Forms.Button();
            this.btnCloseIcon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(1, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(418, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Screen Capture";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(10, 38);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // btnMinimizedIcon
            // 
            this.btnMinimizedIcon.BackColor = System.Drawing.Color.Black;
            this.btnMinimizedIcon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimizedIcon.ForeColor = System.Drawing.Color.White;
            this.btnMinimizedIcon.Location = new System.Drawing.Point(337, 2);
            this.btnMinimizedIcon.Name = "btnMinimizedIcon";
            this.btnMinimizedIcon.Size = new System.Drawing.Size(35, 25);
            this.btnMinimizedIcon.TabIndex = 12;
            this.btnMinimizedIcon.Text = "-";
            this.btnMinimizedIcon.UseVisualStyleBackColor = false;
            this.btnMinimizedIcon.Click += new System.EventHandler(this.OnClickBtnMinimizedIcon);
            // 
            // btnCloseIcon
            // 
            this.btnCloseIcon.BackColor = System.Drawing.Color.Black;
            this.btnCloseIcon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseIcon.ForeColor = System.Drawing.Color.White;
            this.btnCloseIcon.Location = new System.Drawing.Point(382, 2);
            this.btnCloseIcon.Name = "btnCloseIcon";
            this.btnCloseIcon.Size = new System.Drawing.Size(35, 25);
            this.btnCloseIcon.TabIndex = 11;
            this.btnCloseIcon.Text = "×";
            this.btnCloseIcon.UseVisualStyleBackColor = false;
            this.btnCloseIcon.Click += new System.EventHandler(this.OnClickBtnClose);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(420, 450);
            this.Controls.Add(this.btnMinimizedIcon);
            this.Controls.Add(this.btnCloseIcon);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnMinimizedIcon;
        private System.Windows.Forms.Button btnCloseIcon;
    }
}

