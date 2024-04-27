using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.SP2024.Lecture5.Controllers
{
    // api/Music
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : Controller
    {
        private List<Music> _Music = new List<Music>();

        public MusicController()
        {
            _Music.Add(new Music { Id = 1, Song = "I Was Made For Lovin' You", Artist = "KISS", ReleaseYear = 1979 });
            _Music.Add(new Music { Id = 2, Song = "Virtual Insanity", Artist = "Jamiroquai", ReleaseYear = 1996 });
            _Music.Add(new Music { Id = 3, Song = "Snake Eater", Artist = "Cynthia Harrell", ReleaseYear = 2004 });
            _Music.Add(new Music { Id = 4, Song = "This Ffffire", Artist = "Franz Ferdinand", ReleaseYear = 2004 });
            _Music.Add(new Music { Id = 5, Song = "Hail to the King", Artist = "Avenged Sevenfold", ReleaseYear = 2013 });
        }


        [HttpGet]
        public ActionResult<IEnumerable<Music>> GetAllMusic()
        {
            return _Music;
        }

        [HttpGet("{id}")]
        public ActionResult<Music> GetMusicById(int id)
        {
            var Music = _Music.FirstOrDefault(v => v.Id == id);

            if (Music == null)
            {
                return NotFound();
            }

            return Music;
        }

        [HttpPost]
        public ActionResult<Music> CreateMusic(Music Music)
        {
            Music.Id = _Music.Max(v => v.Id) + 1;

            _Music.Add(Music);

            return CreatedAtAction(nameof(GetMusicById), new { id = Music.Id }, Music);
        }

        [HttpPut]
        public ActionResult<Music> UpdateMusic(int id, Music updatedMusic)
        {
            var Music = _Music.Find(v => v.Id == id);

            if (Music == null)
            {
                return BadRequest();
            }

            Music.Song = updatedMusic.Song;
            Music.Artist = updatedMusic.Artist;
            Music.ReleaseYear = updatedMusic.ReleaseYear;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteMusic(int id)
        {
            var Music = _Music.Find(v => v.Id == id);

            if (Music == null)
            {
                return NotFound();
            }

            _Music.Remove(Music);

            return NoContent();

        }

    }
}