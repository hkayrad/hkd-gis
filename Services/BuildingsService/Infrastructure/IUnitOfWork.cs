using System;
using BuildingsService.Infrastructure.Repositories;

namespace BuildingsService.Infrastructure;

public interface IUnitOfWork
{
    IBuildingRepository BuildingsRepository { get; }
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}