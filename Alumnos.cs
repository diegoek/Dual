using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dual
{
    class Alumnos
    {
        private int idAlumno;
        private string matrícula;
        private string nombreCompleto;
        private string semestre;
        private string modalidad;
        private string celular;
        private string correo;

        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        public string Matrícula { get => matrícula; set => matrícula = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public string Semestre { get => semestre; set => semestre = value; }
        public string Modalidad { get => modalidad; set => modalidad = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
