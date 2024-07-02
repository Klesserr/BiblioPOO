using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaPOO
{
    public class Book
    {
        public string Author {  get; set; }
        public string Title { get; set; }
        public int NumberPages { get; set; }
        public StatusPrestamo Status { get; set; }

        public Book() { }

        public Book(string author, string title, int numberPages, StatusPrestamo status)
        {
            Author = author;
            Title = title;
            NumberPages = numberPages;
            Status = status;
        }

        public string Prestamo()
        {
            Status = StatusPrestamo.Prestado;
            return $"El estado actual del libro es : {Status}";

        }

        public string Devolucion()
        {
            Status = StatusPrestamo.Disponible;
            return $"El estado actual del libro es : {Status}";
        }
        public string GetInformationBook()
        {
            return $"Información actual sobre el libro: \n" +
                $"Autor: {Author} \n" +
                $"Titulo: {Title} \n" +
                $"Número de Páginas: {NumberPages} \n" +
                $"Estado: {Status}";
        }
    }

    public enum StatusPrestamo
    {
        Prestado,
        Disponible
    }
}
