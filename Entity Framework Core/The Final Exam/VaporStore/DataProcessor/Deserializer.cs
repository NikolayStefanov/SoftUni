namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private const string ErrorMessage = "Invalid Data";
		private const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";
		private const string SuccessfullyImportedUser = "Imported {0} with {1} cards";
		private const string SuccessfullyImportedPurchase = "Imported {0} for {1}";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
			var outputResult = new StringBuilder();

			var gamesDtos = JsonConvert.DeserializeObject<List<ImportGameDto>>(jsonString);

            foreach (var gameDto in gamesDtos)
            {
				DateTime releaseDate; 
                if (IsValid(gameDto) && gameDto.Tags.Any() && DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate))
				{
					var newGame = new Game
					{
						Name = gameDto.Name,
						Price = gameDto.Price,
						ReleaseDate = releaseDate
					};

					Developer developerToAdd;

                    if (!context.Developers.Any(d=> d.Name.ToLower() == gameDto.Developer.ToLower()))
                    {
						developerToAdd = new Developer
						{
							Name = gameDto.Developer
						};
                    }
                    else
                    {
						developerToAdd = context.Developers.First(x => x.Name == gameDto.Developer);
                    }
					newGame.Developer = developerToAdd;

					Genre genreToAdd;

                    if (!context.Genres.Any(g=> g.Name == gameDto.Genre))
                    {
						genreToAdd = new Genre
						{
							Name = gameDto.Genre
                        };
                    }
                    else
                    {
						genreToAdd = context.Genres.First(g => g.Name == gameDto.Genre);
                    }

					newGame.Genre = genreToAdd;

                    foreach (var tagName in gameDto.Tags.Distinct())
                    {
						Tag tagToAdd;
                        if (!context.Tags.Any(t=> t.Name == tagName))
                        {
							tagToAdd = new Tag
							{
								Name = tagName
							};
                        }
                        else
                        {
							tagToAdd = context.Tags.First(t => t.Name == tagName);
                        }
						newGame.GameTags.Add(new GameTag { Tag = tagToAdd, Game = newGame });
                    }
					context.Games.Add(newGame);
					outputResult.AppendLine(string.Format(SuccessfullyImportedGame, newGame.Name, newGame.Genre.Name, newGame.GameTags.Count));
					context.SaveChanges();
                }
                
                else
                {
					outputResult.AppendLine(ErrorMessage);
                }
            }

			return outputResult.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var outputResult = new StringBuilder();
			var validUsersToAdd = new List<User>();

			var usersDtos = JsonConvert.DeserializeObject<ImportUsersAndCardsDto[]>(jsonString);

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto) || !userDto.Cards.Any())
                {
					outputResult.AppendLine(ErrorMessage);
					continue;
                }
				var newUser = new User
				{
					Username = userDto.Username,
					FullName = userDto.FullName,
					Email = userDto.Email,
					Age = userDto.Age
				};
				var isWrongCard = false;
                foreach (var cardDto in userDto.Cards)
                {
					CardType cardType;
					var isCardTypeValid = Enum.TryParse<CardType>(cardDto.Type, true, out cardType);

					if (!IsValid(cardDto) || !isCardTypeValid)
                    {
						outputResult.AppendLine(ErrorMessage);
						isWrongCard = true;
						break;
                    }
					newUser.Cards.Add(new Card { Number = cardDto.Number, Cvc = cardDto.Cvc, Type =  cardType});
                }
                if (isWrongCard)
                {
					continue;
                }
				validUsersToAdd.Add(newUser);
				outputResult.AppendLine(string.Format(SuccessfullyImportedUser, newUser.Username, newUser.Cards.Count));
            }
			context.Users.AddRange(validUsersToAdd);
			context.SaveChanges();
			return outputResult.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var outputResult = new StringBuilder();
			var validPurchasesToAdd = new List<Purchase>();

			var purchasesDtos = XmlConverter.Deserializer<ImportPurchaseDto>(xmlString, "Purchases");

            foreach (var purchaseDto in purchasesDtos)
            {
				PurchaseType purchaseType;
				var isGenreValid = Enum.TryParse<PurchaseType>(purchaseDto.Type, true, out purchaseType);

				var targetGame = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);
				var targetCard = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                if (!IsValid(purchaseDto) || targetGame == null || !isGenreValid || targetCard == null)
                {
					outputResult.AppendLine(ErrorMessage);
					continue;
                }
				var newPurchase = new Purchase
				{
					Game = targetGame,
					Type = purchaseType,
					ProductKey = purchaseDto.ProductKey,
					Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Card = targetCard
				};
				validPurchasesToAdd.Add(newPurchase);
				outputResult.AppendLine(string.Format(SuccessfullyImportedPurchase, newPurchase.Game.Name, newPurchase.Card.User.Username));
            }
			context.AddRange(validPurchasesToAdd);
			context.SaveChanges();
			return outputResult.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}