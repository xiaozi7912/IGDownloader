namespace IGDownloader
{
    partial class MainForm2
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
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.listAccount = new System.Windows.Forms.ListBox();
            this.listPicture = new System.Windows.Forms.ListView();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnSaveAllPicture = new System.Windows.Forms.Button();
            this.btnLoadNextPage = new System.Windows.Forms.Button();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(12, 43);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(200, 25);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            this.txtAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccount_KeyPress);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(219, 43);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(100, 25);
            this.btnAddAccount.TabIndex = 1;
            this.btnAddAccount.Text = "新增帳號";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // listAccount
            // 
            this.listAccount.FormattingEnabled = true;
            this.listAccount.ItemHeight = 15;
            this.listAccount.Location = new System.Drawing.Point(12, 74);
            this.listAccount.Name = "listAccount";
            this.listAccount.Size = new System.Drawing.Size(200, 394);
            this.listAccount.TabIndex = 2;
            this.listAccount.SelectedIndexChanged += new System.EventHandler(this.listAccount_SelectedIndexChanged);
            this.listAccount.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listAccount_MouseDoubleClick);
            // 
            // listPicture
            // 
            this.listPicture.Location = new System.Drawing.Point(219, 75);
            this.listPicture.Name = "listPicture";
            this.listPicture.Size = new System.Drawing.Size(951, 363);
            this.listPicture.TabIndex = 3;
            this.listPicture.UseCompatibleStateImageBehavior = false;
            this.listPicture.SelectedIndexChanged += new System.EventHandler(this.listPicture_SelectedIndexChanged);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(12, 13);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(200, 25);
            this.txtSavePath.TabIndex = 4;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(219, 13);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(100, 25);
            this.btnSelectPath.TabIndex = 5;
            this.btnSelectPath.Text = "選擇目錄";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(218, 444);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(952, 25);
            this.progressBar.TabIndex = 6;
            // 
            // btnSaveAllPicture
            // 
            this.btnSaveAllPicture.AutoSize = true;
            this.btnSaveAllPicture.Location = new System.Drawing.Point(423, 43);
            this.btnSaveAllPicture.Name = "btnSaveAllPicture";
            this.btnSaveAllPicture.Size = new System.Drawing.Size(110, 25);
            this.btnSaveAllPicture.TabIndex = 7;
            this.btnSaveAllPicture.Text = "儲存所有圖片";
            this.btnSaveAllPicture.UseVisualStyleBackColor = true;
            this.btnSaveAllPicture.Click += new System.EventHandler(this.btnSaveAllPicture_Click);
            // 
            // btnLoadNextPage
            // 
            this.btnLoadNextPage.AutoSize = true;
            this.btnLoadNextPage.Location = new System.Drawing.Point(325, 43);
            this.btnLoadNextPage.Name = "btnLoadNextPage";
            this.btnLoadNextPage.Size = new System.Drawing.Size(92, 25);
            this.btnLoadNextPage.TabIndex = 8;
            this.btnLoadNextPage.Text = "載入圖片";
            this.btnLoadNextPage.UseVisualStyleBackColor = true;
            this.btnLoadNextPage.Click += new System.EventHandler(this.btnLoadNextPage_Click);
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Font = new System.Drawing.Font("PMingLiU", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTotalCount.Location = new System.Drawing.Point(1021, 46);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(149, 19);
            this.labelTotalCount.TabIndex = 9;
            this.labelTotalCount.Text = "照片總數：99999";
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 503);
            this.Controls.Add(this.labelTotalCount);
            this.Controls.Add(this.btnLoadNextPage);
            this.Controls.Add(this.btnSaveAllPicture);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.listPicture);
            this.Controls.Add(this.listAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.txtAccount);
            this.MaximizeBox = false;
            this.Name = "MainForm2";
            this.Text = "MainForm2";
            this.Deactivate += new System.EventHandler(this.MainForm2_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm2_FormClosed);
            this.Load += new System.EventHandler(this.MainForm2_Load);
            this.Leave += new System.EventHandler(this.MainForm2_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.ListBox listAccount;
        private System.Windows.Forms.ListView listPicture;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnSaveAllPicture;
        private System.Windows.Forms.Button btnLoadNextPage;
        private System.Windows.Forms.Label labelTotalCount;
    }
}