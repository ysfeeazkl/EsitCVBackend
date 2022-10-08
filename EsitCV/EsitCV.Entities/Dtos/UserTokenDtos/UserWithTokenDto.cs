using EsitCV.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.UserTokenDtos
{
    public class UserWithTokenDto
    {
        public UserDto User { get; set; }
        public UserTokenDto Token { get; set; }
    }
}
