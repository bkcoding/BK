using System;

namespace BK.Models
{
    public class ViewPostsModelNoContent
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string writer { get; set; }
        public DateTime time { get; set; }
        public string pic { get; set; }
        public string info { get; set; }
        public decimal read { get; set; }
        public int mfcID { get; set; }
        public string mfcName { get; set; }
        public string mfcOtherName { get; set; }
    }
    public class SidebarModel
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string pic { get; set; }
        public string writer { get; set; }
        public DateTime time { get; set; }
        public decimal read { get; set; }
    }
}
