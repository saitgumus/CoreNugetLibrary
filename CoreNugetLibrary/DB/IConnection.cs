namespace SG.Kernel.DB
{
    public interface IConnection<T> where T:new()
    {
        public abstract void Open();
        public abstract void Close();
        public abstract T GetConnection(string database);
    }

}