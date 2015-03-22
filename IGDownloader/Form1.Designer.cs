namespace IGDownloader
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.listSearch = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listAccont = new System.Windows.Forms.ListBox();
            this.listImage = new System.Windows.Forms.ListView();
            this.userImageList = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(12, 12);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(150, 25);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            this.txtAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccount_KeyDown);
            // 
            // listSearch
            // 
            this.listSearch.FormattingEnabled = true;
            this.listSearch.ItemHeight = 15;
            this.listSearch.Location = new System.Drawing.Point(12, 43);
            this.listSearch.Name = "listSearch";
            this.listSearch.Size = new System.Drawing.Size(232, 619);
            this.listSearch.TabIndex = 1;
            this.listSearch.SelectedIndexChanged += new System.EventHandler(this.listSearch_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(169, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listAccont
            // 
            this.listAccont.FormattingEnabled = true;
            this.listAccont.ItemHeight = 15;
            this.listAccont.Location = new System.Drawing.Point(250, 13);
            this.listAccont.Name = "listAccont";
            this.listAccont.Size = new System.Drawing.Size(232, 649);
            this.listAccont.TabIndex = 3;
            // 
            // listImage
            // 
            this.listImage.LargeImageList = this.userImageList;
            this.listImage.Location = new System.Drawing.Point(488, 326);
            this.listImage.Name = "listImage";
            this.listImage.Size = new System.Drawing.Size(762, 336);
            this.listImage.SmallImageList = this.userImageList;
            this.listImage.TabIndex = 4;
            this.listImage.UseCompatibleStateImageBehavior = false;
            this.listImage.SelectedIndexChanged += new System.EventHandler(this.listImage_SelectedIndexChanged);
            // 
            // userImageList
            // 
            this.userImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.userImageList.ImageSize = new System.Drawing.Size(100, 100);
            this.userImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(488, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(762, 307);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.listImage);
            this.Controls.Add(this.listAccont);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.listSearch);
            this.Controls.Add(this.txtAccount);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ListBox listSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox listAccont;
        private System.Windows.Forms.ListView listImage;
        private System.Windows.Forms.ImageList userImageList;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

