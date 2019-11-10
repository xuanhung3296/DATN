using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel.Models
{
    public class TourViewModel
    {
       public Tour Tour { get; set; }
       public List<Comment> listComment { get; set; }
    }
}