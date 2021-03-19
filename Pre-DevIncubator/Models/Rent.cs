using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models
{
    public class Rent
    {
        public DateTime RentDate { get; set; }
        public double RentCost { get; set; }

        public Rent()
        {
            RentDate = DateTime.Today;
            RentCost = 0;
        }

        public Rent(DateTime rentDate, double rentCost)
        {
            RentDate = rentDate;
            RentCost = rentCost;
        }
    }
}
