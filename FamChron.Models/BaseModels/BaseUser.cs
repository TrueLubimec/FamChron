using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamChron.Models.BaseModels
{
    public abstract class BaseUser
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

    }
}
