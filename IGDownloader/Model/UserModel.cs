using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGDownloader.Model
{
    class UserModel
    {
        public UserMeta meta { get; set; }
        public UserData data { get; set; }
    }

    class UserMeta
    {
        public int code { get; set; }
        public String error_type { get; set; }
        public String error_message { get; set; }
    }

    class UserData
    {
        public String id { get; set; }
        public String username { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String profile_picture { get; set; }
        public UserDataCounts counts { get; set; }
    }

    class UserDataCounts
    {
        public int media { get; set; }
        public int followed_by { get; set; }
        public int follows { get; set; }
    }
}
