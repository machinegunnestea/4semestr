using Microsoft.Data.Sqlite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoData
{
    public class AdoSQLiteRepository
    {
        public void Create(Notebook item)
        {
            string sqlExpression = $"INSERT INTO Notebook(Day, Time, Event, Name, Number)" +
                " VALUES (@day, @time, @event, @name, @number);";

            using (SqliteConnection connection = new SqliteConnection(NotebookContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqliteParameter[]
                        {
                            new SqliteParameter("@day", item.Day),
                            new SqliteParameter("@time", item.Time),
                            new SqliteParameter("@event",item.Event),
                            new SqliteParameter("@name",item.Name),
                            new SqliteParameter("@number",item.Number),
                        });

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string evvent)
        {
            string sqlExpression = "DELETE FROM Notebook WHERE Event = @event";

            using (SqliteConnection connection = new SqliteConnection(NotebookContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                {
                    SqliteParameter idParam = new SqliteParameter("@event", evvent);
                    command.Parameters.Add(idParam);

                    command.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<Notebook> GetAll()
        {
            string sqlExpression = "SELECT Day, Time, Event, Name, Number FROM Notebook";
            List<Notebook> notebooks = new List<Notebook>();

            using (var connection = new SqliteConnection(NotebookContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            notebooks.Add(new Notebook()
                            {
                                Day = reader["Day"].ToString(),
                                Time = Convert.ToDateTime(reader["Time"]),
                                Event = reader["Event"].ToString(),
                                Name = reader["Name"].ToString(),
                                Number = reader["Number"].ToString(),
                            });
                        }
                    }
                }
            }

            return notebooks;
        }

       
        public void Update(Notebook item)
        {
            string sqlExpression = "UPDATE Notebook SET Day=@day, Time=@time, Event=@event, Name=@name, Number=@number" +
                " FROM Notebook" +
                " WHERE Event = @event";

            using (SqliteConnection connection = new SqliteConnection(NotebookContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqliteParameter[]
                        {
                            new SqliteParameter("@day", item.Day),
                            new SqliteParameter("@time", item.Time),
                            new SqliteParameter("@event",item.Event),
                            new SqliteParameter("@name",item.Name),
                            new SqliteParameter("@number",item.Number),
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