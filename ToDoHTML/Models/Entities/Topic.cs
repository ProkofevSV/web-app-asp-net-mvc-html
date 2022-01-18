using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoHTML.Extensions;
using ToDoHTML.Models.Attributes;



namespace ToDoHTML.Models
{
    public class Topic
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название темы
        /// </summary>    
        [Required]
        [Display(Name = "Название темы", Order = 5)]
        public string Name { get; set; }

        
        /// <summary>
        /// Предметы
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Task> Tasks { get; set; }

    }
}