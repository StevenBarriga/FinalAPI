using FinalAPI.DAL;
using FinalAPI.DAL.Entities;
using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization;

namespace FinalAPI.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //metoso llamado seederasync es una especie de metodo main()
        //este metodo tiene la responsabilidad de prepoblar las tablas de la base de datos

        public async Task SeederAsync()
        {
            // primero se agrega un metodo propop de entitty framework que hace las veces del comando de ipdateDataBase
            // es un metodo que creara la base de datos automaticamente
            await _context.Database.EnsureCreatedAsync();

            // a partir de aqui se van creando metodos que sirvern para prepoblar la base de datod
            await PopulateStudentsAsync();
            await _context.SaveChangesAsync();  //esta linea me guarda los datos en base de datos

        }

        #region Private Methos

        private async Task PopulateStudentsAsync()
        {
            if (!_context.Students.Any())
            {
                //asi se crea un objeto pais con sus estados
                _context.Students.Add(new Student
                {
                    CreatedDate = DateTime.Now,
                    Name = "Steven Barriga",
                    Subjects = new List<Subject>()
                    {
                        new Subject
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Matematicas"
                        },

                        new Subject
                        {
                            CreatedDate = DateTime.Now,
                            Name = "ingles"
                        },

                        new Subject
                        {
                            CreatedDate = DateTime.Now,
                            Name = "fisica"
                        }
                    }
                });

                //asi se crea otro objeto pais con sus estados
                _context.Students.Add(new Student
                {
                    CreatedDate = DateTime.Now,
                    Name = "Jeferson Mejia",
                    Subjects = new List<Subject>()
                    {
                        new Subject
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Matematicas"
                        }
                    }
                });

            }

        }

        #endregion

    }
}
