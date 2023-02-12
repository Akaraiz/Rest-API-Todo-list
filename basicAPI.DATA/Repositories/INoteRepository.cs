using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basicAPI.Model;

namespace basicAPI.Data.Repositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllNotes();

        Task<Note> GetDetails(int id);

        Task<bool> InsertNote(Note note);

        Task<bool> UpdateNote(Note note);

        Task<bool> DeleteNote(Note note);


    }
}
