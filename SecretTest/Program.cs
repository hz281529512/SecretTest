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
            var data2 = Encoding.UTF8.GetBytes("这是测试!!!!!");
            SM2KeyPair keys = Sm2Base.GenerateKey();


            Sm2Base.GenerateKeyFile(keys.pubKey, @"C:\Users\Zeng\Desktop\pukfile.puk");
            byte[] signValue = Sm2Base.Sign(keys.priKey, data2);
            bool b = Sm2Base.VerifySign(keys.pubKey, data2, signValue);



            byte[] cipher2 = Sm2Base.Encrypt(keys.pubKey, data2);

            byte[] plain = Sm2Base.Decrypt(keys.priKey, cipher2);

            //byte[] ciphersm4 = Sm2Base.Encrypt(, Encoding.UTF8.GetBytes(data2));
            Console.WriteLine(Encoding.UTF8.GetString(plain));
            Console.ReadKey();
        }
    }
}
