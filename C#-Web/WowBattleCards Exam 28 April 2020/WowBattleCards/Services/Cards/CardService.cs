using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowBattleCards.Data;
using WowBattleCards.ViewModels.Cards;

namespace WowBattleCards.Services.Cards
{
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext db;

        public CardService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCardToUserCollection(int cardId, string userId)
        {
            if (this.db.UserCards.Any(x=> x.CardId == cardId && x.UserId == userId))
            {
                return;
            }
            this.db.UserCards.Add(new UserCard { CardId = cardId, UserId = userId });
            this.db.SaveChanges();
        }

        public void CreateCard(CreateCardInputModel inputModel,string userId)
        {
            var newCard = new Card
            {
                Name = inputModel.Name,
                ImageUrl = inputModel.Image,
                Keyword = inputModel.Keyword,
                Attack = inputModel.Attack,
                Health = inputModel.Health,
                Description = inputModel.Description
            };
            this.db.Cards.Add(newCard);
            this.db.UserCards.Add(new UserCard { Card = newCard, UserId = userId });
            this.db.SaveChanges();
        }

        public IEnumerable<AllCardsViewModel> GetAll()
        {
            return this.db.Cards.Select(c => new AllCardsViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Attack = c.Attack,
                Health = c.Health,
                Keyword = c.Keyword,
                ImageUrl = c.ImageUrl

            }).ToList();
        }

        public IEnumerable<AllCardsViewModel> GetAllForCollection(string userId)
        {
            return this.db.UserCards.Where(x => x.UserId == userId).Select(x => new AllCardsViewModel
            {
                Id = x.Card.Id,
                Name = x.Card.Name,
                Keyword = x.Card.Keyword,
                Description = x.Card.Description,
                Attack = x.Card.Attack,
                Health = x.Card.Health,
                ImageUrl = x.Card.ImageUrl
            }).ToList();
        }

        public void RemoveCardFromCollection(string userId, int cardId)
        {
            var targetUserCard = this.db.UserCards.FirstOrDefault(x => x.CardId == cardId && x.UserId == userId);
            this.db.UserCards.Remove(targetUserCard);
            this.db.SaveChanges();
        }
    }
}
