using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoTF.security
{
    public class PasswordHasher
    {
        private static string HashPassword(string password, string salt)
        {
            //salt 666
            // 将密码和盐合并
            string saltedPassword = password + salt;

            // 创建SHA-256哈希算法对象
            using (SHA256 sha256 = SHA256.Create())
            {
                // 计算哈希值
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // 将哈希值转换为Base64字符串
                string hashedPassword = Convert.ToBase64String(hashBytes);

                return hashedPassword;
            }
        }

        public static bool CheckPassword(string password, string target)
        {
            //默认密码 123123
            string hashPassword = HashPassword(password, "666");
            return hashPassword == target;
        }
    }
}
