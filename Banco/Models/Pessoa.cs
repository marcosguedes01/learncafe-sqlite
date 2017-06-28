using SQLite.Net.Attributes;

namespace Banco.Models
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Telefone}";
        }
    }
}
