using System;
using System.Collections.Generic;

namespace IGDownloader
{
    class MediaModel
    {
        public MediaPagination pagination { get; set; }
        public MediaMeta meta { get; set; }
        public List<MediaData> data { get; set; }
    }

    class MediaPagination
    {
        public String next_url { get; set; }
        public String next_max_id { get; set; }
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
