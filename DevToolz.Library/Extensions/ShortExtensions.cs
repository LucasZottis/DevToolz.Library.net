namespace DevToolz.Library.Extensions
{
    public static class ShortExtensions
    {
        public static char ToChar( this short valor )
        {
            if ( valor.Between( 0, 10 ) )
                throw new ArgumentException( "Valor informado não é um número. Valor deve ser um número de 0 à 9." );

            return valor.ToString().ToChar();
        }

        /// <summary>
        /// Verifica se um valor está na faixa entre dois números informados.
        /// </summary>
        /// <Param name="value">Valor a ser verificado.</Param>
        /// <Param name="lowestValue">Menor valor da faixa.</Param>
        /// <Param name="highestValue">Maior valor da faixa.</Param>
        /// <returns>Retorna true se estive entre o intervalo.</returns>
        public static bool Between( this short value, short lowestValue, short highestValue, bool inclusive = true )
        {
            if ( inclusive )
                return value >= lowestValue && value <= highestValue;

            return value > lowestValue && value < highestValue;
        }
    }
}