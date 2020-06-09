using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using NetMatch_PT.ViewModels;

namespace NetMatch_PT.Calculation
{
    public static class PriceCalculation
    {
        public static double Tickets(int tickets)
        {
            double price = 200;
            double TotalTickets = price * tickets;
            return TotalTickets;
        }
        public static double RoomPrice(int rooms)
        {
            double price = 100;
            double roomPrice = price * rooms;

            return roomPrice;
        }
        public static double TotalPrice(BoekingVm boeking, double price)
        {
            double annulering = 30;
            double reis = 30;
            double calamity = 2.50;
            double reservation = 18;
            double korting = 0.95;
            double total = Tickets(boeking.Tickets) + RoomPrice(boeking.TravelOptions.Rooms) + calamity + reis + reservation;
            if (boeking.AnnuleringsVerzekering)
            {
                total = total + annulering;
            }
            if (boeking.ReisVerzekering)
            {
                total = total + reis;
            }
            if (boeking.AgentKorting)
            {
                total = total * korting;
            }
            return total;

        }

    }
}