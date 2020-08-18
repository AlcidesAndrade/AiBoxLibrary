using Dapper;
using LibraryManager.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LibraryManager.Repository
{
    public class LibraryBank : ILibraryBank
    {
        IConfiguration configuration1;
        public LibraryBank(IConfiguration configuration)
        {
            configuration1 = configuration;
        }
        public string GetConnection()
        {
            var connection = configuration1.GetSection("ConnectionsStrings").
GetSection("BookConnection").Value;
            return connection;
        }
        public int Add(Book book)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Book(Id, BookName, AutorName, PublicData, Units) VALUES(@Id, @BookName, @AutorName, @PublicData, @Units); SELECT CAST(SCOPE_IdENTITY() as INT);";
                    count = con.Execute(query, book);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int Delete(int Id)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Book WHERE Id =" + Id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int Edit(Book book)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Book SET BookName = @BookName, AutorName = @AutorName, PublicData = @PublicData, Units = @Units WHERE Id = " + book.Id;
                    count = con.Execute(query, book);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public Book Get(int Id)
        {
            var connectionString = this.GetConnection();
            Book book = new Book();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Book WHERE Id =" + Id;
                    book = con.Query<Book>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return book;
            }
        }
        public List<Book> GetBooks()
        {
            var connectionString = this.GetConnection();
            List<Book> books = new List<Book>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Book";
                    books = con.Query<Book>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return books;
            }
        }
    }
}
