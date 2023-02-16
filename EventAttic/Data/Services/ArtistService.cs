using EventAttic.Data.Base;
using EventAttic.Models;


namespace EventAttic.Data.Services
{
    public class ArtistService : EntityBaseRepository<Artist>, IArtistService
    {
        public ArtistService(ApplicationDbContext context) : base(context)
        {
        }

        //public async Task AddAsync(Artist artist)
        //{
        //    _context.Artists.AddAsync(artist);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var deleteArtist = _context.Artists.FirstOrDefault(a => a.Id == id);

        //    await _context.Artists.Remove(deleteArtist);
        //    await _context.SaveChangesAsync();
        //}

        //public Task<Artist> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Artist> UpdateAsync(int id, Artist newArtist)
        //{
        //    _context.Update(newArtist);
        //    await _context.SaveChangesAsync();
        //    return newArtist;
        //}

    }
}
