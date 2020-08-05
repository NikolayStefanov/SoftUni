namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var outputResult = new StringBuilder();
            var resultWritersDtos = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);
            var newWriters = new List<Writer>();

            foreach (var writerDto in resultWritersDtos)
            {
                if (!IsValid(writerDto))
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }
                var newWriter = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };
                newWriters.Add(newWriter);

                outputResult.AppendLine(string.Format(SuccessfullyImportedWriter, newWriter.Name));
            }

            context.Writers.AddRange(newWriters);
            context.SaveChanges();

            return outputResult.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var outputResult = new StringBuilder();
            var realProducers = new List<Producer>();

            var deserializedProducerWithAlbums = JsonConvert.DeserializeObject<ImportProducerAndAlbumsDto[]>(jsonString);

            foreach (var deserializedProducer in deserializedProducerWithAlbums)
            {
                var newAlbums = new List<Album>();
                if (!IsValid(deserializedProducer) || !deserializedProducer.Albums.All(IsValid))
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }
                var newProducer = new Producer
                {
                    Name = deserializedProducer.Name,
                    Pseudonym = deserializedProducer.Pseudonym,
                    PhoneNumber = deserializedProducer.PhoneNumber
                };

                foreach (var album in deserializedProducer.Albums)
                {
                    var newAlbum = new Album
                    {
                        Name = album.Name,
                        ReleaseDate = DateTime.ParseExact(album.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };
                    newProducer.Albums.Add(newAlbum);
                }
                string message = newProducer.PhoneNumber == null
                    ? string.Format(SuccessfullyImportedProducerWithNoPhone, newProducer.Name, newProducer.Albums.Count)
                    : string.Format(SuccessfullyImportedProducerWithPhone, newProducer.Name, newProducer.PhoneNumber, newProducer.Albums.Count);

                outputResult.AppendLine(message);
                realProducers.Add(newProducer);
            }

            context.Producers.AddRange(realProducers);
            context.SaveChanges();

            return outputResult.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var outputString = new StringBuilder();
            var importSongsRootName = "Songs";
            var resultXmlDtos = XmlConverter.Deserializer<ImportSongDto>(xmlString, importSongsRootName);

            var songsToAdd = new List<Song>();

            foreach (var songDto in resultXmlDtos)
            {
                Genre givenGenre;
                var isGenreValid = Enum.TryParse(songDto.Genre, true, out givenGenre);

                var isAlbumIdValid = context.Albums.Any(x=> x.Id == songDto.AlbumId) || songDto.AlbumId == null;
                var isWriterIdValid = context.Writers.Any(x => x.Id == songDto.WriterId);

                if (!IsValid(songDto) || !isGenreValid || !isAlbumIdValid || !isWriterIdValid)
                {
                    outputString.AppendLine(ErrorMessage);
                    continue;
                }
                var newSong = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = givenGenre,
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };
                songsToAdd.Add(newSong);
                outputString.AppendLine(string.Format(SuccessfullyImportedSong, newSong.Name, newSong.Genre.ToString(), newSong.Duration.ToString()));
            }
            context.Songs.AddRange(songsToAdd);
            context.SaveChanges();

            return outputString.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var outputResult = new StringBuilder();
            var songPerformersRootName = "Performers";
            var songPerformersDtos = XmlConverter.Deserializer<ImportSongPerformersDto>(xmlString, songPerformersRootName);

            var realPerformers = new List<Performer>();

            foreach (var songPerformerDto in songPerformersDtos)
            {
                var areAllSongsValid = true;
                foreach (var songId in songPerformerDto.Songs)
                {
                    if (context.Songs.All(x=> x.Id != songId.SongId))
                    {
                        areAllSongsValid = false;
                        break;
                    }
                }
                if (!IsValid(songPerformerDto) || !areAllSongsValid)
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }
                var newPerformer = new Performer
                {
                    FirstName = songPerformerDto.FirstName,
                    LastName = songPerformerDto.LastName,
                    Age = songPerformerDto.Age,
                    NetWorth = songPerformerDto.NetWorth

                };

                foreach (var songId in songPerformerDto.Songs)
                {
                    var existedSong = context.Songs.FirstOrDefault(x=> x.Id == songId.SongId);

                    newPerformer.PerformerSongs.Add(new SongPerformer { Performer = newPerformer, Song = existedSong });
                }
                realPerformers.Add(newPerformer);
                outputResult.AppendLine(string.Format(SuccessfullyImportedPerformer, newPerformer.FirstName, newPerformer.PerformerSongs.Count));
            }
            context.Performers.AddRange(realPerformers);
            context.SaveChanges();
            return outputResult.ToString().TrimEnd();
        }
        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}