using solidariedadeAnonima.Domain.Commands.HomeCommand;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Tests.Repositories
{
    public class FakeHomeRepository : IHomeRepository
    {
        private readonly CardPrincipal CardPrincipal = new CardPrincipal
        {
            Title = "Test Card",
            Description = "Description tests",
            ImageLarge = "large.jpg",
            ImageOriginal = "original.jpg",
            ImagePortrait = "portrait.jpg",
            ImageLandscape = "landscape.jpg",
            ImageTiny = "tiny.jpg"
        };

        public Task AddCardAsync(CardPrincipal card)
        {
            return Task.CompletedTask;
        }

        public Task<List<CardPrincipal>> GetPrincipalsCardsAsync()
        {
            var newListCardPrincipal = new List<CardPrincipal>();
            newListCardPrincipal.Add(CardPrincipal);
            return Task.FromResult(newListCardPrincipal);
        }
    }
}
