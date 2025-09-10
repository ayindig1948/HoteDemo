
namespace SqliteData
{
    public interface IDataAcsesLite
    {
        List<T> LoadData<T, P>(string sql, P par, string cString);
        void Save<T>(string sql, T data, string cString);
    }
}