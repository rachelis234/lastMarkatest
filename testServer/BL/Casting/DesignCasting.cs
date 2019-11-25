using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class DesignCasting
    {
        public static design DesignToDAL(DesignDTO d)
        {
            return new design()
            {
                design_id = d.design_id,
                //teachers = teachers.Where(t => t.design_id == d.design_id).ToList()
            };
        }
        public static DesignDTO DesignToDTO(design d)
        {
            return new DesignDTO()
            {
                design_id = d.design_id
            };
        }
        public static List<design> DesignsToDAL(List<DesignDTO> designsDTO)
        {
            List<design> designs = new List<design>();
            designsDTO.ToList().ForEach(d => designs.Add(DesignToDAL(d)));
            return designs;
        }
        public static List<DesignDTO> DesignsToDTO(List<design> designs)
        {
            List<DesignDTO> designsDTO = new List<DesignDTO>();
            designs.ToList().ForEach(d => designsDTO.Add(DesignToDTO(d)));
            return designsDTO;
        }
    }
}
