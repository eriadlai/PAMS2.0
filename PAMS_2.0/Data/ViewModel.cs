using PAMS_2._0.Models;
using PAMS_2._0.Models.Psicologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Data
{
    public class ViewModel
    {
        //PERSONAS============================
        public IEnumerable<Usuario> listaUsuarios { get; set; }
        public IEnumerable<Paciente> listaPacientes { get; set; }
        public Usuario usuario { get; set; }
        public Paciente paciente { get; set; }
        //PSICOLOGIA==========================
        public IEnumerable<AntecedentesClinicos> listaAntecedentesClinicos { get; set; }
        public IEnumerable<AntecedentesFamiliares> listaAntecedentesFamiliares { get; set; }
        public IEnumerable<CirculoSocial> listaCirculoSocial { get; set; }
        public IEnumerable<EstadoMental> listaEstadoMental { get; set; }
        public IEnumerable<Familiares> listaFamiliares { get; set; }
        public IEnumerable<Habitos> listaHabitos { get; set; }
        public IEnumerable<HistorialSexual> listaHistorialSexual { get; set; }
        public IEnumerable<Problema> listaProblema { get; set; }
        public IEnumerable<ReporteSesion> listaReporteSesion { get; set; }
        public AntecedentesClinicos antecedentesClinicos { get; set; }
        public AntecedentesFamiliares antecedentesFamiliares { get; set; }
        public CirculoSocial circuloSocial { get; set; }
        public EstadoMental estadoMental { get; set; }
        public Familiares familiares { get; set; }
        public Habitos habitos { get; set; }
        public HistorialSexual historialSexual { get; set; }
        public Problema problema { get; set; }
        public ReporteSesion reporteSesion { get; set; }
       
        //OTROS===============================
        public string Sesion { get; set; }
        public string rol { get; set; }
        public string imgSesion { get; set; }
        public IEnumerable<Edicion> listaEdicion { get; set; }
        public Edicion ediciont { get; set; }
        public TabManagement tabManagement { get; set; }



    }
}
