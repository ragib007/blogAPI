using BlogApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BlogApi4.Repositories
{
    public class PostRepositoryLocalDb : IPostRepository
    {

        public PostRepositoryLocalDb()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=postdb;Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("IF NOT EXISTS(SELECT * FROM sysobjects WHERE  name = 'posts3' and xtype='U') CREATE TABLE posts3 (Id int,Title varchar(255),Text varchar(255),CreatedAt varchar(255),AuthorId int) ", connection))
                {
                    SqlDataReader reader=command.ExecuteReader();

                }

            }

        }



        public List<Post> GetAll()
        {
            List<Post> _posts = new List<Post>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=postdb;Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM posts3", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            _posts.Add(new Post { Id = reader.GetInt32(0), Title = reader.GetString(1), Text = reader.GetString(2), CreatedAt = reader.GetString(3), AuthorId = reader.GetInt32(4) });
                        }

                    }
                    
                }
                
            }
          
            
            return _posts;
        }

        public Post GetById(int id)
        {
            
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=postdb;Integrated Security=True;MultipleActiveResultSets=True";
            var post = new Post();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandQuery = $"SELECT * FROM posts3 WHERE Id={id}";
                using (SqlCommand command = new SqlCommand(commandQuery, connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            post = new Post { Id = reader.GetInt32(0), Title = reader.GetString(1), Text = reader.GetString(2), CreatedAt = reader.GetString(3), AuthorId = reader.GetInt32(4) };
                        }
                    }
                    
                }
            }

            return post;
        }

        public IEnumerable<Post> GetByAuthor(int id)
        {
            List<Post> _posts = new List<Post>();
            return _posts.Where(p => p.AuthorId == id);
        }

        public IEnumerable<string> GetTitle()
        {
            List<Post> _posts = new List<Post>();
            List<string> titles = new List<string>();
            foreach (var post in _posts)
                titles.Add(post.Title);
            return titles;
        }

        public void Create(Post post)
        {
           
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=postdb;Integrated Security=True;MultipleActiveResultSets=True";
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandQuery = $"INSERT INTO posts3 VALUES('{post.Id}','{post.Title}','{post.Text}','{post.CreatedAt}','{post.AuthorId}')";
                using (SqlCommand command = new SqlCommand(commandQuery, connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                }
            }
            
        }

        public void Update(int id, Post post)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=postdb;Integrated Security=True;MultipleActiveResultSets=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandQuery = $"UPDATE posts3 SET Id='{post.Id}',Title='{post.Title}',Text='{post.Text}',CreatedAt='{post.CreatedAt}',AuthorId='{post.AuthorId}' WHERE Id={id}";
                using (SqlCommand command = new SqlCommand(commandQuery, connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                }
            }
            
        }

        public void Delete(int id)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=postdb;Integrated Security=True;MultipleActiveResultSets=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandQuery = $"DELETE FROM posts3 WHERE Id={id}";
                using (SqlCommand command = new SqlCommand(commandQuery, connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                }
            }

        }

        public bool Exists(int id)
        {
                      
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=postdb;Integrated Security=True;MultipleActiveResultSets=True";
            Post post = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                string commandQuery = $"SELECT * FROM posts3 WHERE Id={id}";
                using (SqlCommand command = new SqlCommand(commandQuery, connection))
                {
                    
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            post = new Post { Id = reader.GetInt32(0), Title = reader.GetString(1), Text = reader.GetString(2), CreatedAt = reader.GetString(3), AuthorId = reader.GetInt32(4) };
                        }
                       
                    }
                    
                }
            }

            return post != null;
        }









    }
}
