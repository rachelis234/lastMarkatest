using BL.Casting;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TypeLogic
    {
        public static List<TypeDTO> GetTypes()
        {
            using (Entities e=new Entities())
            {
                return TypeCasting.typesToDTO(e.types.ToList());
            }
        }
    }
}
