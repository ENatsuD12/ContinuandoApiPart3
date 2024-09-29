using System.Text.Json;
using Mangas.Domain.Entities;

namespace Mangas.Infrastructure.Repositories;
    public class MangaRepository
    {
        private List<Manga> _mangas;
        private string _filePath;

        public MangaRepository(IConfiguration configuration)
        {
            _filePath = configuration.GetValue<string>("dataBank") ?? string.Empty;
            _mangas = LoadData();
        }

        private string GetCurrentFilePath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentFilePath = Path.Combine(currentDirectory, _filePath);

            return currentFilePath;
        }

        private List<Manga> LoadData()
        {
            var currentFilePath = GetCurrentFilePath();
            if (File.Exists(currentFilePath))
            {
                var jsonData = File.ReadAllText(currentFilePath);
                return JsonSerializer.Deserialize<List<Manga>>(jsonData);
            }
            return new List<Manga>();
        }

        public IEnumerable<Manga> GetAll()
        {
            return _mangas;
        }

        public Manga GetById(int id)
        {
            return _mangas.Find(Manga => Manga.id == id) 
                ?? new Manga {
                    Title = string.Empty,
                    Author = string.Empty
                    };
        }

        public void Add(Manga manga)
        {
            _mangas.Add(manga);
            var filePath = GetCurrentFilePath();
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, JsonSerializer.Serialize(_mangas));
            }
        }

        public void Update(Manga updatedManga)
        {
            var index = _mangas.FindIndex(m => m.id == updatedManga.id);
            if (index != -1)
            {
                _mangas[index] = updatedManga;
                var filePath = GetCurrentFilePath();
                if (File.Exists(filePath))
                {
                    File.WriteAllText(filePath, JsonSerializer.Serialize(_mangas));
                }
            }
        }

        public void Delete(int id)
        {
            _mangas.RemoveAll(m => m.id == id);
            var filePath = GetCurrentFilePath();
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, JsonSerializer.Serialize(_mangas));
            }
        }
    }