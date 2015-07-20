using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGDownloader
{
    class MediaModel
    {
        public MediaMeta meta { get; set; }
        public List<MediaData> data { get; set; }
    }

    class MediaMeta
    {
        public int code { get; set; }
        public String error_type { get; set; }
        public String error_message { get; set; }
    }

    class MediaData
    {
        public String id { get; set; }
        public MediaCaption caption { get; set; }
        public MediaImages images { get; set; }
        public String created_time { get; set; }
    }

    class MediaCaption
    {
        public String id { get; set; }
        public String text { get; set; }        
        public String created_time { get; set; }
    }

    class MediaImages
    {
        public MediaImage low_resolution { get; set; }
        public MediaImage thumbnail { get; set; }
        public MediaImage standard_resolution { get; set; }
    }

    class MediaImage
    {
        public String url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
