using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    public class Messages
    {
        public static string SuccessResult = "Başarılı";
        public static string ErrorResult = "Başarısız";
        public static string CarCountOfBrandError = "Bir markada en fazla 10 araç bulunabilir";

        public static string CarAdded = "araba başarılı bir şekilde eklendi";

        public static string CarNameAlreadyExist = "böyle bir araba ismi halihazırda bulunmakta";

        public static string CategoryLimitExceeded = "kategori limiti aşıldı";
    }
}
