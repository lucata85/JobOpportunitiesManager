using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataBaseServices : IDataBaseServices
    {
        private readonly string _connectionString;

        public DataBaseServices()
        {
            _connectionString = new Connection().GetConnectionStrings();
        }

        #region Job Opportunity

        public bool CreateJobOpportunity(JobOpportunity jobOpportunity)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO JobOpportunities VALUES (@p1, @p2, @p3, @p4)", con);

                    command.Parameters.AddWithValue("@p1", jobOpportunity.Title);
                    command.Parameters.AddWithValue("@p2", jobOpportunity.Description);
                    command.Parameters.AddWithValue("@p3", jobOpportunity.Salary);
                    command.Parameters.AddWithValue("@p4", DateTime.Now);

                    int rows = command.ExecuteNonQuery();

                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<JobOpportunity> JobOpportunities()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    List<JobOpportunity> jobOpportunities = new List<JobOpportunity>();

                    SqlCommand command = new SqlCommand("SELECT * FROM JobOpportunities", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        JobOpportunity job = new JobOpportunity
                        {
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            Description = reader["Description"].ToString(),
                            Title = reader["Title"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"].ToString()),
                            CreatedOn = Convert.ToDateTime(reader["CreatedOn"])
                        };

                        jobOpportunities.Add(job);
                    }

                    return jobOpportunities;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteJobOpportunity(int idJob)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM JobOpportunities WHERE Id = @p1", con);

                    command.Parameters.AddWithValue("@p1", idJob);

                    int rows = command.ExecuteNonQuery();

                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public JobOpportunity GetJobOpportunity(int idJob)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    JobOpportunity job = new JobOpportunity();

                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM JobOpportunities WHERE Id = @p1", con);

                    command.Parameters.AddWithValue("@p1", idJob);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        job.Id = Convert.ToInt32(reader["Id"].ToString());
                        job.Description = reader["Description"].ToString();
                        job.Title = reader["Title"].ToString();
                        job.Salary = Convert.ToDecimal(reader["Salary"].ToString());
                        job.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                    }

                    return job;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Candidate

        public bool CreateCandidate(Candidate candidate, int idJob)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Candidates VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10); SELECT SCOPE_IDENTITY();", con);

                    command.Parameters.AddWithValue("@p1", candidate.Name);
                    command.Parameters.AddWithValue("@p2", candidate.LastName);
                    command.Parameters.AddWithValue("@p3", candidate.IdCard);
                    command.Parameters.AddWithValue("@p4", candidate.Email);
                    command.Parameters.AddWithValue("@p5", candidate.Phone);
                    command.Parameters.AddWithValue("@p6", candidate.BirthDay);
                    command.Parameters.AddWithValue("@p7", candidate.Genre);
                    command.Parameters.AddWithValue("@p8", candidate.Address);
                    command.Parameters.AddWithValue("@p9", candidate.State);
                    command.Parameters.AddWithValue("@p10", candidate.City);

                    int idCandidate = Convert.ToInt32(command.ExecuteScalar());

                    command.Parameters.Clear();

                    command.CommandText = "INSERT INTO JobsCandidates VALUES (@p1, @p2)";

                    command.Parameters.AddWithValue("@p1", idJob);
                    command.Parameters.AddWithValue("@p2", idCandidate);

                    int rows = command.ExecuteNonQuery();

                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region JobsCandidates

        public List<Candidate> GetCandidatesByJobOpportunity(int idJob)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    List<Candidate> candidates = new List<Candidate>();

                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT c.* FROM JobsCandidates as jc " +
                        "INNER JOIN Candidates as c " +
                        "ON jc.IdCandidate = c.Id" +
                        " WHERE jc.IdJob = @p1", con);

                    command.Parameters.AddWithValue("@p1", idJob);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var candidate = new Candidate
                        {
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Address = reader["Address"].ToString(),
                            BirthDay = Convert.ToDateTime(reader["BirthDay"].ToString()),
                            City = reader["City"].ToString(),
                            Email = reader["Email"].ToString(),
                            Genre = reader["Genre"].ToString(),
                            IdCard = reader["IdCard"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            State = reader["State"].ToString(),
                        };

                        candidates.Add(candidate);
                    }

                    return candidates;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
