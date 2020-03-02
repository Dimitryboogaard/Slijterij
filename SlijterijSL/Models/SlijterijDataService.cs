using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;

namespace SlijterijSL.Models
{
    public class SlijterijDataService : IDisposable
    {

       
            private SqlConnection connection;
            public SlijterijDataService()
            {
            // connection string
            // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=..\..\Database\Slijterijdb.mdf;Integrated Security=True;Connect Timeout=30    
            //var conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ITvitae\PublisherSolution\PublisherData\Data\PublisherDb.mdf;Integrated Security=True";
            var connectionString = ConfigurationManager.ConnectionStrings["PublisherDbConnection"].ConnectionString;
                //Debug.Assert(conString == connectionString);
                connection = new SqlConnection(connectionString);
                connection.Open();
            }

            #region Disposablity
            //Destructor in .NET is a Finalizer (will be called by GC) :
            ~SlijterijDataService()
            {
                Dispose(false);
            }

            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                //var x = new Object();
                //var y = x;
                //x = null;
                //y = null;//Destructable..all references released, waiting for garbage collector to destruct or cleanup
                if (!disposed)//to detect redundant calls
                {
                    if (disposing)
                    {
                        if (connection != null && connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        connection.Dispose();
                    }
                    disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);//Notify GC to inform this object has been disposed
            }

            #endregion


            public bool AddBookToPublisher(int publisherId, int authorId, string bookTitle)
            {
                int recordsAffected = 0;
                try
                {
                    //var sqlInjectable = "INSERT INTO Books (Title, AuthorId) VALUES (\"" + bookTitle + "\", " + authorId + ");";
                    var sql = "INSERT INTO Books (Title, AuthorId, Genre) VALUES (@bookTitle, @authorId, 0);";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("bookTitle", bookTitle);
                        command.Parameters.AddWithValue("authorId", authorId);
                        recordsAffected = command.ExecuteNonQuery();
                    }

                }
                catch (SqlException sqlEx)
                {
                    //log exception..
                    Console.WriteLine("***********************************************");
                    Console.WriteLine($"SqlException.ToString(): {sqlEx.ToString()}");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine($"SqlException.Message: {sqlEx.Message}");
                    Console.WriteLine("***********************************************");
                    foreach (var error in sqlEx.Errors)
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                    Console.WriteLine("***********************************************");
                }

                return recordsAffected == 1;
            }


            public int PublisherBooksCount(int publisherId)
            {
                //Implement code and use command.ExecuteScalar
                var result = 0;
                var sql = "SELECT Count(Book_Id) FROM PublisherBooks WHERE Publisher_Id = @publisherId;";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("publisherId", publisherId);
                    result = Convert.ToInt32(command.ExecuteScalar());
                }

                return result;
            }

            public ICollection<string> GetBooks(int genre)
            {
                var result = new List<string>();
                var sql = "SELECT Id, Title FROM Books WHERE Genre = @genre;";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("genre", genre);
                    var reader = command.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        result.Add($"({reader.GetInt32(0)}) {(reader.IsDBNull(1) ? string.Empty : reader.GetString(1))}");
                    }
                }
                return result;
            }
        
    }

}
}
