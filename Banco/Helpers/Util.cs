using System;
using SQLite.Net.Async;
using System.Threading.Tasks;
using Banco.Models;
using System.Collections.Generic;

namespace Banco.Helpers
{
    public static class Util
    {
        public async static Task CriarTabelasAsync(SQLiteAsyncConnection db)
        {
            await db.CreateTableAsync<Pessoa>();
        }

        public async static Task CriarPessoa(SQLiteAsyncConnection db)
        {
            await db.InsertAllAsync(new List<Pessoa> {
                new Pessoa { Nome = "Marcos Guedes", Telefone="(81) 98273.9283"},
                new Pessoa { Nome = "Priscila Guedes", Telefone="(81) 99847.9283"}
            });
        }

        public static AsyncTableQuery<Pessoa> ObterPessoas(SQLiteAsyncConnection db, string valorBusca)
        {
            return db.Table<Pessoa>().Where(p => p.Nome.ToLower().Contains(valorBusca.ToLower()));
        }
    }
}
