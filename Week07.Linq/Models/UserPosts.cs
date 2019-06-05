namespace Week07.Linq
{
    using System.Collections.Generic;
    using Models;

    internal partial class Program
    {
        public class UserPosts {
            public User User { get; set; }
            public List<Post> Posts { get; set; }

            //constructor
            public UserPosts()
                {
                
                }

        }
    }

}
