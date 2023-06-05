using GestionRH.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;


namespace GestionRH.Context
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
    : base(options)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        #region Constructor

        #endregion

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);



        #region Déclaration DbSet
        public virtual DbSet<Credit> Credit { get; set; }
        public virtual DbSet<Conge> Conge { get; set; }
        public virtual DbSet<Autorisation> Autorisation { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Employe> Employees { get; set; }
        #endregion

    }
}
