using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public double Saldo { get; set; }
        public ulong NumeroTarjeta { get; set; }
        public String NombreBanco { get; set; }
        public Usuario Usuario { get; set; }
        public String UsuarioId { get; set; }

        public Cuenta() { }

        public Cuenta(int cuentaId, double saldo, ulong numeroTarjeta, string nombreBanco, String usuarioId)
        {
            CuentaId = cuentaId;
            Saldo = saldo;
            NumeroTarjeta = numeroTarjeta;
            NombreBanco = nombreBanco;
            UsuarioId = usuarioId;
        }
    }
}