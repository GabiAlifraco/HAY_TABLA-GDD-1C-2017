using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    public class Turno
    {
        public Turno()
        {

        }

        public Turno(string descripcion, DateTime horaInicio, DateTime horaFin, decimal precioBase, decimal valorKm)
        {
           
            this.descripcion = descripcion;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.precioBase = precioBase;
            this.valorKm = valorKm;
          
        }

        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        private DateTime horaInicio;
        public DateTime HoraInicio
        {
            get
            {
                return this.horaInicio;
            }
            set
            {
                this.horaInicio = value;
            }
        }

        private DateTime horaFin;
        public DateTime HoraFin
        {
            get
            {
                return this.horaFin;
            }
            set
            {
                this.horaFin = value;
            }
        }

        private decimal precioBase;
        public decimal PrecioBase
        {
            get
            {
                return this.precioBase;
            }
            set
            {
                this.precioBase = value;
            }
        }

        private decimal valorKm;
        public decimal ValorKm
        {
            get
            {
                return this.valorKm;
            }
            set
            {
                this.valorKm = value;
            }
        }

    }

}

