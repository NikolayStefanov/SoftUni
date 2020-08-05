namespace MusicHub.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.Albums
                .Where(x=> x.ProducerId == producerId)
                .Select(x=> new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(s=> new 
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("0.00"),
                            Writer = s.Writer.Name
                        }).OrderByDescending(s=> s.SongName).ThenBy(s=> s.Writer),
                    AlbumPrice = x.Songs.Sum(s=> s.Price).ToString("0.00")
                })
                .OrderByDescending(x=> x.AlbumPrice)
                .ToList();
            var resultJson = JsonConvert.SerializeObject(albumsInfo, Formatting.Indented);
            return resultJson;

        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var rootElement = "Songs";
            var wantedDuration = TimeSpan.FromSeconds(duration);
            var targetSongs = context.Songs
                .Where(x => x.Duration > wantedDuration)
                .Select(x => new ExportSongsAboveDurationDto
                {
                    SongName = x.Name,
                    Writer = x.Writer.Name,
                    Performer = x.SongPerformers.FirstOrDefault().Performer.FirstName + " " + x.SongPerformers.FirstOrDefault().Performer.LastName,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })
                .OrderBy(x=> x.SongName)
                .ThenBy(x=> x.Writer)
                .ThenBy(x=> x.Performer)
                .ToList();
            var resultXml = XmlConverter.Serialize(targetSongs, rootElement);

            return resultXml;
        }
    }
}