using CoreTweet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
    public class UserModel
    {
        public List<Tokens> tokens { get; set; }

        public UserModel()
        {
            if (this.tokens == null)
            {
                this.tokens = new List<Tokens>();
            }
        }
    }
}
