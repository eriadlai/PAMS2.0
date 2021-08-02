
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PAMS_2._0.Models;
using PAMS_2._0.Models.Logistica;
using PAMS_2._0.Models.Psicologia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

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
        //LOGISTICA================================
        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<AlmacenProducto> AlmacenProducto { get; set; }

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
            ReporteSesion.Add(oReporte);
            //RELLENAR
            this.SaveChanges();
        }
        //METODOS ALMACEN===================================
        public Boolean VerifyDireccion(string direccion)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaAlmacen = Almacen.Where(alm => alm.direccion == direccion);
            if (modelo.listaAlmacen.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //METODOS PRODUCTO==================================
        public Boolean VerifySku(string sku)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaProducto = Producto.Where(prod => prod.sku == sku);
            if (modelo.listaProducto.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
    }
}
