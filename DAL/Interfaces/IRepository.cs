﻿namespace VSTest.DAL.Interfaces;

public interface IRepository<TEntity> : IReadonlyRepository<TEntity> where TEntity : class
{
    void Insert(TEntity entity);
    void Delete(TEntity entity);
}