using solidariedadeAnonima.Domain.Entities;

namespace solidariedadeAnonima.Domain.Repositories
{
    public interface IHomeRepository
    {
        Task<List<CardPrincipal>> GetPrincipalsCardsAsync();
        Task AddCardAsync(CardPrincipal card);
    }
}
