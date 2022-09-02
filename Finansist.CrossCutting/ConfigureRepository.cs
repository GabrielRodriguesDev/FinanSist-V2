﻿using Finansist.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansist.CrossCutting
{
    public class ConfigureRepository
    {
        public static void ConfigureDI(IServiceCollection services)
        { var connection = "Server=localhost;Port=3306;Database=Finansist;Uid=root;Pwd=fx870";
            services.AddDbContext<FinansistContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)).LogTo(Console.Write));
            services.AddScoped<FinansistContext, FinansistContext>();
        }
    }
}
