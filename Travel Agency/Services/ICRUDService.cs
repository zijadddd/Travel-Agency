namespace Travel_Agency.Services {
    public interface ICRUDService<T> {
        Task<dynamic> Create(T value);
        Task<dynamic> Read(T value);
        Task<dynamic> Update(T value);
        Task<dynamic> Delete(T value);
    }
}
