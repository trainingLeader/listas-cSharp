using listas_cSharp.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        Persona alumno = new Persona();
        bool isOkData = false;
        bool isEmailOk = false;
        List<Persona> personas = new List<Persona>();
        while (isOkData == false){
            Console.Clear();
            try{
                Console.WriteLine("Ingrese El nombre del Alumno");
                alumno.Name = Console.ReadLine() ?? String.Empty;
                if(alumno.Name == String.Empty){
                    continue;
                }
                Console.WriteLine("Ingrese la edad del Alumno");
                alumno.Age = Convert.ToInt32(Console.ReadLine());
                do{
                    Console.WriteLine("Ingrese El Email del Alumno");
                    alumno.Email = Console.ReadLine() ?? String.Empty;
                    isEmailOk = alumno.IsValidEmail(alumno.Email);
                }while(isEmailOk == false);
                personas.Add(alumno);
                isOkData = true;
            }catch(Exception){

            }
        }
        Console.Clear();
        Console.WriteLine("{0,-15} {1,20} {2,30} {3,40}","Codigo","Nombre del alumno","Edad","Correo electronico");
        foreach (Persona person in personas){
            try{
                Console.WriteLine("{0,-15} {1,20} {2,30} {3,30}",person.IdPerson,person.Name,person.Age,person.Email);

            }catch(Exception){
                Console.WriteLine("Error verifique con chat-GPT");
            }
        }
        Console.ReadKey();

    }
}