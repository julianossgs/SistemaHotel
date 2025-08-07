using System;
using System.Linq;

namespace SistemaHotel.Services
{
    public static class CheckImageEdit
    {
        /// <summary>
        /// Verifica se a imagem foi alterada pelo usuário.
        /// Se não alterada, retorna a original; caso contrário, retorna a nova.
        /// </summary>
        /// <param name="imagemOriginal">Imagem existente no banco.</param>
        /// <param name="imgAtual">Imagem atual do PictureBox.</param>
        /// <returns>Byte array da imagem a ser salva.</returns>
        public static byte[] VerificarImagemEdicao(byte[] imagemOriginal, byte[] imgAtual)
        {
            // Se imagem atual está nula ou vazia, retorna a original
            if (imgAtual == null || imgAtual.Length == 0)
                return imagemOriginal;

            // Se imagem original existe e é igual à atual, retorna original
            if (imagemOriginal != null && imgAtual.SequenceEqual(imagemOriginal))
                return imagemOriginal;

            // Caso contrário, retorna a imagem alterada
            return imgAtual;
        }
    }
}
