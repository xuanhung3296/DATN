using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel.Models
{
    public class FormSubmitViewModel
    {
        public List<Tourist> ListTourist { get; set; }

        public User User { get; set; }
    }
}