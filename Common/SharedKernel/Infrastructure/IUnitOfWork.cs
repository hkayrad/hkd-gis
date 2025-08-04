using System;

namespace HKD.GIS.SharedKernel.Infrastructure;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
