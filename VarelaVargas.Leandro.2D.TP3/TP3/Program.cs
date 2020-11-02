using Archivos;
using Clases_Instanciables;
using EntidadesAbstractas;
using System;
using static Clases_Instanciables.Universidad;
using static EntidadesAbstractas.Persona;

namespace TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            uni += a1;
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
                uni += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
                uni += a3;
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }

            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);
            uni += a4;
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);
            uni += a5;
            Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
            uni += a6;
            Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.AlDia);
            uni += a7;
            Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);
            uni += a8;
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12224458",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            uni += i1;
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            uni += i2;

            try
            {
                uni += Universidad.EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                uni += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                uni += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {

                uni += Universidad.EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine(uni.ToString());
            Console.ReadKey();
            Console.Clear();
            
            try
            {
                Universidad.Guardar(uni);
                Console.WriteLine("Archivo de Universidad guardado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                int jornada = 0;
                Jornada.Guardar(uni[jornada]);
                Console.WriteLine("Archivo de Jornada {0} guardado.", jornada);
                //Console.WriteLine(Jornada.Leer());
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            */

            Console.ReadKey();
         
        }
    }
}

/* Pruebas Personales (Alumno):
Alumno a1 = new Alumno (1, "Juan", "Lopez", "12234456",
EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
Alumno.EEstadoCuenta.Becado);

Alumno a2 = new Alumno(1, "Juan", "Lopez", "12234456",
EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
Alumno.EEstadoCuenta.Becado);

Console.WriteLine(a1);
Console.WriteLine("a1 == a2 (true): " + (a1 == a2));
Console.WriteLine("a1 != a2 (false): " + (a1 != a2) );

Console.WriteLine("a1 == Programacion (true): " + (a1 == Universidad.EClases.Programacion));
Console.WriteLine("a1 != Programacion (false): " + (a1 != Universidad.EClases.Programacion));
*/

/* Pruebas Personales (Profesor)
Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
Alumno.EEstadoCuenta.Becado);
Profesor i1 = new Profesor(1, "Juan", "Lopez", "12224458",
EntidadesAbstractas.Persona.ENacionalidad.Argentino);
//uni += i1;
Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
EntidadesAbstractas.Persona.ENacionalidad.Argentino);
//uni += i2;

Console.WriteLine(i1);

Console.WriteLine("i1 == i2 (false): " + (i1 == i2) );
Console.WriteLine("i1 != i2 (true): " + (i1 != i2) );
Console.WriteLine("i1 == a1 (false): " + (i1 == a1));
*/

/* Pruebas Personales (Archivos)

Text guardarAlumno = new Text();
string textoLeido;

string pathText = @"C:\Users\lean\Desktop\archivo.txt";

guardarAlumno.Guardar(pathText, new Alumno(0, "A", "B", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia).ToString());

Console.WriteLine(guardarAlumno.Leer(pathText, out textoLeido));

Console.WriteLine(textoLeido);

*************************************************
Xml<Alumno> guardarAlumno = new Xml<Alumno>();
Alumno alumnoLeido;

string pathXML = @"C:\Users\lean\Desktop\archivo.xml";

guardarAlumno.Guardar(pathXML, new Alumno(0, "A", "B", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia));

Console.WriteLine(guardarAlumno.Leer(pathXML, out alumnoLeido));

Console.WriteLine(alumnoLeido);

*/

/* Pruebas Personales (Jornada)
    Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
    EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
    Alumno.EEstadoCuenta.Becado);

    Alumno a2 = new Alumno(2, "Juan", "Lopez", "15234456",
    EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
    Alumno.EEstadoCuenta.Becado);

    Profesor p1 = new Profesor(3, "AAA", "AAA", "24435460", Persona.ENacionalidad.Argentino);

    Jornada j = new Jornada(Universidad.EClases.Laboratorio, p1);

    if ( j+a1 && j+a2 )
    {
        Jornada.Guardar(j);
        Console.WriteLine(Jornada.Leer());
    }
 */

/* Pruebas Personales (Universidad)
    Alumno aUno = new Alumno(0, "AA", "AA", "29384732", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
    Alumno aDos = new Alumno(1, "BB", "BB", "25460392", ENacionalidad.Argentino, EClases.Programacion);
    Alumno aTres = new Alumno(2, "CC", "CC", "56437869", ENacionalidad.Argentino, EClases.Legislacion);
    Alumno aCuatro = new Alumno(3, "DD", "DD", "93452934", ENacionalidad.Extranjero, EClases.Laboratorio);

    Profesor pUno = new Profesor(1, "AA", "NN", "54435434", Persona.ENacionalidad.Argentino);
            
    Universidad uni = new Universidad();

    uni += aUno;
    uni += aDos;
    uni += aTres;
    uni += aCuatro;
    uni += pUno;
    uni += pUno;

    try
    {
        uni += EClases.Laboratorio;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    try
    {
        uni += EClases.SPD;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    try
    {
        uni += EClases.Programacion;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    try
    {
        uni += EClases.Legislacion;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine(uni);
 */