using Core.Entities.IDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        
        
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string CarDescription { get; set; }
        public int DailyPrice { get; set; }



    }
}
