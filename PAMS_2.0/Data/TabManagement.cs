using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Data
{
    public class TabManagement
    {
        public Tab ActiveTab { get; set; }
    }
    public enum Tab
    {
        Pacientes,
        AntecedentesClinicos,
        AntecedentesFamiliares,
        CirculoSocial,
        EstadoMental,
        Familiares,
        Habitos,
        HistorialSexual,
        Problema,
        ReporteSesion
    }
}
