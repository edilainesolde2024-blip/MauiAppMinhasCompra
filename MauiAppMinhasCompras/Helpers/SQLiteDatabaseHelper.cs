using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection conn;

        public SQLiteDatabaseHelper(string path)
        {
            conn = new SQLiteAsyncConnection(path);
            conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p) 
        {
            return conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? Where Id=?";

            return conn.QueryAsync<Produto>(sql, p.Descicao, p.Quantidade, p.Preco, p.Id);

;        }

        public Task<int> Delete(int id) 
        {
            return conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> GetALL() 
        {
            return conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%" + q + "%'";

            return conn.QueryAsync<Produto>(sql);
        }

    }
}