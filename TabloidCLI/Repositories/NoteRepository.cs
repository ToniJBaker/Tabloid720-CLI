using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.Repositories
{
    internal class NoteRepository : DatabaseConnector, IRepository<Note>
    {
        public NoteRepository(string connectionString) : base(connectionString) { }

        public void Insert(Note note)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Note (Title, Content, CreateDateTime)
                                                     VALUES (@title, @content, @createDateTime)";
                    cmd.Parameters.AddWithValue("@title", note.Title);
                    cmd.Parameters.AddWithValue("@content", note.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", note.CreateDateTime);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Note Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT p.Id AS NotetId,
                                               p.Title
                                          FROM Note p 
                                          WHERE p.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    Note note = null;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (note == null)
                        {
                            note = new Note()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("NoteId")),
                                Title = reader.GetString(reader.GetOrdinal("Title"))
                            };
                        }

                    }

                    reader.Close();

                    return note;

                }
            }
        }

        public List<Note> GetAll()
        {
            return null;
        }

        public void Update(Note note)
        {
            Console.WriteLine("");
        }

        public void Delete(int id)
        {
            Console.WriteLine("");
        }
    }
}
