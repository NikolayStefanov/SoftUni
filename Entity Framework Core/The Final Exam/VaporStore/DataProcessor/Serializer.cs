using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VaporStore.Data;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
	
	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var employees = context
                .Genres
                .ToArray()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                        .Where(g => g.Purchases.Any())
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                            Players = g.Purchases.Count
                        })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToList(),
                    TotalPlayers = x.Games.SelectMany(g => g.Purchases).Count(),
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return jsonOutput;

        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var targetPurchases = context.Users
                .ToList()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .Select(x => new ExportUserPurchasesDto
                {
                    Username = x.Username,
                    Purchases = x.Cards.SelectMany(c => c.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Select(p => new PurchasesDto
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new GameDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }

                    }).OrderBy(p => DateTime.Parse(p.Date, CultureInfo.InvariantCulture)).ToList(),
                    TotalMoneySpent = x.Cards.SelectMany(c => c.Purchases).Where(p => p.Type.ToString() == storeType).Sum(y => y.Game.Price)
                })
                .Where(x=> x.Purchases.Any())
                .OrderByDescending(x => x.TotalMoneySpent)
                .ThenBy(x => x.Username)
                .ToList();

            var xmlOutput = XmlConverter.Serialize(targetPurchases, "Users");
            return xmlOutput;
			
		}
	}
}
