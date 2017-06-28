using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using System.IO;
using System.Threading.Tasks;

namespace AndroidLib.Helpers
{
    public class Util
    {
        public async static Task<SQLiteAsyncConnection> GetConexaoAsync()
        {
            string applicationFolderPath =
                Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "CanFindLocation");

            Directory.CreateDirectory(applicationFolderPath);

            string databaseFileName = Path.Combine(applicationFolderPath,"config.db");

            var pathDBLocal = databaseFileName;
            var stringConn = new SQLiteConnectionString(pathDBLocal, true);

            var db = new SQLiteAsyncConnection(()=> 
                new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), stringConn)
            );

            await Banco.Helpers.Util.CriarTabelasAsync(db);

            return db;
        }
    }
}