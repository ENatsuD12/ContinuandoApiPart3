using Mangas.Domain.Entities;

namespace Service.Features.Mangas;

public class MangaService
{
    private readonly List<Manga> _mangas = new();

    public IEnumerable<Manga> GetAll()
    {
        return _mangas;
    }

    public Manga GetById(int id)
    {
        return _mangas.FirstOrDefault(manga => manga.id == id);
    }

    public void add(Manga manga)
    {
        _mangas.Add(manga);
    }

    public void update(Manga mangaToUpdate)
    {
        var manga = GetById(mangaToUpdate.id);
        if (manga != null)
        {
            _mangas.Remove(manga);
            _mangas.Add(mangaToUpdate);
        }
    }

    public void delete(int id)
    {
        var manga = GetById(id);
        if (manga != null)
        {
            _mangas.Remove(manga);
        }
    }
}