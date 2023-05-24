using PracticeNumber2.Domain;

namespace PracticeNumber2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userList = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "Test",
                    Mail = "test@gmail.com",
                    Password = "password",

                },
                new User()
                {
                    Id = 2,
                    Name = "Test2",
                    Mail = "test2@gmail.com",
                    Password = "password2",
                },
                new User()
                {
                    Id = 3,
                    Name = "Test3",
                    Mail = "test3@gmail.com",
                    Password= "password3",
                }
            };

            Console.WriteLine("Bienvenido a las opciones de Usuario!\n");
            Console.WriteLine("Ingrese la opción deseada: \n1- Crear Usuario\n2- Obtener Usuarios\n3- Modificar Usuario\n4- Eliminar Usuario\n");
            Console.Write("Escriba la opción: ");
            var opcion = int.TryParse(Console.ReadLine(), out var opcionElegida);

            while (opcionElegida != 0 && opcionElegida < 5)
            {
                switch (opcionElegida)
                {
                    case 1:
                        //var idPosition = userList[userList.Count - 1].Id;-----> Lo que me dijo Jona                        
                        if(userList.Count == 0)
                        {
                            var newUser = new User();

                            newUser.Id = userList.Count + 1;

                            Console.Write("\nIngrese el nombre: ");
                            newUser.Name = Console.ReadLine();

                            Console.Write("Ingrese el mail: ");
                            newUser.Mail = Console.ReadLine();

                            Console.Write("Ingrese el contraseña: ");
                            newUser.Password = Console.ReadLine();

                            userList.Add(newUser);

                        }
                        else
                        {
                            var newUser = new User();
                            var idPosition = userList.Last().Id; //------> Lo que hice yo.

                            Console.Write("\nIngrese el nombre: ");
                            newUser.Name = Console.ReadLine();

                            Console.Write("Ingrese el mail: ");
                            newUser.Mail = Console.ReadLine();

                            Console.Write("Ingrese el contraseña: ");
                            newUser.Password = Console.ReadLine();

                            newUser.Id = idPosition + 1;

                            userList.Add(newUser);
                        }

                       
                        break;
                    case 2:
                        if(userList.Count > 0)
                        {
                            foreach (var user in userList)
                            {
                                Console.WriteLine("Id: " + user.Id + " // " + "Nombre: " + user.Name + " // " + "Mail: " + user.Mail + " // " + "Contraseña: " + user.Password);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo se encuentran usuarios registrados.");
                        }
                        
                        break;
                    case 3:
                        Console.Write("\nIngrese el Id: ");
                        var id = int.TryParse(Console.ReadLine(), out int idSeleccionado);
                        var userById = userList.Where(x => x.Id == idSeleccionado).FirstOrDefault();
                        if (userById != null)
                        {
                            Console.WriteLine("Id: " + userById.Id + " // " + "Nombre: " + userById.Name + " // " + "Mail: " + userById.Mail + " // " + "Contraseña: " + userById.Password);


                            Console.Write("\nDesea modificarlo? Si/No: ");
                            var respuesta = Console.ReadLine();
                            if (respuesta == "si".ToLower())
                            {

                                Console.Write("\nIngrese el nombre: ");
                                userById.Name = Console.ReadLine();

                                Console.Write("Ingrese el mail: ");
                                userById.Mail = Console.ReadLine();

                                Console.Write("Ingrese el contraseña: ");
                                userById.Password = Console.ReadLine();
                            }
                            Console.WriteLine("Id: " + userById.Id + " // " + "Nombre: " + userById.Name + " // " + "Mail: " + userById.Mail + " // " + "Contraseña: " + userById.Password);
                        }
                        else
                        {
                            Console.WriteLine("\nId no encontrado.");
                        }
                        break;
                    case 4:
                        Console.Write("\nIngrese el Id: ");
                        var idDelete = int.TryParse(Console.ReadLine(), out int idElegido);
                        var userDelete = userList.Where(x => x.Id == idElegido).FirstOrDefault();
                        if(userDelete != null)
                        {
                            Console.WriteLine("Id: " + userDelete.Id + " // " + "Nombre: " + userDelete.Name + " // " + "Mail: " + userDelete.Mail + " // " + "Contraseña: " + userDelete.Password);

                            Console.Write("\nDesea eliminarlo? Si/No: ");
                            var eleccion = Console.ReadLine();
                            if (eleccion == "si".ToLower())
                            {
                                userList.Remove(userDelete);
                                Console.WriteLine("El usuario ha sido eliminado");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nId no encontrado.");
                        }
                        
                        break;
                }

                Console.WriteLine("\nIngrese la opción deseada: \n1- Crear Usuario\n2- Obtener Usuarios\n3- Modificar Usuario\n4- Eliminar Usuario");
                Console.Write("\nEscriba la opción: ");
                opcion = int.TryParse(Console.ReadLine(), out opcionElegida);
            }

            Console.WriteLine("\nOpción incorrecta. El programa ha finalizado!");

            Console.ReadLine();

        }
    }
}