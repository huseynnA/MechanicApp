using DataAccess.Entites;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IAdminService:IBaseService<AdminDTO,Admin,AdminDTO>
    {
      
        public AdminDTO SignIn(AdminDTO adminDTO);
        
    }
}
