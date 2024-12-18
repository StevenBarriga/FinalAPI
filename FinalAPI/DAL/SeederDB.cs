﻿
using FinalAPI.DAL.Entities;
using System.Diagnostics.Metrics;

namespace FinalAPI.DAL
{
    public class SeederDB
    {

        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateStudentsAsync();
            await _context.SaveChangesAsync();
        }


        private async Task PopulateStudentsAsync()
        {
            if (!_context.Students.Any())
            {
           
                _context.Students.Add(new Student
                {
                    CreatedDate = DateTime.Now,
                    Name = "steven",
                    Carrera = "sistemas",
                    Celular = 3113675962,
                    Direccion ="cl 45 28 34",
                    Estrato = 2,
                    ContactoEmergencia = "3117130097",
                    Subjects = new List<Subject>()
                    {
                        new Subject
                        {
                            CreatedDate = DateTime.Now,
                            Name = "matematica",
                            Semester = "3",
                            Intensity = 3,
                            Credits = 4,
                          
                        },

                        new Subject
                        {
                            CreatedDate = DateTime.Now,
                            Name = "algebra",
                            Semester = "4",
                            Intensity = 4,
                            Credits= 2,
                                
                        },

                        new Subject
                        {
                            CreatedDate = DateTime.Now,
                            Name = "geometria",
                            Semester = "3",
                            Intensity = 2,
                            Credits= 2,
                        }
                    }
                });

                _context.Students.Add(new Student
                {
                    CreatedDate = DateTime.Now,
                    Name = "Jeferson",
                    Carrera = "sistemas",
                    Celular = 300000000,
                    Direccion = "cl 10 28 34",
                    Estrato = 4,
                    ContactoEmergencia = "3117130091",
                    Subjects = new List<Subject>()
                    {
                        new Subject
                        {
                            CreatedDate = DateTime.Now,
                            Name = "fisica",
                            Semester = "3",
                            Intensity = 3,
                            Credits = 4,
                        }
                    }
                });

            }
        }




    }
}
