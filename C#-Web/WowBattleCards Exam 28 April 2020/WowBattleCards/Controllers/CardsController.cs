using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowBattleCards.Services.Cards;
using WowBattleCards.ViewModels.Cards;

namespace WowBattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardService cardService;

        public CardsController(ICardService cardService)
        {
            this.cardService = cardService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var allCards = this.cardService.GetAll();

            return this.View(allCards);
        }
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            this.cardService.AddCardToUserCollection(cardId, userId);
            return this.Redirect("/Cards/All");
        }
        [HttpPost]
        public HttpResponse Add(CreateCardInputModel inputModel)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (inputModel.Name.Length < 5 || inputModel.Name.Length > 15)
            {
                return this.Error("The name must be between 5 and 15 characters!");
            }
            if (inputModel.Description.Length > 200)
            {
                return this.Error("Description have 200 characters max length.");
            }
            if (inputModel.Attack < 0 || inputModel.Health < 0)
            {
                return this.Error("Attack and Health cannot be negative.");
            }
            var userId = this.GetUserId();
            this.cardService.CreateCard(inputModel, userId);

            return this.Redirect("/Cards/All");
        }
        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            var cards = this.cardService.GetAllForCollection(userId);
            return this.View(cards);
        }
        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            this.cardService.RemoveCardFromCollection(userId, cardId);
            return this.Redirect("/Cards/Collection");
        }
    }
}
