using System;
using BuildingsService.Infrastructure.Repositories;

namespace BuildingsService.Infrastructure;

public interface IUnitOfWork
{
    BuildingRepository BuildingsRepository { get; }

    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
