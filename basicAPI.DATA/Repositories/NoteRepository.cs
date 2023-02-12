using basicAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicAPI.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {

        private readonly MySQLConfiguration _connectionString;
        public NoteRepository(MySQLConfiguration connectionString) 
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteNote(Note note)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM note WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = note.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM note";

            return await db.QueryAsync<Note>(sql, new { });
        }

        public async Task<Note> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, data FROM note WHERE id = @Id";

            return await db.QuerySingleOrDefaultAsync<Note>(sql, new {Id = id });
        }

        public async Task<bool> InsertNote(Note note)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO `note` (`data`) VALUES (@Data) ";
            //var sq3213l = @"INSERT INTO `note`(`id`, `data`) VALUES ('[value-1]','[value-2]')";

            var result = await db.ExecuteAsync(sql, new { note.Data });

            return result > 0;
        }

        public async Task<bool> UpdateNote(Note note)
        {
            var db = dbConnection();
            var sql = @"UPDATE note SET data = @Data WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { note.Data, note.Id});

            return result > 0;
        }
    }
}
