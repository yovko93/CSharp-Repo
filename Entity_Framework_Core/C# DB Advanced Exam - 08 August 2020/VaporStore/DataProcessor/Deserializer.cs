namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var games = JsonConvert.DeserializeObject<IEnumerable<GameJsonImportModel>>(jsonString);

            foreach (var currentGame in games)
            {
                if (!IsValid(currentGame) ||
					!currentGame.Tags.Any())
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var genre = context.Genres.FirstOrDefault(x => x.Name == currentGame.Genre)
					?? new Genre { Name = currentGame.Genre };

				var developer = context.Developers.FirstOrDefault(x => x.Name == currentGame.Developer)
					?? new Developer { Name = currentGame.Developer };

				var game = new Game
				{
					Name = currentGame.Name,
					Price = currentGame.Price,
					ReleaseDate = currentGame.ReleaseDate.Value,
					Developer = developer,
					Genre = genre,
				};
                foreach (var jsonTag in currentGame.Tags)
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag)
						?? new Tag { Name = jsonTag };

					game.GameTags.Add(new GameTag { Tag = tag });
                }

				context.Games.Add(game);
				context.SaveChanges();
				sb.AppendLine($"Added {currentGame.Name} ({currentGame.Genre}) with {currentGame.Tags.Count()} tags");
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();
			var users = new List<User>();

			var usersDto = JsonConvert.DeserializeObject<IEnumerable<UserJsonInputModel>>(jsonString);

            foreach (var jsonUser in usersDto)
            {
                if (!IsValid(jsonUser) ||
					!jsonUser.Cards.All(IsValid) ||
					!jsonUser.Cards.Any())
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var user = new User
				{
					Username = jsonUser.Username,
					FullName = jsonUser.FullName,
					Email = jsonUser.Email,
					Age = jsonUser.Age,
					Cards = jsonUser.Cards.Select(x => new Card
					{
						Number = x.Number,
						Cvc = x.CVC,
						Type = x.Type.Value,
					})
					.ToList()
				};

				users.Add(user);
				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseXmlInputModel[]), new XmlRootAttribute("Purchases"));

			var purchases = (PurchaseXmlInputModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var xmlPurchase in purchases)
            {
                if (!IsValid(xmlPurchase))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var parsedDate = DateTime.TryParseExact(
					xmlPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

				if (!parsedDate)
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				var purchase = new Purchase
				{
					Type = xmlPurchase.Type.Value,
					ProductKey = xmlPurchase.Key,
					Date = date,
					Card = context.Cards.FirstOrDefault(x => x.Number == xmlPurchase.Card),
					Game = context.Games.FirstOrDefault(x => x.Name == xmlPurchase.Title)
				};

				var username = context.Users.Where(x => x.Id == purchase.Card.UserId).Select(x => x.Username).FirstOrDefault();

				context.Purchases.Add(purchase);
				context.SaveChanges();

				sb.AppendLine($"Imported {xmlPurchase.Title} for {username}");
            }

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}