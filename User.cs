using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaPOO
{
    public class User
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<Book> ListaPrestados { get; set; }
        public User() { }
        public User(string name, string id, List<Book> listaPrestados)
        {
            Name = name;
            Id = id;
            ListaPrestados = listaPrestados;
        }
        /*AddBook: Cambiamos el estado del libro de Disponible a Prestado, lo añadimos a nuestra lista de libros prestados*/
        public void AddBook(Book book)
        {
            book.Status = StatusPrestamo.Prestado;
            ListaPrestados.Add(book);   
        }
        /*RemoveBook: Viene llamado desde el método GiveBackBook de la clase Library. Si el estado del libro
         es Prestado, entonces se eliminara de la lista de prestados, previamente cambiaremos su estado a disponible.*/
        public void RemoveBook(Book book)
        {
            book.Status = StatusPrestamo.Disponible;
            ListaPrestados.Remove(book); 
        }
        public string GetInformationUsers()
        {
            return $"Información sobre los usuarios de la Biblioteca: \n" +
                $"Nombre: {Name}\n" +
                $"Id: {Id}\n" +
                $"Lista de libros Prestados: {ListaPrestados}\n";
        }

    }
}
