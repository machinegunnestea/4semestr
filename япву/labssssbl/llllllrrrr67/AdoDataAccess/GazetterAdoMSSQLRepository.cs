using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdoDataAccess
{
    public class GazetterAdoMSSQLRepository
    {
        public void Create(Gazetter item)
        {
            string sqlExpression = $"INSERT INTO Gazetter (Country, Square, Population, Continent, Capital)" +
                " VALUES (@country, @square, @population, @continent, @capital);";

            using (SqlConnection connection = new SqlConnection(GazetterContext.AdoMSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@country", item.Country),
                            new SqlParameter("@square", item.Square),
                            new SqlParameter("@population", item.Population),
                            new SqlParameter("@continent", item.Continent),
                            new SqlParameter("@capital", item.Country),

                        });

                    command.ExecuteNonQuery();
                }
            }

        }
        public void Delete(string country)
        {
            string sqlExpression = "DELETE FROM Gazetter WHERE Country=@country";

            using (SqlConnection connection = new SqlConnection(GazetterContext.AdoMSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlParameter typeParam = new SqlParameter("@country", country);
                    command.Parameters.Add(typeParam);

                    command.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<Gazetter> GetAll()
        {
            string sqlExpression = "SELECT Country, Square, Population, Continent, Capital FROM Gazetter";
            List<Gazetter> gazetters = new List<Gazetter>();

            using (SqlConnection connection = new SqlConnection(GazetterContext.AdoMSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gazetters.Add(new Gazetter()
                            {
                                Country = (string)reader["Country"],
                                Square = (double)reader["Square"],
                                Population = (double)reader["Population"],
                                Continent = (string)reader["Continent"],
                                Capital = (string)reader["Capital"],
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
            using (SqlConnection connection = new SqlConnection(GazetterContext.AdoMSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlParameter idParam = new SqlParameter(@"country", country);
                    command.Parameters.Add(idParam);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read() ? new Gazetter()
                        {
                            Country = (string)reader["Country"],
                            Square = (double)reader["Square"],
                            Population = (double)reader["Population"],
                            Continent = (string)reader["Continent"],
                            Capital = (string)reader["Capital"],
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

            using (SqlConnection connection = new SqlConnection(GazetterContext.AdoMSSQLConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("@country", item.Country),
                            new SqlParameter("@square", item.Square),
                            new SqlParameter("@population", item.Population),
                            new SqlParameter("@continent", item.Continent),
                            new SqlParameter("@capital", item.Country),
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
