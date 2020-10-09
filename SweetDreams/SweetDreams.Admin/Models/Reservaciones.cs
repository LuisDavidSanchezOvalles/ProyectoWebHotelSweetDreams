﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Admin.Models
{
    public class Reservaciones
    {
        public int ReservacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Tarjeta { get; set; }
        public string Codigo { get; set; }
        public decimal Balance { get; set; }

        public List<ReservacionesDetalle> ReservacionDetalle { get; set; }

        public Reservaciones()
        {
            ReservacionId = 0;
            FechaInicio = DateTime.Now;
            FechaSalida = DateTime.Now;
            FechaExpiracion = DateTime.Now;
            Tarjeta = string.Empty;
            Codigo = string.Empty;
            Balance = 0;
            ReservacionDetalle = new List<ReservacionesDetalle>();
        }

        public Reservaciones(int reservacionId, DateTime fechaInicio, DateTime fechaSalida, DateTime fechaExpiracion, string tarjeta, string codigo, decimal balance, List<ReservacionesDetalle> reservacionDetalle)
        {
            ReservacionId = reservacionId;
            FechaInicio = fechaInicio;
            FechaSalida = fechaSalida;
            FechaExpiracion = fechaExpiracion;
            Tarjeta = tarjeta;
            Codigo = codigo;
            Balance = Balance;
            ReservacionDetalle = reservacionDetalle;
        }
    }
}
