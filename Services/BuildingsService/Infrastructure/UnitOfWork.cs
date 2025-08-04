using System;
using BuildingsService.Infrastructure.Data;
using BuildingsService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BuildingsService.Infrastructure;

public class UnitOfWork(BuildingsContext context) : IUnitOfWork
{
    private readonly BuildingsContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private BuildingRepository? _buildingsRepository;

    private IDbContextTransaction? _transaction;
    private bool _disposed = false;

    public BuildingRepository BuildingsRepository
    {
        get
        {
            return _buildingsRepository ??= new BuildingRepository(_context);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _context.Dispose();
            _disposed = true;
        }
    }
}
