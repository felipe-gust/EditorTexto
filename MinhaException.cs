using System;

namespace EditorTexto
{
    public class MinhaException : Exception
    {

        public DateTime QuandoAconteceu { get; set; }
        
        public MinhaException(DateTime date)
        {
            QuandoAconteceu = date;
        }

    }
}