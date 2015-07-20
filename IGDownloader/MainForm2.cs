using IGDownloader.Model;
using IGDownloader.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IGDownloader
{
    public partial class MainForm2 : Form
    {
        private ImageList mPictureList = null;
        private int mSelectedUserIndex = 0;
        private UserModel mSelectedUserModel = null;
        private List<UserModel> mUserModelList = null;
        public MainForm2()
        {
            InitializeComponent();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            String account = txtAccount.Text;

            if (!account.Equals(String.Empty))
            {
                IGManager.defaultManager().getSearchResult(txtAccount.Text, (SearchModel searchResult) =>
                {
                    Console.WriteLine("result.data.Count : " + searchResult.data.Count);
                    if (searchResult.data.Count == 1)
                    {
                        IGManager.defaultManager().getUserInfo(searchResult.data[0].id, (UserModel userModelResult) =>
                        {
                            mUserModelList.Add(userModelResult);
                            listAccount.Items.Add(txtAccount.Text);
                            txtAccount.Text = String.Empty;
                        });
                    }
                    txtAccount.Focus();
                    txtAccount.SelectAll();
                });
            }
            else
            {
                MessageBox.Show("新增的帳號不可為空值！", "錯誤訊息");
                txtAccount.Focus();
            }
        }

        private void listAccount_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mSelectedUserIndex = listAccount.SelectedIndex;

            if (mSelectedUserIndex != -1)
            {
                Console.WriteLine(listAccount.SelectedItem.ToString());
                DialogResult deleteResult = MessageBox.Show("確定要刪除選取的帳號？", "確認訊息", MessageBoxButtons.YesNo);

                if (deleteResult.Equals(DialogResult.Yes))
                {
                    listAccount.Items.RemoveAt(mSelectedUserIndex);
                }
            }
        }

        private void listAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedUserIndex = listAccount.SelectedIndex;
            Console.WriteLine("mSelectedAccountIndex : " + mSelectedUserIndex);

            if (mSelectedUserIndex != -1)
            {
                UserModel selectedUser = mUserModelList[mSelectedUserIndex];
                IGManager.defaultManager().getUserMedia(selectedUser.data.id, (MediaModel result) =>
                {
                    mPictureList = new ImageList();
                    listPicture.Items.Clear();
                    for (int i = 0; i < result.data.Count; i++)
                    {
                        Console.WriteLine("Download Picture Start");
                        MediaData mediaItem = result.data[i];
                        IGManager.defaultManager().getPicture(i, mediaItem.images.standard_resolution.url, (int index, Image pictureResult) =>
                        {
                            mPictureList.Images.Add(pictureResult);
                            ListViewItem viewItem = new ListViewItem();
                            viewItem.ImageIndex = index;
                            listPicture.Items.Add(viewItem);
                            Console.WriteLine("Download Picture Done");
                        });
                        Console.WriteLine("Download Picture End");
                    }
                    mPictureList.ImageSize = new Size(128, 128);
                    mPictureList.ColorDepth = ColorDepth.Depth32Bit;
                    listPicture.LargeImageList = mPictureList;
                });
            }
        }

        private void listPicture_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm2_Deactivate(object sender, EventArgs e)
        {

        }

        private void MainForm2_Leave(object sender, EventArgs e)
        {
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {
            mUserModelList = new List<UserModel>();
            txtSavePath.Enabled = false;
            listPicture.View = View.LargeIcon;
        }
    }
}