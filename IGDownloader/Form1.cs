using IGDownloader.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGDownloader
{
    public partial class MainForm : Form
    {
        private static String API_BASE_URL = "https://api.instagram.com/v1";
        private static String USER_SEARCH_URL = API_BASE_URL + "/users/search?q={0}&client_id={1}";
        private static String USER_INFO_URL = API_BASE_URL + "/users/{0}?client_id={1}";
        private static String USER_MEDIA_URL = API_BASE_URL + "/users/{0}/media/recent?count={1}&client_id={2}";
        private static int MAX_RETURN = 20;

        private List<UserData> mSearchList = null;
        private List<MediaData> mMediaList = null;
        private UserData mSelectedUser = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                String clientId = System.Configuration.ConfigurationManager.AppSettings["CLIENDID"];
                String strAcc = txtAccount.Text;
                String requestUrl = String.Format(USER_SEARCH_URL, strAcc, clientId);

                Thread thread = new Thread(searchUserTask);
                thread.Start(requestUrl);
            }
            catch (System.Configuration.ConfigurationErrorsException error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void listSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listSearch.SelectedIndex;
                if (selectedIndex != -1)
                {
                    UserData selectedUser = mSearchList[selectedIndex];
                    String clientId = System.Configuration.ConfigurationManager.AppSettings["CLIENDID"];
                    String requestUrl = String.Format(USER_INFO_URL, selectedUser.id, clientId);

                    Thread thread = new Thread(getUserInfoTask);
                    thread.Start(requestUrl);
                }
            }
            catch (System.Configuration.ConfigurationErrorsException error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void searchUserTask(object requestUrl)
        {
            Console.WriteLine(requestUrl);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl.ToString());
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    String strResponse = reader.ReadToEnd();
                    SearchModel model = JsonConvert.DeserializeObject<SearchModel>(strResponse);

                    if (model.meta.code == 200)
                    {
                        mSearchList = model.data;
                        Console.WriteLine("Search Count : " + mSearchList.Count);
                        Invoke(new searchInvoke(updateSearchList), model);
                    }
                }
            }
        }

        private void getUserInfoTask(object requestUrl)
        {
            Console.WriteLine(requestUrl);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl.ToString());
            request.Method = "GET";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        String strResponse = reader.ReadToEnd();
                        UserModel model = JsonConvert.DeserializeObject<UserModel>(strResponse);

                        if (model.meta.code == 200)
                        {
                            try
                            {
                                mSelectedUser = model.data;
                                String clientId = System.Configuration.ConfigurationManager.AppSettings["CLIENDID"];
                                requestUrl = String.Format(USER_MEDIA_URL, mSelectedUser.id, MAX_RETURN, clientId);

                                Thread thread = new Thread(getMediaTask);
                                thread.Start(requestUrl);
                            }
                            catch (System.Configuration.ConfigurationErrorsException error)
                            {
                                Console.WriteLine(error.Message);
                            }
                            Console.WriteLine("User Id : " + mSelectedUser.id);
                            Console.WriteLine("User Name : " + mSelectedUser.username);
                            Console.WriteLine("User media : " + mSelectedUser.counts.media);
                            Console.WriteLine("User follows : " + mSelectedUser.counts.follows);
                            Console.WriteLine("User followed_by : " + mSelectedUser.counts.followed_by);
                        }
                    }
                }
            }
            catch (WebException error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void getMediaTask(object requestUrl)
        {
            Console.WriteLine(requestUrl);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl.ToString());
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    String strResponse = reader.ReadToEnd();
                    MediaModel model = JsonConvert.DeserializeObject<MediaModel>(strResponse);

                    if (model.meta.code == 200)
                    {
                        mMediaList = model.data;
                        foreach (MediaData item in mMediaList)
                        {
                            userImageList.Images.Add(loadImage(item.images.standard_resolution.url));
                        }
                        Invoke(new mediaInvoke(updateImageList));
                        Console.WriteLine("Media Count : " + mMediaList.Count);
                    }
                }
            }
        }

        private Image loadImage(String imageUrl)
        {
            WebRequest request = WebRequest.Create(imageUrl);
            using (WebResponse response = request.GetResponse())
            {
                Console.WriteLine("ContentLength : " + response.ContentLength);
                Stream responseStream = response.GetResponseStream();
                Image image = Image.FromStream(responseStream);
                responseStream.Dispose();
                return image;
            }
        }

        delegate void searchInvoke(SearchModel model);
        delegate void mediaInvoke();
        private void updateSearchList(SearchModel model)
        {
            listSearch.Items.Clear();
            foreach (UserData item in model.data)
            {
                listSearch.Items.Add(item.username);
            }
        }

        private void updateImageList()
        {
            for (int i = 0; i < mMediaList.Count; i++)
            {
                ListViewItem viewItem = new ListViewItem();
                viewItem.ImageIndex = i;
                viewItem.Text = (mMediaList[i].caption == null) ? "" : mMediaList[i].caption.text;
                listImage.Items.Add(viewItem);
            }
            listImage.View = View.LargeIcon;
        }

        private void listImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox.Image = userImageList.Images[0];
        }

    }
}
