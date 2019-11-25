using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class UserCasting
    {
        public static user UserToDAL(UserDTO user)
        {
            return new user()
            {
                user_id = user.user_id,
                user_id_number = user.user_id_number,
                user_mail = user.user_mail,
                user_name = user.user_name,
                user_password = user.user_password,
                status = user.status,
                // classes =e.classes.Where(c=>c.class_id==)
            };
        }
        public static UserDTO UserToDTO(user user)
        {
            return new UserDTO()
            {
                user_id = user.user_id,
                user_id_number = user.user_id_number,
                user_password = user.user_password,
                user_name = user.user_name,
                user_mail = user.user_mail,
                status = user.status
            };
        }
        public static List<user> UsersToDAL(List<UserDTO> usersDTO)
        {
            List<user> users = new List<user>();
            usersDTO.ToList().ForEach(u => users.Add(UserToDAL(u)));
            return users;
        }
        public static List<UserDTO> UsersToDTO(List<user> users)
        {
            List<UserDTO> usersDTO = new List<UserDTO>();
            users.ToList().ForEach(u => usersDTO.Add(UserToDTO(u)));
            return usersDTO;
        }
    }
}