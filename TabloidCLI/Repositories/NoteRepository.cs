//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using TabloidCLI.Models;
//using TabloidCLI.Repositories;

//namespace TabloidCLI.Repositories
//{
//    internal class NoteRepository : DatabaseConnector, IRepository<Note>
//    {
//        public NoteRepository(string connectionString) : base(connectionString) { }

//        public Note Get(int id)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"SELECT p.Id AS NotetId,
//                                               p.Title
//                                          FROM Note p 
//                                          WHERE p.Id = @id";

//                    cmd.Parameters.AddWithValue("@id", id);

//                    Note note = null;

//                    SqlDataReader reader = cmd.ExecuteReader();
//                    if (reader.Read())
//                    {
//                        if (note == null)
//                        {
//                            note = new Note()
//                            {
//                                Id = reader.GetInt32(reader.GetOrdinal("NoteId")),
//                                Title = reader.GetString(reader.GetOrdinal("Title"))
//                            };
//                        }

//                        }

//                        reader.Close();

//                        return note;
                    
//                }
//            }
//        }
//    }
//}
