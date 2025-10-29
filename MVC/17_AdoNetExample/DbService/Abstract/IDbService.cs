using _17_AdoNetExample.Models;
using Microsoft.Data.SqlClient;

namespace _17_AdoNetExample.DbService.Abstract
{
    public interface IDbService
    {
        void ExecuteNonQuery(string query);//Sql sorgularını (Insert,Update,Delete) çalıştırmak için kullanılır
        void ExecuteNonQuery(string query, SqlParameter[] parameters);//Parametreli sorgular için overload metot
        List<Student> ExecuteReader(string query);//Select sorgularını çalıştırmak ve sonuçları almak için kullanılır
        object ExecuteScalar(string query);//Tek bir değer döndüren sorgular için kullanılır (count sum avg max min)
    }
}
