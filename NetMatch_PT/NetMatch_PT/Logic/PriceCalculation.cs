using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using NetMatch_PT.ViewModels;

namespace NetMatch_PT.Logic
{
    public class PriceCalculation
    {
        public static decimal Tickets(TravelDetailVm tvm)
        {
            decimal TotalTickets = Convert.ToDecimal(tvm.FlightDetailVm.Price) * tvm.Tickets;
            return TotalTickets;
        }
        public static decimal RoomPrice(TravelDetailVm tvm)
        {
            decimal roomPrice = Convert.ToDecimal(tvm.Accommodation.Price) * tvm.Rooms;

            return roomPrice;
        }
        public static decimal AdultPrice(TravelDetailVm tvm)
        {
            decimal adultPrice = Convert.ToDecimal(tvm.Price) * 2;
            return adultPrice;
        }
        public static decimal KidsPrice(TravelDetailVm tvm)
        {
            decimal kidsPrice;
            if (tvm.TravelCompany.Count > 2)
            {
                kidsPrice = (tvm.TravelCompany.Count - 2) * Convert.ToDecimal(tvm.Accommodation.KidsPrice);
            }
            else
            {
                kidsPrice = 0;
            }
            return kidsPrice;
        }
        public static decimal Total(TravelDetailVm tvm)
        {
            decimal total;
            decimal insurancePrice = 0;

            for (int i = 0; i < tvm.Insurances.Count; i++)
            {
                if (tvm.Insurances[i].Selected)
                {
                    insurancePrice += Convert.ToDecimal(tvm.Insurances[i].Price);
                }
            }
            string calamity = "2,50";
            string reservation = "18,00";
            string discount = "0,95";

            if (tvm.Discount)
            {
                total = (Tickets(tvm) + insurancePrice + RoomPrice(tvm) + AdultPrice(tvm) + KidsPrice(tvm) + Convert.ToDecimal(calamity) + Convert.ToDecimal(reservation)) * Convert.ToDecimal(discount);
            }
            else
            {
                total = Tickets(tvm) + insurancePrice + RoomPrice(tvm) + AdultPrice(tvm) + KidsPrice(tvm) + Convert.ToDecimal(calamity) + Convert.ToDecimal(reservation);
            }
            return total;
        }

    }
}
