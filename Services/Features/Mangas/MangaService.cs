using Mangas.Domain.Entities;
using Mangas.Infrastructure.Repositories;

namespace Mangas.Service.Features.Mangas;

public class MangaService
{
    private readonly MangaRepository _mangaRepository;

    public MangaService(MangaRepository mangaRepository)
    {
        this._mangaRepository = mangaRepository;
    }

    public IEnumerable<Manga> GetAll()
    {
        return _mangaRepository.GetAll();
    }

    public Manga GetById(int id)
    {
        return _mangaRepository.GetById(id);
    }

    public void add(Manga manga)
    {
        _mangaRepository.Add(manga);
    }

    public void update(Manga mangaToUpdate)
    {
        var manga = GetById(mangaToUpdate.id);
        if (manga.id > 0)
        {
            _mangaRepository.Update(mangaToUpdate);
        }
    }

    public void delete(int id)
    {
        var manga = GetById(id);
        if (manga != null)
        {
            _mangaRepository.Delete(id);
        }
    }
}