
namespace HotelDataA.DataBase
{
    public interface IDapAcasses
    {
        List<T> loedData<T, P>(string sql, P parm, string csName, bool IsProcedure = false);
        void Save<T>(string sql, T parm, string csName, bool IsProcedure = false);
    }
}