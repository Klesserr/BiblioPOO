using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaPOO
{
    public class Library
    {
        public List<Book> ColectionBooks { get; set; }
        public List<User> UserList { get; set; }

        public Library() { }

        public Library(List<Book> colectionBooks, List<User> userList)
        {
            ColectionBooks = colectionBooks;
            UserList = userList;
        }
        /*Muestra la información de todos los libros DE LA LIBRERIA*/
        public void GetAllBooks()
        {
            foreach(var book in ColectionBooks)
            {
                Console.WriteLine(book.GetInformationBook());
                Console.WriteLine("_");
            }
        }

        /*GetAllUsers: Muestra la información de todos los usuarios DE LA LIBRERIA*/
        public void GetAllUsers()
        {
            foreach(var user in UserList)
            {
                Console.WriteLine(user.GetInformationUsers());
                Console.WriteLine("_");
            }
        }
        /*GetBooksAvaiables: Nos devuelve una lista de los libros que se encuentran en la libreria con estado DISPONIBLE*/
        public List<Book> GetBooksAvaiables()
        {
            return ColectionBooks.Where(l => l.Status == StatusPrestamo.Disponible).ToList();
        }
        /*RegisterUser: Permite Registrar un usuario en la lista de la libreria*/
        public void RegisterUser(User user)
        {
            UserList.Add(user);
        }
        /*AddBooks: Permite agregar un libro en la lista de la libreria*/
        public void AddBooks(Book book)
        {
            ColectionBooks.Add(book);
        }
        /*GiveBook: Comprueba que el estado del libro este Disponible. En caso afirmativo llama al método->user.AddBook
         user.AddBook: Cambia el estado del libro a Prestado y SE AÑADE A LA LISTA DE LIBROS PRESTADOS que tiene el usuario.
         OJO:Este método(user.AddBook) no cambia el estado del libro de la LIBRERIA. Si lo hace del listado de libros del usuario.
         Informamos sobre el libro que se va a devolver y después hacemos una Query con LinQ.

         La Query se basa en buscar el primer libro en ColectionBooks(lista de Libros de LA clase LIBRERIA) y comprobar que coincidan 
         el titulo del libro con el titulo del libro que pasamos por parámetro.En caso de que sea así(es decir, será diferente
         de null),cambiaremos el estado del libro SOBRE LA LISTA DE LIBROS DE LA LIBRERIA.*/
        public void GiveBook(User user, Book book)
        {
            if (book.Status == StatusPrestamo.Disponible)
            {
                user.AddBook(book); //Este método cambia el estado del libro.(Explicación del método en la Clase User línea 21).
                Console.WriteLine($"LIBRO ENTREGADO AL USUARIO:");
                Console.WriteLine(book.GetInformationBook());
                var result = ColectionBooks.FirstOrDefault(b => b.Title == book.Title);
                
                if (result != null) //Result es una variable de tipo libro.
                {
                    result.Status = StatusPrestamo.Prestado; 
                }
                /*for(int j = 0; j < ColectionBooks.Count; j++)
                {
                    if(book.Title == ColectionBooks[j].Title)
                    {
                        book.Status = StatusPrestamo.Prestado;
                        break;
                        Mismo codigo que arriba pero sin usar LinQ
                    }
                }*/
            }
            else
            {
                Console.WriteLine($"El libro solicitado no se encuentra disponible.");
            }
        }
        /*GiveBackBook:En caso de que el libro que pasamos por parámetro se encuentre Prestado, llamamos al método -> user.RemoveBook.
         user.RemoveBook elimina el libro DE LA LISTA DE LIBROS PRESTADOS DE LA CLASE User.Seguidamente, nos muestra la información.
         Después hacemos la misma Query lanzada como en el anterior método y en caso de que sea distinto de NULL, cambiamos el estado del 
         libro a disponible DE LA LISTA DE LIBROS DE LA LIBRERIA*/
        public void GiveBackBook(User user, Book book)
        {
            //var result = UserList.Where(i => i.Id == user.Id).ToList();
            if (book.Status == StatusPrestamo.Prestado)
            {
                user.RemoveBook(book);
                Console.WriteLine($"LIBRO DEVUELTO DEL USUARIO");
                Console.WriteLine(book.GetInformationBook());
                var result = ColectionBooks.FirstOrDefault(b => b.Title == book.Title);
                if (result != null)
                //Cambiamos el valor del estado de la lista de libros a disponible.
                {
                    book.Status = StatusPrestamo.Disponible;
                }

            }
            //La comprobacion del IF sobra.Ya que cuando vamos a devolver un libro no se comprueba el estado
        }
        /*DisponibilityBook: Pasamos por parámetro un libro para saber el estado en el que se encuentra.*/
        public void DisponibilityBook(Book book)
        {
            if (book.Status == StatusPrestamo.Disponible)
            {
                Console.WriteLine($"El Libro {book.Title} se encuentra disponible");
            }
            else if (book.Status == StatusPrestamo.Prestado)
            {
                Console.WriteLine($"El libro {book.Title} esta prestado");
            }
        }
    }
}
