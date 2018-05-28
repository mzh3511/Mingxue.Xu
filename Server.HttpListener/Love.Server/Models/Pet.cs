using System;

namespace Love.Server.Models
{
    public class Pet
    {
        public DateTime CreateTime { get; set; }
        public string FilePath { get; set; }
        public int Id { get; set; }
        public string Input { get; set; }
        public int IsLike { get; set; }
        public string Tito { get; set; }
        public string Type { get; set; }
    }
}
