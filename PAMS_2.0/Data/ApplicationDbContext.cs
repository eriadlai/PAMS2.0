
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Navigation;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PAMS_2._0.Models;
using PAMS_2._0.Models.Psicologia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Tabulador = iText.Layout.Element.Tab;

namespace PAMS_2._0.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //OTROS=====================
        public DbSet<Edicion> Edicion { get; set; }

        //PERSONAS=================================
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        //PSICOLOGICO==============================
        public DbSet<AntecedentesClinicos> AntecedentesClinicos { get; set; }
        public DbSet<AntecedentesFamiliares> AntecedentesFamiliares { get; set; }
        public DbSet<CirculoSocial> CirculoSocial { get; set; }
        public DbSet<EstadoMental> EstadoMental { get; set; }
        public DbSet<Familiares> Familiares { get; set; }
        public DbSet<Habitos> Habitos { get; set; }
        public DbSet<HistorialSexual> HistorialSexual { get; set; }
        public DbSet<Problema> Problema { get; set; }
        public DbSet<ReporteSesion> ReporteSesion {get;set;}

        //METODOS USUARIO===================================
        public Boolean VerifyEmail(string email)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaUsuarios = Usuario.Where(usu => usu.email == email);
            if (modelo.listaUsuarios.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean VerifyEmailEdit(Usuario usuario)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaUsuarios = Usuario.Where(usu => usu.email == usuario.email && usu.id != usuario.id);
            if (modelo.listaUsuarios.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public byte[] GetUserByte(Usuario usuario) {

            var user = Usuario.AsNoTracking().Where(usu => usu.id == usuario.id);
            return user.First().foto;
        }
        public string GetUserPass(Usuario usuario) {
            var user = Usuario.AsNoTracking().Where(usu => usu.id == usuario.id);
            return user.First().password;
        }
        
        public IFormFile GetFormFile(IWebHostEnvironment env)
        {

            var filepath = Path.Combine(env.WebRootPath, @"images\" + "Perfil.png");

            using (var stream = System.IO.File.OpenRead($"{filepath}"))
            {
                return new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            }

        }
        public string CleanTelefonoUser(Usuario usuario) {

            usuario.telefono = usuario.telefono.Replace("(", " ");
            usuario.telefono = usuario.telefono.Replace(")", " ");
            usuario.telefono = usuario.telefono.Replace("-", " ");
            usuario.telefono = usuario.telefono.Replace(" ", "");
            return usuario.telefono;
        }
        
       //METODOS DE LOGEO=======================================
        public string HashPassword(string password)
        {
            var prf = KeyDerivationPrf.HMACSHA256;
            var rng = RandomNumberGenerator.Create();
            const int iterCount = 10000;
            const int saltSize = 128 / 8;
            const int numBytesRequested = 256 / 8;

            // Produce a version 3 (see comment above) text hash.
            var salt = new byte[saltSize];
            rng.GetBytes(salt);
            var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; // format marker
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, iterCount);
            WriteNetworkByteOrder(outputBytes, 9, saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
            return Convert.ToBase64String(outputBytes);
        }

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            // Wrong version
            if (decodedHashedPassword[0] != 0x01)
                return false;

            // Read header information
            var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1);
            var iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5);
            var saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

            // Read the salt: must be >= 128 bits
            if (saltLength < 128 / 8)
            {
                return false;
            }
            var salt = new byte[saltLength];
            Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

            // Read the subkey (the rest of the payload): must be >= 128 bits
            var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
            if (subkeyLength < 128 / 8)
            {
                return false;
            }
            var expectedSubkey = new byte[subkeyLength];
            Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            // Hash the incoming password and verify it
            var actualSubkey = KeyDerivation.Pbkdf2(providedPassword, salt, prf, iterCount, subkeyLength);
            return actualSubkey.SequenceEqual(expectedSubkey);
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }

        //METODOS PACIENTE==================================
        public byte[] GetPacienteByte(Paciente paciente)
        {

            var oPaciente = Paciente.AsNoTracking().Where(pac => pac.id == paciente.id);
            return oPaciente.First().foto;
        }
        public string CleanTelefonoPaciente(Paciente paciente)
        {

            paciente.telefono = paciente.telefono.Replace("(", " ");
            paciente.telefono = paciente.telefono.Replace(")", " ");
            paciente.telefono = paciente.telefono.Replace("-", " ");
            paciente.telefono = paciente.telefono.Replace(" ", "");
            return paciente.telefono;
        }
        public Boolean VerifyTelefono(Paciente oPaciente)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaPacientes = Paciente.Where(pac => pac.telefono == oPaciente.telefono && pac.id != oPaciente.id);
            if (modelo.listaPacientes.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetPsicologia(int id) {
            AntecedentesClinicos oClinicos = new AntecedentesClinicos();
            oClinicos.idPaciente = id;
            oClinicos.Patologico = "";
            oClinicos.psicologico = "";
            oClinicos.psiquiatrico = "";
            AntecedentesClinicos.Add(oClinicos);
            AntecedentesFamiliares oFamiliares = new AntecedentesFamiliares();
            oFamiliares.idPaciente = id;
            oFamiliares.accidentes = "";
            oFamiliares.dispAuxiliar = "";
            oFamiliares.enfermedadGrave = "";
            oFamiliares.intervencionQuirurgica = "";
            oFamiliares.medicamentos = "";
            AntecedentesFamiliares.Add(oFamiliares);
            CirculoSocial oCirculo = new CirculoSocial();
            oCirculo.idPaciente = id;
            oCirculo.laboral = "";
            oCirculo.social = "";
            oCirculo.vivienda = "";
            CirculoSocial.Add(oCirculo);
            EstadoMental oEstadoMental = new EstadoMental();
            oEstadoMental.idPaciente = id;
            oEstadoMental.lenguaje = "";
            oEstadoMental.realidad = "";
            oEstadoMental.emocional = "";
            oEstadoMental.higiene = "";
            EstadoMental.Add(oEstadoMental);
            Familiares oParientes = new Familiares();
            oParientes.idPaciente = id;
            oParientes.nombre = "";
            oParientes.apellido = "";
            oParientes.ocupacion = "";
            oParientes.parentesco = "";
            oParientes.nacimiento = DateTime.Now;
            Familiares.Add(oParientes);
            Habitos oHabitos = new Habitos();
            oHabitos.idPaciente = id;
            oHabitos.dream = "";
            oHabitos.antPsicologicos = "";
            oHabitos.alimento = "";
            Habitos.Add(oHabitos);
            HistorialSexual oSexual = new HistorialSexual();
            oSexual.idPaciente = id;
            oSexual.preferenciaSexual = "";
            oSexual.traumas = false;
            oSexual.traumasInfo = "";
            oSexual.abuso = false;
            oSexual.embarazo=false;
            oSexual.edad = 1;
            HistorialSexual.Add(oSexual);
            Problema oProblema = new Problema();
            oProblema.idPaciente = id;
            oProblema.evolucion = "";
            oProblema.acciones = "";
            oProblema.causas = "";
            oProblema.implicaciones = "";
            Problema.Add(oProblema);
            ReporteSesion oReporte = new ReporteSesion();
            oReporte.idPaciente = id;
            oReporte.objetivoClinico = "";
            oReporte.observaciones = "";
            oReporte.diagnostico = "";
            oReporte.notaSesion = "";
            ReporteSesion.Add(oReporte);
            //RELLENAR
            this.SaveChanges();
        }
        public void deleteDatos(int id) {
            ViewModel modelo = new ViewModel();
            modelo.listaAntecedentesClinicos = AntecedentesClinicos.Where(dato =>dato.idPaciente == id);
            foreach(var item in modelo.listaAntecedentesClinicos)
            {
                AntecedentesClinicos.Remove(item);
            }
            modelo.listaAntecedentesFamiliares = AntecedentesFamiliares.Where(dato => dato.idPaciente == id);
            foreach (var item in modelo.listaAntecedentesFamiliares)
            {
                AntecedentesFamiliares.Remove(item);
            }
            modelo.listaCirculoSocial = CirculoSocial.Where(dato => dato.idPaciente == id);
            foreach (var item in modelo.listaCirculoSocial)
            {
                CirculoSocial.Remove(item);
            }
            modelo.listaEstadoMental = EstadoMental.Where(dato => dato.idPaciente == id);
            foreach (var item in modelo.listaEstadoMental)
            {
                EstadoMental.Remove(item);
            }
            modelo.listaFamiliares= Familiares.Where(dato => dato.idPaciente == id);
            foreach (var item in modelo.listaFamiliares)
            {
                Familiares.Remove(item);
            }
            modelo.listaHabitos= Habitos.Where(dato => dato.idPaciente == id);
            foreach (var item in modelo.listaHabitos)
            {
                Habitos.Remove(item);
            }
            modelo.listaHistorialSexual = HistorialSexual.Where(dato => dato.idPaciente == id);
            foreach (var item in modelo.listaHistorialSexual)
            {
                HistorialSexual.Remove(item);
            }
            modelo.listaProblema = Problema.Where(dato => dato.idPaciente == id);
            foreach (var item in modelo.listaProblema)
            {
                Problema.Remove(item);
            }
            modelo.listaReporteSesion = ReporteSesion.Where(dato => dato.idPaciente == id);
            foreach (var item in modelo.listaReporteSesion)
            {
                ReporteSesion.Remove(item);
            }
            this.SaveChanges();

        }
       
        //METODOS GENERALES==========================================
        public byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        public string FormatTelefono(String oTelefono)
        {
            long num;
            bool isNumeric = Int64.TryParse(oTelefono, out num);

            if (oTelefono.Length < 9)
            {
                return "Formato Incorrecto";
            }
            else if (isNumeric)
            {
                string telefono = String.Format("{0:(###) ###-####}", num);
                return telefono;
            }

            return "Formato Incorrecto";
        }
        //PDFPsicologia===============================================
        public void PDF(int id, IWebHostEnvironment env) {
            
            var paciente = Paciente.Find(id);
            var problemas = Problema.Where(item => item.idPaciente == paciente.id);
            var familiares = Familiares.Where(item => item.idPaciente == paciente.id);
            var circuloSocial = CirculoSocial.Where(item => item.idPaciente == paciente.id);
            var historialSexual = HistorialSexual.Where(item => item.idPaciente == paciente.id);
            var habitos = Habitos.Where(item => item.idPaciente == paciente.id);
            var antecedentesClinicos = AntecedentesClinicos.Where(item => item.idPaciente == paciente.id);
            var antecedentesFamiliares = AntecedentesFamiliares.Where(item => item.idPaciente == paciente.id);
            var estadoMental = EstadoMental.Where(item => item.idPaciente == paciente.id);
            var reporteSesion = ReporteSesion.Where(item => item.idPaciente == paciente.id);

            //Fuentes
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            PdfFont font2 = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            var pdfPath= ".\\reportes" + "\\" + paciente.nombre + " " + paciente.apellido + ".pdf";
            var path = Path.Combine(env.WebRootPath,pdfPath);
            
            //titulo
            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Reporte Psicologico")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);
            document.Add(header);
            //subtitulo
            Paragraph subheader = new Paragraph("A " + DateTime.Now)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(15);
            document.Add(subheader);

            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            //parrafo titulo
            Paragraph TituloPaciente = new Paragraph()
                .Add(new Tabulador())
                .Add("Información Del Paciente" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloPaciente);
            //parafo normal -  informacion Paciente
            Paragraph InfoPaciente = new Paragraph()

                .Add(new Text("Nombre: ").SetFont(font2).SetFontSize(12))
                .AddTabStops(new TabStop(300, iText.Layout.Properties.TabAlignment.RIGHT))
                .Add(new Tabulador())
                .Add(paciente.nombre + " " + paciente.apellido + "\n")

                .Add(new Text("Fecha de Nacimiento: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.nacimiento + "\n")

                .Add(new Text("Escolaridad: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.escolaridad + "\n")

                .Add(new Text("Religion: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.religion + "\n")

                .Add(new Text("Ocupación: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.ocupacion + "\n")

                .Add(new Text("Actividades Extra: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.actividadExtra + "\n")
                 .Add(new Text("Dirección: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.direccion + "\n")

                .Add(new Text("Telefono: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.telefono + "\n")

                .Add(new Text("Servicio: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.servicio + "\n")

                .Add(new Text("Asunto: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.asunto + "\n")

                .Add(new Text("Fecha De Registro: ").SetFont(font2).SetFontSize(12))
                .Add(new Tabulador())
                .Add(paciente.fechaRegistro + "\n")
                .SetFont(font).SetFontSize(12);
            document.Add(InfoPaciente);
            //linea
            document.Add(ls);

            //parrafo titulo
            Paragraph TituloProblemas = new Paragraph()
                .Add(new Tabulador())
                .Add("Problemas" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloProblemas);

            //parafo normal -  informacion Problemas
            Paragraph InfoProblemas = new Paragraph()
                .Add(new Text("Evolución: ").SetFont(font2).SetFontSize(12))
                .Add(problemas.First().evolucion + "\n")

                .Add(new Text("Causas: ").SetFont(font2).SetFontSize(12))
                .Add(problemas.First().causas + "\n")


                .Add(new Text("Acciones Realizadas En Busca De Solución: ").SetFont(font2).SetFontSize(12))
                .Add(problemas.First().acciones + "\n")

                .Add(new Text("Implicaciones (a nivel familiar, social, académico, etc.): ").SetFont(font2).SetFontSize(12))
                .Add(problemas.First().implicaciones + "\n")
                .SetFont(font).SetFontSize(12);
            document.Add(InfoProblemas);

            //linea
            document.Add(ls);

            //parrafo titulo
            Paragraph TituloFamiliograma = new Paragraph()
                .Add(new Tabulador())
                .Add("Familiograma" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloFamiliograma);

            //Insertar tabla de familiograma
            Table table = new Table(4, false);

            Cell cell11 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Miembro").SetFont(font2));
            Cell cell12 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Parentesco").SetFont(font2));
            Cell cell13 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Fecha de Nacimiento").SetFont(font2));
            Cell cell14 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Ocupación").SetFont(font2));

            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);

            foreach (var item in familiares)
            {
                Cell cell1 = new Cell(1, 1)
                    .Add(new Paragraph(item.nombre + " " + item.apellido).SetFont(font));

                Cell cell2 = new Cell(1, 1)
                    .Add(new Paragraph(item.parentesco).SetFont(font));

                Cell cell3 = new Cell(1, 1)
                    .Add(new Paragraph(item.nacimiento + "").SetFont(font));

                Cell cell4 = new Cell(1, 1)
                    .Add(new Paragraph(item.ocupacion).SetFont(font));

                table.AddCell(cell1);
                table.AddCell(cell2);
                table.AddCell(cell3);
                table.AddCell(cell4);
            }
            //parrafo donde ira la tabla para poderlo alinear
            Paragraph tabla = new Paragraph()
                .Add(table)
                .SetTextAlignment(TextAlignment.CENTER);
            document.Add(tabla);
            //linea
            document.Add(ls);

            //parrafo titulo
            Paragraph TituloSociales = new Paragraph()
                .Add(new Tabulador())
                .Add("Círculos Sociales" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloSociales);

            //parafo normal -  informacion Redes Sociales
            Paragraph InfoRedSocial = new Paragraph()

                .Add(new Text("Entorno Social: ").SetFont(font2).SetFontSize(12))
                .Add(circuloSocial.First().social + "\n")

                .Add(new Text("Entorno Laboral: ").SetFont(font2).SetFontSize(12))
                .Add(circuloSocial.First().laboral + "\n")

                .Add(new Text("Entorno Familiar/Vivienda: ").SetFont(font2).SetFontSize(12))
                .Add(circuloSocial.First().vivienda + "\n")
                .SetFont(font).SetFontSize(12);
            document.Add(InfoRedSocial);

            //linea
            document.Add(ls);

            //parrafo titulo
            Paragraph TituloAbuso = new Paragraph()
                .Add(new Tabulador())
                .Add("Historial Sexual" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloAbuso);

            //parafo normal -  informacion Abuso sexual
            var abuso = "No";
            var embarazo = "No";
            var traumas = "No";
            var edad = ""+historialSexual.First().edad;
            if (historialSexual.First().abuso) {
                abuso = "Si";
            }
            if (historialSexual.First().embarazo) {
                embarazo = "Si";
            }
            if (historialSexual.First().traumas) {
                traumas = historialSexual.First().traumasInfo;
            }
            else { traumas = "Ninguno"; }
            Paragraph InfoHistorialSexual = new Paragraph()

                
                .Add(new Text("Antecedesntes De Abuso Sexual: ").SetFont(font2).SetFontSize(12))
                .Add(abuso + "\n")

                .Add(new Text("Embarazo: ").SetFont(font2).SetFontSize(12))
                .Add(embarazo + "\n")

                .Add(new Text("Edad: ").SetFont(font2).SetFontSize(12))
                .Add(edad + "\n")

                .Add(new Text("Preferencia Sexual: ").SetFont(font2).SetFontSize(12))
                .Add(historialSexual.First().preferenciaSexual + "\n")

                .Add(new Text("Exposición a eventos traumáticos en ésta area: ").SetFont(font2).SetFontSize(12))
                .Add(traumas).SetFont(font).SetFontSize(12);
            document.Add(InfoHistorialSexual);

            //linea
            document.Add(ls);


            //parrafo titulo
            Paragraph TituloHabitos = new Paragraph()
                .Add(new Tabulador())
                .Add("Hábitos" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloHabitos);

            //parafo normal -  informacion Habitos
            Paragraph InfoHabitos = new Paragraph()

                .Add(new Text("Hábitos De Sueño: ").SetFont(font2).SetFontSize(12))
                .Add(habitos.First().dream + "\n")

                .Add(new Text("Hábitos Alimenticios: ").SetFont(font2).SetFontSize(12))
                .Add(habitos.First().alimento + "\n")

                .Add(new Text("Antecedentes Psicológicos: ").SetFont(font2).SetFontSize(12))
                .Add(habitos.First().antPsicologicos + "\n").SetFont(font).SetFontSize(12);
            document.Add(InfoHabitos);

            //linea
            document.Add(ls);
            //parrafo titulo
            Paragraph TituloClinico = new Paragraph()
                .Add(new Tabulador())
                .Add("Antecedentes Familiares" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloClinico);

            //parafo normal -  informacion Antecedentes Clinicos
            Paragraph InfoAntClinicos = new Paragraph()

                .Add(new Text("Enfermedades Graves: ").SetFont(font2).SetFontSize(12))
                .Add(antecedentesFamiliares.First().enfermedadGrave + "\n")

                .Add(new Text("Accidentes/Lesiones: ").SetFont(font2).SetFontSize(12))
                .Add(antecedentesFamiliares.First().accidentes + "\n")

                .Add(new Text("Medicación: ").SetFont(font2).SetFontSize(12))
                .Add(antecedentesFamiliares.First().medicamentos + "\n")

                .Add(new Text("Intervención Quirúrgica: ").SetFont(font2).SetFontSize(12))
                .Add(antecedentesFamiliares.First().intervencionQuirurgica + "\n")

                .Add(new Text("Dispositivo Auxiliar: ").SetFont(font2).SetFontSize(12))
                .Add(antecedentesFamiliares.First().dispAuxiliar + "\n").SetFont(font).SetFontSize(12);
            document.Add(InfoAntClinicos);

            //linea
            document.Add(ls);

            //parrafo titulo
            Paragraph TituloFamiliares = new Paragraph()
                .Add(new Tabulador())
                .Add("Antecedentes Clinicos" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloFamiliares);

            //parafo normal -  informacion Antecedentes Familiares
            Paragraph InfoAntFamiliares = new Paragraph()

                .Add(new Text("Área Psicológica: ").SetFont(font2).SetFontSize(12))
                .Add(antecedentesClinicos.First().psicologico + "\n")

                .Add(new Text("Área Psiquiátrica: ").SetFont(font2).SetFontSize(12))
                .Add(antecedentesClinicos.First().psiquiatrico + "\n")

                .Add(new Text("Otras Patologia: ").SetFont(font2).SetFontSize(12))
                .Add(antecedentesClinicos.First().Patologico+ "\n").SetFont(font).SetFontSize(12);
            document.Add(InfoAntFamiliares);

            //linea
            document.Add(ls);

            //parrafo titulo
            Paragraph TituloMental = new Paragraph()
                .Add(new Tabulador())
                .Add("Estado Mental" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloMental);

            //parafo normal -  informacion Estado Mental
            Paragraph InfoEstadoMental = new Paragraph()

                .Add(new Text("Percepción Y Lenguaje: ").SetFont(font2).SetFontSize(12))
                .Add(estadoMental.First().lenguaje + "\n")

                .Add(new Text("Estado Emocional: ").SetFont(font2).SetFontSize(12))
                .Add(estadoMental.First().emocional + "\n")

                .Add(new Text("Contacto Con La Realidad: ").SetFont(font2).SetFontSize(12))
                .Add(estadoMental.First().realidad + "\n")

                .Add(new Text("Higiene Y Apariencia Personal ").SetFont(font2).SetFontSize(12))
                .Add(estadoMental.First().higiene + "\n").SetFont(font).SetFontSize(12);
            document.Add(InfoEstadoMental);

            //parrafo titulo
            Paragraph TituloReporte = new Paragraph()
                .Add(new Tabulador())
                .Add("Reporte de Sesion" + "\n")
                .SetFont(font2).SetFontSize(14);
            document.Add(TituloReporte);

            //parafo normal -  informacion Reporte de Sesion
            Paragraph InfoReporteSesion = new Paragraph()

                .Add(new Text("Nota de la Sesion: ").SetFont(font2).SetFontSize(12))
                .Add(reporteSesion.First().notaSesion + "\n")

                .Add(new Text("Impresión Diagnóstica: ").SetFont(font2).SetFontSize(12))
                .Add(reporteSesion.First().diagnostico + "\n")

                .Add(new Text("Observaciones Generales: ").SetFont(font2).SetFontSize(12))
                .Add(reporteSesion.First().observaciones + "\n")

                .Add(new Text("Objetivo Terapeutico ").SetFont(font2).SetFontSize(12))
                .Add(reporteSesion.First().objetivoClinico + "\n").SetFont(font).SetFontSize(12);
            document.Add(InfoReporteSesion);


            //linea
            document.Add(ls);

            PdfExplicitDestination zoomPage = PdfExplicitDestination.CreateXYZ(pdf.GetPage(1),
                  0, 842, 1);
            pdf.GetCatalog().SetOpenAction(zoomPage);
            //final
            document.Close();
            

        }
    }

}
