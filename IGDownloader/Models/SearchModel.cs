using IGDownloader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGDownloader
{
    class SearchModel
    {
        public SearchMeta meta { get; set; }
        public List<UserData> data { get; set; }
    }

    class SearchMeta
    {
        public int code { get; set; }
        public String error_type { get; set; }
        public String error_message { get; set; }
    }
}
