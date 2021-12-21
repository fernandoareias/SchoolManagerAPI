using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Entities
{
    public abstract class Entity
    {
        protected Entity() {
            this.Id = Guid.NewGuid();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }
    }
}
