using SecretUtils;
using System;
using System.Text;
using SecretUtils.Crypto;

namespace SecretTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //国密sm4
            //string sm4key= Sm4Base.GenerateKeyString();
            //string sm4key = "698ee3f90666d6a8e62d73b3c1f5f4f3";
            //string data = "测试示例testtest！！！";
            //byte[] cipher= Sm4Base.EncryptCBC(Encoding.UTF8.GetBytes(data), sm4key);
            //Console.WriteLine(Hex.ToHexString(cipher, 0, cipher.Length));
            //byte[] plain = Sm4Base.DecryptCBC(cipher, sm4key);
            //Console.WriteLine(Encoding.UTF8.GetString(plain));

            //国密sm2

            //SM2KeyPair ms2key =Sm2Base.GenerateKey();
            var plainText = "这是测试!!!!!";
            Console.WriteLine("国密待加密字符串：" + plainText);
            var data2 = Encoding.UTF8.GetBytes(plainText);
            // 生成公钥私钥键值对
            SM2KeyPair keys = Sm2Base.GenerateKey();

            Sm2Base.GenerateKeyFile(keys.pubKey, @"D:\Users\Zeng\Desktop\pukfile.puk");
            // 私钥加签
            byte[] signValue = Sm2Base.Sign(keys.priKey, data2);
            // 公钥验证
            bool b = Sm2Base.VerifySign(keys.pubKey, data2, signValue);

            Console.WriteLine("国密验签结果：" + b);

            // 公钥加密
            byte[] cipher2 = Sm2Base.Encrypt(keys.pubKey, data2);

            // 私钥解密
            byte[] plain = Sm2Base.Decrypt(keys.priKey, cipher2);

            //byte[] ciphersm4 = Sm2Base.Encrypt(, Encoding.UTF8.GetBytes(data2));
            Console.WriteLine("国密解密结果：" + Encoding.UTF8.GetString(plain));
            Console.ReadKey();
        }
    }
}
