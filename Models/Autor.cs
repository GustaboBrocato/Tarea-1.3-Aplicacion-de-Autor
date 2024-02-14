﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1._3_Aplicacion_de_Autor.Models
{
    [SQLite.Table("Autor")]
    public class Autor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255), NotNull]
        public string? Nombres { get; set; }

        [MaxLength(255), NotNull]
        public string? Nacionalidad { get; set; }
        public string? Foto { get; set; }
    }
}
