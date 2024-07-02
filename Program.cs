namespace BibliotecaPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RentalBooks();
            //Pruebas();
            RentalBooks2();
        }
        public static void RentalBooks()
        {
            /*Console.WriteLine($"Bienvenido/a a tu Biblioteca Virtual");
            //Creación de 6 libros, una lista y agregamos a cada uno a dicha lista.
            Book b1 = new Book("J.R.R Tolkien","El señor de los Anillos: Las Dos Torres",435,"disponible");
            Book b2 = new Book("J.K. Rowling","Harry Potter y la piedra filosofal",250,"prestado");
            Book b3 = new Book("George Martin","Juego de Tronos",650,"disponible");
            Book b4 = new Book("Brandon Sanderson","El camino de los Reyes",890,"disponible");
            Book b5 = new Book("Patrick Rothfuss","El nombre del Viento",720,"prestado");
            Book b6 = new Book("Andrzej Sapowski","Ultimo Deseo",270,"disponible");

            List<Book> listBooks = new List<Book>();
            listBooks.Add(b1);
            listBooks.Add(b2);
            listBooks.Add(b3);
            listBooks.Add(b4);
            listBooks.Add(b5);
            listBooks.Add(b6);

            //Creamos 4 usuarios, y también los agregamos a una lista de usuarios.
            User u1 = new User("Marcos","1",listBooks);
            User u2 = new User("Ana","2",listBooks);
            User u3 = new User("Paula","3",listBooks);
            User u4 = new User("David","4",listBooks);

            List<User> listUsers = new List<User>();
            listUsers.Add(u1);
            listUsers.Add(u2);
            listUsers.Add(u3);
            listUsers.Add(u4);

            //Creamos la clase Libreria y enseñaremos en un primer momento toda la información que tenemos hasta el momento.
            Library library = new Library(listBooks, listUsers);
            Console.WriteLine($"LIBROS DISPONIBLES EN NUESTRA BIBLIOTECA :");
            List<Book> aviableBooks = library.GetBooksAvaiables();
            int count = 1;
            foreach (var b in aviableBooks)
            {
                Console.WriteLine($"Libro: {count}");
                Console.WriteLine(b.GetInformationBook());
                count++;
            }
            Console.WriteLine($"USUARIOS DE NUESTRA BIBLIOTECA: ");
            foreach(var u in listUsers)
            {
                Console.WriteLine(u.GetInformationUsers());//Lista de libros ilegible: System.Collections
            }
            library.GiveBook(u1, b2);
            Console.WriteLine("--");
            library.GiveBackBook(u1, b2);
            Console.WriteLine("//////////////////////////////////////");

            /*PREGUNTA: No me sale el libro de harry potter una vez devuelto y su estado se encuentra en disponible.
             Me sale cuando comento la linea 28 del metodo AddBook de la clase User.

            //aviableBooks = library.GetBooksAvaiables(); //Necesaria esta linea?
            //foreach(var b in aviableBooks) //Ya que si hago sobre listBooks, me escoge a todos.
            //{
            //    Console.WriteLine(b.GetInformationBook());
            //    Console.WriteLine("--");
            //}

            Console.WriteLine($"LIBROS QUE TIENE EL USUARIO: {u1.Name}");
            int contadorNuevo = 1;
            /*Considero que esto no es coger los libros que tiene el usuario prestado.
             Sino hacer una query que te escoge todos los libros que tengan el estado prestado.
            List<Book> listBooksNotAviable = listBooks.Where(b => b.Status == StatusPrestamo.Prestado).ToList();
            List<Book> nuevaListaDePrueba = new List<Book>(); 
            //foreach(var b in listBooksNotAviable)
            //{
            //    Console.WriteLine(b.GetInformationBook());
            //    Console.WriteLine("--");
            //}
            
            for(int i =0; i < listBooks.Count; i++)
            {
                if (u1.ListaPrestados[i].Status == StatusPrestamo.Prestado)
                {
                    library.GiveBackBook(u1, listBooks[i]);
                }
            }

            foreach(var l in nuevaListaDePrueba)
            {
                Console.WriteLine(l.GetInformationBook());
                Console.WriteLine("---");
            }*/
        }
        public static void Pruebas()
        {
            //Creacion de libros.
            Book l1 = new Book("Tolkien", "Anillos", 332, StatusPrestamo.Disponible);
            Book l2 = new Book("Rowling", "Harry", 100, StatusPrestamo.Prestado);

            //Creacion de Lista de libros.
            List<Book> listaDeLibros = new List<Book>();
            listaDeLibros.Add(l1);
            listaDeLibros.Add(l2);
            //Impresion de todos los libros
            foreach (var l in listaDeLibros)
            {
                Console.WriteLine(l.GetInformationBook());
                Console.WriteLine("--");
            }
            //Creamos una nueva lista de libros, de usuarios y un nuevo un usuario
            List<Book> nuevaLista = new List<Book>();
            User user = new User("Jesus", "1", listaDeLibros);

            List<User> listaUsuarios = new List<User>();
            listaUsuarios.Add(user);

            Console.WriteLine($"Libros que tiene el usuario: {user.Name}");
            Console.WriteLine();
            //Añadimos o eliminamos el libro l1, segun su status. Cambiamos el status del l2 y hacemos lo mismo.
            user.AddBook(l1);
            l2.Devolucion(); //Cambiamos el estado a disponible
            user.AddBook(l2);//Cambiamos el estado a prestado y lo agregamos a la lista de libros de usuario.
            //Comprobamos que el usuario tiene 2 libros en posesion.

            foreach (var l in nuevaLista) //Si aqui pongo user.ListaPrestado me sale igual, a que se debe?
            {
                Console.WriteLine($"{l.GetInformationBook()}");
                Console.WriteLine("______");
            }
            Console.WriteLine($"Devolucion de uno de los 2 libros y luego impresion sobre el total de los libros: ");
            //Cambiamos el estado de disponible a prestado y eliminamos el libro. Después recorremos de nuevo la lista
            //Y comprobamos que solo queda1.
            l1.Prestamo();
            //user.RemoveBook(nuevaLista, l1);
            foreach (var l in user.ListaPrestados)
            {
                Console.WriteLine($"{l.GetInformationBook()}");
            }
            Library libreria = new Library(listaDeLibros,listaUsuarios);
            Console.WriteLine($"LISTA DE TODOS LOS LIBROS: ");
            int i = 1;
            foreach (var l in libreria.ColectionBooks)
            {
                Console.WriteLine($"Libro : {i}");
                Console.WriteLine(l.GetInformationBook());
                i++;
            }
            Console.WriteLine($"LISTA DE TODOS LOS USUARIOS");
            foreach(var l in libreria.UserList)
            {
                Console.WriteLine($"Usuario numero: {l.Id}");
                Console.WriteLine(l.GetInformationUsers());
            }
            l1.Devolucion();
            l2.Devolucion();
            Console.WriteLine($"LISTADO FINAL DE LOS LIBROS: ");
            foreach(var l in user.ListaPrestados)
            {
                Console.WriteLine(l.GetInformationBook());
            }
            libreria.GiveBook(user, l1);
            libreria.GiveBook(user, l2);

            Console.WriteLine($"DEVOLUCION DE UN LIBRO A LA BIBLIOTECA: ");
            libreria.GiveBackBook(user, l1);
            Console.WriteLine($"ESTADO DE LOS LIBROS: ");

            libreria.DisponibilityBook(l1);
            libreria.DisponibilityBook(l2);
        }

        public static void RentalBooks2()
        {
            Console.WriteLine($"Bienvenido/a a tu Biblioteca Virtual");
            //Creación de 6 libros, una lista y agregamos a cada uno a dicha lista.
            Book b1 = new Book("J.R.R Tolkien", "El señor de los Anillos: Las Dos Torres", 435, StatusPrestamo.Disponible);
            Book b2 = new Book("J.K. Rowling", "Harry Potter y la piedra filosofal", 250, StatusPrestamo.Prestado);
            Book b3 = new Book("George Martin", "Juego de Tronos", 650, StatusPrestamo.Disponible);
            Book b4 = new Book("Brandon Sanderson", "El camino de los Reyes", 890, StatusPrestamo.Disponible);
            Book b5 = new Book("Patrick Rothfuss", "El nombre del Viento", 720, StatusPrestamo.Prestado);
            Book b6 = new Book("Andrzej Sapowski", "Ultimo Deseo", 270, StatusPrestamo.Disponible);

            List<Book> listBooks = new List<Book>();
            listBooks.Add(b1);
            listBooks.Add(b2);
            listBooks.Add(b3);
            listBooks.Add(b4);
            listBooks.Add(b5);
            listBooks.Add(b6);

            List<Book> listU1 = new List<Book>();
            listU1.Add(b2);//Lista con 1 solo libro y estado Prestado.
            List<Book> listU2 = new List<Book>();
            listU2.Add(b5);//Lista con 1 solo libro y estado Prestado.
            List<Book> listU4 = new List<Book>();


            //Creamos 4 usuarios, y también los agregamos a una lista de usuarios.
            User u1 = new User("Marcos", "1", listU1);
            User u2 = new User("Ana", "2", listU2);
            User u3 = new User("Paula", "3", new List<Book>());
            User u4 = new User("David", "4", new List<Book>());

            List<User> listUsers = new List<User>();
            /*El u1 y u2, contienen listas de libros con un libro cada una con Status = Prestado.
             En cambio u3 y u4, contienen una lista vacía.*/
            listUsers.Add(u1);
            listUsers.Add(u2);
            listUsers.Add(u3);
            listUsers.Add(u4);

            /*Creamos la clase Libreria y enseñaremos en un primer momento toda la información que tenemos hasta el momento.
              Pasamos como argumento el listado de los 6 libros agregados a la listBooks y la lista de usuarios
              con sus respectivas listas de libros.*/
            Library library = new Library(listBooks, listUsers); 

            List<Book> listAvaiables = library.GetBooksAvaiables();
            Console.WriteLine($"LISTA DE LIBROS DISPONIBLES: ");
            foreach(var b in listAvaiables)
            {
                Console.WriteLine(b.GetInformationBook());
                Console.WriteLine("--");
            }
            /*Mostramos los libros que tiene el usuario2 en propiedad. Actualmente tan solo tiene 1,
             el de Patrick Rothfuss.*/
            Console.WriteLine($"LIBROS EN PROPIEDAD DEL USUARIO : {u2.Name}");
            foreach (var b in u2.ListaPrestados)
            {
                Console.WriteLine(b.GetInformationBook());
                Console.WriteLine("-");
            }
            /*Usamos el método GiveBook: es decir, le pasamos por parámetro el usuario que queremos que obtenga un nuevo libro
              y el libro que queremos que obtenga. En caso de que el estado del libro sea DISPONIBLE, le cambiara el estado y lo 
              agregará AL LISTADO DE LIBROS DEL USUARIO como libro prestado. En este caso el user2, obtendrá el libro 1 EN SU PROPIA
              LISTA DE LIBROS.
            
              Después, llamamos al método GiveBackBook que devolverá el libro que tiene el usuario EN SU PROPIA LISTA DE LIBROS en caso de que
              el estado de dicha libro sea Prestado y esto nos cambiará el estado a Disponible EN LA LISTA DE LA LIBRERIA para que otro usuario
              pueda volver a cogerlo.*/
            
            library.GiveBook(u2, b1);
            Console.WriteLine("----------------------------------");
            library.GiveBackBook(u2, b5); 
            Console.WriteLine("----------------------------------");

            /*Mostramos el listado de libros de la biblioteca una vez realizado las transacciones. Como podemos comprobar
              en un primer momento el libro de el señor de los anillos se encuentra Disponible y más adelante pasa a Prestado.
              Además como ahora enseñamos TODOS los libros independientemente de su estado, también observamos como el de Harry Potter
              también sale como Prestado*/
            Console.WriteLine($"TODOS LOS LIBROS DE LA BIBLIOTECA: ");
            foreach (var b in listBooks)
            {
                Console.WriteLine(b.GetInformationBook());
                Console.WriteLine("-......._------");
            }
        }


    }
}
