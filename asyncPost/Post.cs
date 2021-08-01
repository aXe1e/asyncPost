using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asyncPost
{
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override string ToString()
        {
            return $"{userId}\n{id}\n{title}\n{body}\n";
        }
    }
}