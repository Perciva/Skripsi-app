using Encryption.CipherModels;

namespace Encryption.CipherController
{
    public class Base64HashController:CipherController
    {
        public override void UpdateValues()
        {
            this.Cipher = new Base64Hash();
        }
    }
}