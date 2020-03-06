using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoapp.Models;

namespace todoapp.Data.Configuration
{
    public class TaskConfiguration :IEntityTypeConfiguration<TaskTodo>
    {
        public void Configure(EntityTypeBuilder<TaskTodo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Name).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();

        }
    }
 
}
