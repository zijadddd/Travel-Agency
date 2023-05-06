namespace Travel_Agency.Services {
    public interface ICRUDService<T> {
        Task<T> Create(T value);
        Task<T> Read(T value);
        Task<T> Update(T value);
        Task<T> Delete(T value);
    }
}
