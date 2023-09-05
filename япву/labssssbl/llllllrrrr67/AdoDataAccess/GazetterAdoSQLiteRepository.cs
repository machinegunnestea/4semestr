using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace AdoDataAccess
{
    public class GazetterAdoSQLiteRepository
    {
        public void Create(Gazetter item)
        {
            string sqlExpression = $"INSERT INTO Gazetter (Country, Square, Population, Continent, Capital)" +
                " VALUES (@country, @square, @population, @continent, @capital);";

            using (SqliteConnection connection = new SqliteConnection(GazetterContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqliteParameter[]
                        {
                            new SqliteParameter("@country", item.Country),
                            new SqliteParameter("@square", item.Square),
                            new SqliteParameter("@population", item.Population),
                            new SqliteParameter("@continent", item.Continent),
                            new SqliteParameter("@capital", item.Country),

                        });

                    command.ExecuteNonQuery();
                }
            }

        }
        public void Delete(string country)
        {
            string sqlExpression = "DELETE FROM Gazetter WHERE Country=@country";

            using (SqliteConnection connection = new SqliteConnection(GazetterContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                {
                    SqliteParameter typeParam = new SqliteParameter("@country", country);
                    command.Parameters.Add(typeParam);

                    command.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<Gazetter> GetAll()
        {
            string sqlExpression = "SELECT Country, Square, Population, Continent, Capital FROM Gazetter";
            List<Gazetter> gazetters = new List<Gazetter>();

            using (var connection = new SqliteConnection(GazetterContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gazetters.Add(new Gazetter()
                            {
                                Country = reader["Country"].ToString(),
                                Square =Convert.ToDouble(reader["Square"]),
                                Population = Convert.ToDouble(reader["Population"]),
                                Continent = reader["Continent"].ToString(),
                                Capital = reader["Capital"].ToString(),
                            });
                        }
                    }
                }
            }

            return gazetters;
        }
        public Gazetter GetById(string country)
        {
            string sqlExpression = "SELECT Country, Square, Population, Continent, Capital FROM Gazetter" +
                    " WHERE Country = @country";
            using (SqliteConnection connection = new SqliteConnection(GazetterContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                {
                    SqliteParameter idParam = new SqliteParameter(@"country", country);
                    command.Parameters.Add(idParam);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read() ? new Gazetter()
                        {
                            Country = reader["Country"].ToString(),
                            Square = Convert.ToDouble(reader["Square"]),
                            Population = Convert.ToDouble(reader["Population"]),
                            Continent = reader["Continent"].ToString(),
                            Capital = reader["Capital"].ToString(),
                        } : null;
                    }
                }
            }
        }
        public void Update(Gazetter item)
        {
            string sqlExpression = "UPDATE Gazetter SET Country=@country, Square=@square, Population=@population, Continent=@continent, Capital=@capital" +
               " FROM Gazetter" +
               " WHERE Country = @country";

            using (SqliteConnection connection = new SqliteConnection(GazetterContext.AdoSQLiteConnectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqliteParameter[]
                        {
                            new SqliteParameter("@country", item.Country),
                            new SqliteParameter("@square", item.Square),
                            new SqliteParameter("@population", item.Population),
                            new SqliteParameter("@continent", item.Continent),
                            new SqliteParameter("@capital", item.Country),
                        });

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Save(List<Gazetter> gazetters)
        {
            var item = GetAll();
            foreach (var i in item)
                Delete(i.Country);
            foreach (var gazetter in gazetters)
                Create(gazetter);
        }
    }
}
