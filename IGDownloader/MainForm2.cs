using IGDownloader.Model;
using IGDownloader.Models;
using IGDownloader.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace IGDownloader
{
    public partial class MainForm2 : Form
    {
        private const String FILE_ROOT_PATH = "SaveData";
        private const String FILE_NAME_ACCOUNT = "AccountList.json";
        private const String FILE_NAME_CONFIG = "Config.json";

        private List<UserModel> mUserModelList = null;
        private List<Image> mOriginalPictureList = null;
        private List<MediaModel> mMediaModelList = null;
        private ImageList mPictureList = null;
        private UserModel mSelectedUserModel = null;
        private ConfigModel mConfigModel = null;
        private MediaModel mMediaModel = null;

        private int mSelectedUserIndex = 0;
        private Boolean mIsPictureLoading = false;

        public MainForm2()
        {
            InitializeComponent();
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {
            checkDirExists(FILE_ROOT_PATH);
            readAccountList();
            readConfig();
            updateAccountListBox();
            updateConfig();

            mPictureList = new ImageList();
            mPictureList.ImageSize = new Size(128, 128);
            mPictureList.ColorDepth = ColorDepth.Depth24Bit;
            txtSavePath.ReadOnly = true;
            listPicture.View = View.LargeIcon;
            listPicture.LargeImageList = mPictureList;
            labelTotalCount.Text = "照片總數：0";
        }

        private void MainForm2_Deactivate(object sender, EventArgs e)
        {

        }

        private void MainForm2_Leave(object sender, EventArgs e)
        {

        }

        private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainForm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            writeAccountList();
            writeConfig();
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Enter))
            {
                btnAddAccount.PerformClick();
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            String account = txtAccount.Text;

            if (!account.Equals(String.Empty))
            {
                IGManager.defaultManager().getSearchResult(txtAccount.Text, (SearchModel searchResult) =>
                {
                    Console.WriteLine("result.data.Count : " + searchResult.data.Count);
                    if (searchResult.data.Count != 0)
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

        private void listAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            mOriginalPictureList = new List<Image>();
            mMediaModelList = new List<MediaModel>();
            mSelectedUserIndex = listAccount.SelectedIndex;
            mSelectedUserModel = null;
            btnLoadNextPage.Enabled = true;
            getUserMedia();
            Console.WriteLine("mSelectedAccountIndex : " + mSelectedUserIndex);
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
        private void listPicture_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDailog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDailog.ShowDialog();

            Console.WriteLine("result : " + result);
            if (result == DialogResult.OK)
            {
                mConfigModel.savePath = folderBrowserDailog.SelectedPath;
                txtSavePath.Text = folderBrowserDailog.SelectedPath;
            }
        }

        private void btnSaveAllPicture_Click(object sender, EventArgs e)
        {
            String dirSavePath = String.Format("{0}\\{1}", mConfigModel.savePath, mSelectedUserModel.data.username);
            checkDirExists(dirSavePath);
            progressBar.Value = 0;
            progressBar.Maximum = mOriginalPictureList.Count;
            btnSaveAllPicture.Enabled = false;
            int currentIndex = 0;

            foreach (MediaModel mediaModel in mMediaModelList)
            {
                for (int i = 0; i < mediaModel.data.Count; i++)
                {
                    MediaData pictureItem = mediaModel.data[i];
                    String fileSavePath = String.Format("{0}\\{1}.jpg", dirSavePath, pictureItem.id);
                    Bitmap pictureBitmap = new Bitmap(mOriginalPictureList[currentIndex + i]);

                    try
                    {
                        pictureBitmap.Save(fileSavePath);
                        pictureBitmap.Dispose();
                        progressBar.Value++;
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("exp : " + exp.Message);
                    }
                }
                currentIndex += mediaModel.data.Count;
            }

            btnSaveAllPicture.Enabled = true;
        }

        private void btnLoadNextPage_Click(object sender, EventArgs e)
        {
            getUserMedia();
        }

        private void checkDirExists(String dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        private void writeAccountList()
        {
            String filePath = Path.Combine(FILE_ROOT_PATH, FILE_NAME_ACCOUNT);
            String jsonString = JsonConvert.SerializeObject(mUserModelList);
            File.WriteAllText(filePath, jsonString);
        }

        private void readAccountList()
        {
            try
            {
                String filePath = Path.Combine(FILE_ROOT_PATH, FILE_NAME_ACCOUNT);
                String jsonString = File.ReadAllText(filePath);
                mUserModelList = JsonConvert.DeserializeObject<List<UserModel>>(jsonString);
            }
            catch (Exception e)
            {
                mUserModelList = new List<UserModel>();
                Console.WriteLine(e.Message);
            }
        }

        private void updateAccountListBox()
        {
            foreach (UserModel item in mUserModelList)
            {
                listAccount.Items.Add(item.data.username);
            }
        }

        private void writeConfig()
        {
            String filePath = Path.Combine(FILE_ROOT_PATH, FILE_NAME_CONFIG);
            String jsonString = JsonConvert.SerializeObject(mConfigModel);
            File.WriteAllText(filePath, jsonString);
        }

        private void readConfig()
        {
            try
            {
                String filePath = Path.Combine(FILE_ROOT_PATH, FILE_NAME_CONFIG);
                String jsonString = File.ReadAllText(filePath);
                mConfigModel = JsonConvert.DeserializeObject<ConfigModel>(jsonString);
            }
            catch (Exception e)
            {
                mConfigModel = new ConfigModel();
                Console.WriteLine(e.Message);
            }
        }

        private void getUserMedia()
        {
            if (mSelectedUserIndex != -1 && !mIsPictureLoading)
            {
                Image[] imageArray = null;
                mIsPictureLoading = true;
                updateControlStatus();
                progressBar.Value = 0;

                if (mSelectedUserModel == null)
                {
                    mSelectedUserModel = mUserModelList[mSelectedUserIndex];

                    IGManager.defaultManager().getUserMedia(mSelectedUserModel.data.id, (MediaModel result) =>
                    {
                        imageArray = new Image[result.data.Count];
                        mPictureList.Images.Clear();
                        listPicture.Items.Clear();
                        progressBar.Maximum = result.data.Count;
                        mMediaModel = result;
                        mMediaModelList.Add(result);

                        for (int i = 0; i < result.data.Count; i++)
                        {
                            Console.WriteLine("Download Picture Start");
                            MediaData mediaItem = result.data[i];
                            IGManager.defaultManager().getPicture(i, mediaItem.images.standard_resolution.url, (int index, Image pictureResult) =>
                            {
                                imageArray[index] = pictureResult;
                                progressBar.Value++;
                                Console.WriteLine("index : " + index);
                                Console.WriteLine("Download Picture Done");
                            });
                            Console.WriteLine("Download Picture End");
                        }
                    });
                }
                else
                {
                    IGManager.defaultManager().getNextPageMedia(mMediaModel.pagination.next_url, (MediaModel result) =>
                    {
                        imageArray = new Image[result.data.Count];
                        progressBar.Maximum = result.data.Count;
                        mMediaModel = result;
                        mMediaModelList.Add(result);

                        for (int i = 0; i < result.data.Count; i++)
                        {
                            Console.WriteLine("Download Picture Start");
                            MediaData mediaItem = result.data[i];
                            IGManager.defaultManager().getPicture(i, mediaItem.images.standard_resolution.url, (int index, Image pictureResult) =>
                            {
                                imageArray[index] = pictureResult;
                                progressBar.Value++;
                                Console.WriteLine("index : " + index);
                                Console.WriteLine("Download Picture Done");
                            });
                            Console.WriteLine("Download Picture End");
                        }
                    });
                }

                new Thread(() =>
                {
                    while (progressBar.Value != progressBar.Maximum)
                    {
                        Thread.Sleep(500);
                    }

                    mIsPictureLoading = false;

                    Invoke(new Action(() =>
                    {
                        int currentPictureCount = mPictureList.Images.Count;

                        for (int i = 0; i < imageArray.Length; i++)
                        {
                            mOriginalPictureList.Add(imageArray[i]);
                            mPictureList.Images.Add(imageArray[i]);
                            ListViewItem viewItem = new ListViewItem();
                            viewItem.ImageIndex = currentPictureCount + i;
                            listPicture.Items.Add(viewItem);
                        }
                        updateControlStatus();
                    }));
                }).Start();
            }
        }

        private void updateConfig()
        {
            txtSavePath.Text = mConfigModel.savePath;
        }

        private void updateControlStatus()
        {
            btnSaveAllPicture.Enabled = !mIsPictureLoading;
            btnLoadNextPage.Enabled = !mIsPictureLoading;
            labelTotalCount.Text = String.Format("照片總數：{0}", mPictureList.Images.Count);

            if (mMediaModel != null)
            {
                btnLoadNextPage.Enabled = (mMediaModel.pagination.next_url == null) ? false : true;
            }
        }
    }
}