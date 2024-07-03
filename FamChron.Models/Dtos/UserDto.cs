using FamChron.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamChron.Models.Dtos
{
    public class UserDto : BaseUser
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
