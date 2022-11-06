﻿using eTickets.Models;

namespace eTickets.Data.Service
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Actor Update(int id, Actor newActor);
        Task DeleteAsync(int id);
    }
}
