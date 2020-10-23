using System.Collections.Generic;
using WowBattleCards.ViewModels.Cards;

namespace WowBattleCards.Services.Cards
{
    public interface ICardService
    {
        void CreateCard(CreateCardInputModel inputModel, string userId);
        void AddCardToUserCollection(int cardId, string userId);
        IEnumerable<AllCardsViewModel> GetAll();
        IEnumerable<AllCardsViewModel> GetAllForCollection(string userId);
        void RemoveCardFromCollection(string userId, int cardId);
    }
}
