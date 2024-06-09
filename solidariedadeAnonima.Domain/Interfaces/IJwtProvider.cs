using solidariedadeAnonima.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
