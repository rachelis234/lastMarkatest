using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL.Casting
{
    public class TypeCasting
    {
        public static type TypeToDAL(TypeDTO t)
        {
            return new type()
            {
                type_id = t.type_id,
                type_name = t.type_name,
                //questions = e.questions.Where(q => q.type_id == tdto.type_id).ToList()
            };
        }
        public static TypeDTO TypeToDTO(type tdal)
        {
            return new TypeDTO()
            {
                type_id = tdal.type_id,
                type_name = tdal.type_name,
            };

        }
        public static List<type> typesToDAL(List<TypeDTO> tdto)
        {
            List<type> types = new List<type>();
            tdto.ToList().ForEach(t => types.Add(TypeToDAL(t)));
            return types;
        }
        public static List<TypeDTO> typesToDTO(List<type> tdto)
        {
            List<TypeDTO> typies = new List<TypeDTO>();
            tdto.ToList().ForEach(t => typies.Add(TypeToDTO(t)));
            return typies;
        }
    }
}
