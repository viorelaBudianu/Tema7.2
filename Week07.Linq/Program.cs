namespace Week07.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Setup;

    internal partial class Program
    {
        private static void Main(string[] args)
        {
            var allUsers = ReadUsers("users.json");
            var allPosts = ReadPosts("posts.json");

            // 1 - find all users having email ending with ".net".
            var users1 = from u in allUsers
                         where u.Email.EndsWith(".net")
                         select u;

            var users2 = allUsers.Where(x => x.Email.EndsWith(".net"));

            var emails = allUsers.Select(x => x.Email).ToList();

            // 2 - find all posts for users having email ending with ".net".
            var UsersPosts = allPosts.Join(users2,
                post => post.UserId,
                user => user.Id,
                (post, users) => post);


            var UsersPosts2 = from s in allPosts
                              join u in users2
                              on s.UserId equals u.Id
                              select new
                              {
                                  PostTitle = s.Title,
                                  PostUser = u.Name,
                                  EmailUser = u.Email
                              };

            foreach (var x in UsersPosts2)
            {
                Console.WriteLine($"Post Title:{x.PostTitle}\nUser: {x.PostUser}\n Email:{x.EmailUser}");
            }


            // 3 - print number of posts for each user.
            var UserP = from p in allPosts
                        join u in allUsers
                        on p.UserId equals u.Id
                        select new
                        {
                            UserID = u.Id,
                            UserName = u.Name,
                            PostTitle = p.Title
                        };
            var countUsers = from c in UserP
                             group c by c.UserID;


            foreach (var group in countUsers)
            {
                
                var count = group.Count();
                Console.WriteLine($"UserID:{group.Key}---Number of Posts:{count}");
                foreach(var k in group)
                {
                    Console.WriteLine($"Post Title:{k.PostTitle}");
                }
            }
            // 4 - find all users that have lat and long negative.
            var LatLong = allUsers.Where(s => s.Address.Geo.Lat.StartsWith("-") && s.Address.Geo.Lng.StartsWith("-"));
            //or
            var LongLat = from a in allUsers
                          where a.Address.Geo.Lat.StartsWith("-")
                          where a.Address.Geo.Lng.StartsWith("-")
                          select new
                          {
                              UserName = a.Name,
                              Long = a.Address.Geo.Lng,
                              Latitude = a.Address.Geo.Lat
                          };
            foreach (var u in LatLong)
            {
                Console.WriteLine($"User that has lat and long negative {u.Name}: Lat {u.Address.Geo.Lat} and Long {u.Address.Geo.Lng}");
            }

            // 5 - find the post with longest body.
            var longBody = allPosts.Max(s => s.Body);
            Console.WriteLine($"The longest post is:\"{longBody}\" having {longBody.Length} characters");


            // 6 - print the name of the employee that have post with longest body.
            var employee = from a in allPosts
                           join u in allUsers
                           on a.UserId equals u.Id
                           where a.Body.Contains(longBody)
                           select u.Name;
            Console.WriteLine($"User with the longest post is:{employee.First()}");


            // 7 - select all addresses in a new List<Address>. print the list.
            List<Address> addresses = new List<Address>();
             var address = from a in allUsers
                        select a.Address;
            addresses = address.ToList();

            Console.WriteLine("Addresses are: ");
            int d = 0;
            foreach (var i in addresses)
            {
                d++;
                Console.WriteLine($"{d}) {i.City} {i.Street} {i.Zipcode} {i.Geo.Lat} {i.Geo.Lng}");
            }

            // 8 - print the employee with min lat
            var min = allUsers.Min(a => a.Address.Geo.Lat);
            var EmployeeLat = allUsers.Where(x => x.Address.Geo.Lat.Equals(min));
            Console.WriteLine($"Employee with min lat is: {EmployeeLat.First().Name}");


            // 9 - print the employee with max long
            var max = allUsers.Max(y => y.Address.Geo.Lng);
            var EmployeeLng = allUsers.Where(y => y.Address.Geo.Lng.Equals(max));
            //foreach(var i in EmployeeLng) am facut foreach sa vad cate rezultate am, dar am 1 singur rezultat. 
            //{
            //    Console.WriteLine(i.Name);
            //}
            Console.WriteLine($"Employee with max lng is: {EmployeeLng.First().Name}");


            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only
            List<UserPosts> userPost = new List<UserPosts>();
            var UserPo = from p in allPosts
                         join u in allUsers
                         on p.UserId equals u.Id
                         select new { User = u, Post = p };

           // userPost.Add(UserPo.ToList());


            // 11 - order users by zip code
            var orderUsers = allUsers.OrderBy(x => x.Address.Zipcode);
            foreach(var i in orderUsers)
            {
                Console.WriteLine($"Zip:{i.Address.Zipcode}  User: {i.Name}");
            }


            // 12 - order users by number of posts
            var postUser = from a in allPosts
                           join u in allUsers
                           on a.UserId equals u.Id
                           select new
                           {
                               user = u,
                               post = a.Title
                           };

            var or = postUser.OrderBy(x => x.post.Count());
            foreach (var i in or)
            {
                Console.WriteLine($"Name:{i.user.Name} #Posts:{i.post.Count()}");
            }
                           


            
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }

}
