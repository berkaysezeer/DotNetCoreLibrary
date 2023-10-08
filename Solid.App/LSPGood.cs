using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.LSPGood
{
    //Kötü LSP iyi örneği

    public interface ITakePhoto
    {
        void TakePhoto();
    }

    //abstract classlardan nesne örneği alınamaz
    public abstract class BasePhone
    {
        public void Call()
        {
            Console.WriteLine("Arama yapıldı");
        }
    }

    //IPhoto'yu iPhone'nun fotoğraf çekme özelliği olduğu için verdik
    public class IPhone : BasePhone, ITakePhoto
    {
        public void TakePhoto()
        {
            Console.WriteLine("Fotoğraf çekildi");
        }
    }

    public class Nokia3310 : BasePhone
    {

    }
}
