using Encryption.CipherModels;

namespace Encryption.CipherController
{
    public class Base32HashController: CipherController
    {
        public override void UpdateValues()
        {
            this.Cipher = new Base32Hash();

        }
    }
}