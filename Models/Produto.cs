using System;

namespace SistemaHotel.Models
{
    public class Produto
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public int IdProduto { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Valor unitário de venda do produto.
        /// </summary>
        public decimal ValorUnit { get; set; }

        /// <summary>
        /// Valor de compra do produto.
        /// </summary>
        public decimal ValorCompra { get; set; }

        /// <summary>
        /// Quantidade atual em estoque.
        /// </summary>
        public decimal Estoque { get; set; }

        /// <summary>
        /// Data/hora de cadastro ou última alteração do produto.
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Imagem do produto (array de bytes).
        /// </summary>
        public byte[] Imagem { get; set; }

        /// <summary>
        /// Identificador do fornecedor vinculado ao produto.
        /// </summary>
        public int IdFornec { get; set; }

        /// <summary>
        /// Nome do fornecedor (opcional, pode ser preenchido em consultas com JOIN).
        /// </summary>
        public string NomeFornecedor { get; set; }
    }
}
