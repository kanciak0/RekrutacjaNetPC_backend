namespace NetPcRekrutacjaBackend.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}