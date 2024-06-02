using Microsoft.EntityFrameworkCore;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Infra.Context;

namespace solidariedadeAnonima.Infra.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        public HomeRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        private readonly DataContext _dataContext;

        public async Task<List<CardPrincipal>> GetPrincipalsCardsAsync()
        {
            return await _dataContext.CardPrincipals
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddCardAsync(CardPrincipal card)
        {
            await _dataContext.CardPrincipals.AddAsync(card);
            await _dataContext.SaveChangesAsync();
        }
    }
}
