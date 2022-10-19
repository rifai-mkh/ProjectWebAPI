﻿namespace MyBackend.DAL
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        //Task<T> GetBy(int id);
        
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task Delete(int id);
    }
}