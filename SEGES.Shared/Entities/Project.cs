﻿using SEGES.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class Project : IEntityWithCreationDate
    {
        public int ProjectId { get; set; }

        [Display(Name = "Nombre Proyecto")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        
        public string ProjectName { get; set; } = "";

        [Display(Name = "Descripción Proyecto")]
        [MaxLength(4000, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string? ProjectDescription { get; set; }

        public DateTime? ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

        [Display(Name = "Fecha de Creación")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public DateTime CreationDate { get; set; }

        public string? StakeHolder_ID { get; set; }
        public UserApp? StakeHolder { get; set; }

        public string? ProjectManager_ID { get; set; }
        public UserApp? ProjectManager { get; set; }

        public string? RequirementsEngineer_ID { get; set; }
        public UserApp? RequirementsEngineer { get; set; }

        public int? ProjectStatus_ID { get; set; }
        public ProjectStatus? ProjectStatus { get; set; }

        public ICollection<Issue>? Issues { get; set; }
        public ICollection<Requirement>? Requirements { get; set; }
        public ICollection<Goal>? Goals { get; set; }
    }
}

