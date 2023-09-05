using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoData
{
    public class AdoMSSQLRepository
    {
        public static readonly string MSSQLConnectionString =
                              "Server=DESKTOP-AIDC8ES\\SQLEXPRESS;" +
                              "Database=Notebook;" +
                              "Trusted_Connection=True;" +
                              "MultipleActiveResultSets=true;";


        public void Create(Notebook item)
        {
            string sqlExpression = $"INSERT INTO Notebook(Day, Time, Event, Name, Number)" +
                " VALUES (@day, @time, @event, @name, @number);";
            

            using (SqlConnection connection = new SqlConnection(MSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@day", item.Day),
                            new SqlParameter("@time", item.Time),
                            new SqlParameter("@event",item.Event),
                            new SqlParameter("@name",item.Name),
                            new SqlParameter("@number",item.Number),
                        }); ;

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string evvent)
        {
            string sqlExpression = "DELETE FROM Notebook WHERE Event = @event";

            using (SqlConnection connection = new SqlConnection(MSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlParameter typeParam = new SqlParameter("@event", evvent);
                    command.Parameters.Add(typeParam);

                    command.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<Notebook> GetAll()
        {
            string sqlExpression = "SELECT Day, Time, Event, Name, Number FROM Notebook";
            List<Notebook> notebooks = new List<Notebook>();

            using (SqlConnection connection = new SqlConnection(MSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notebooks.Add(new Notebook()
                            {
                                Day=(string)reader["Day"],
                                Time = (DateTime)reader["Time"],
                                Event = (string)reader["Event"],
                                Name = (string)reader["Name"],
                                Number = (string)reader["Number"],
                            });
                        }
                    }
                }
            }

            return notebooks;
        }
        public Notebook GetById(string evvent)
        {
            string sqlExpression = "SELECT Day, Time, Event, Name, Number FROM Notebook" +
                " WHERE Event = @event";
            using (SqlConnection connection = new SqlConnection(MSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlParameter idParam = new SqlParameter(@"event", evvent);
                    command.Parameters.Add(idParam);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read() ? new Notebook()
                        {
                            Day = (string)reader["Day"],
                            Time = (DateTime)reader["Time"],
                            Event = (string)reader["Event"],
                            Name = (string)reader["Name"],
                            Number = (string)reader["Number"],
                        } : null;
                    }
                }
            }
        }
        public void Update(Notebook item)
        {
            string sqlExpression = "UPDATE Notebook SET Day=@day, Time=@time, Event=@event, Name=@name, Number=@number" +
                " FROM Notebook" +
                " WHERE Event = @event";

            using (SqlConnection connection = new SqlConnection(MSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@day", item.Day),
                            new SqlParameter("@time", item.Time),
                            new SqlParameter("@event",item.Event),
                            new SqlParameter("@name",item.Name),
                            new SqlParameter("@number",item.Number),
                        });

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Save(List<Notebook> notebooks)
        {
            var item = GetAll();
            foreach (var i in item)
                Delete(i.Event);
            foreach (var notebook in notebooks)
                Create(notebook);
        }
    }
}
