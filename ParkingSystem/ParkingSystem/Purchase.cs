﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Purchase
    {
        public Enrollment enrollmentOfPurchase { get; set;}
        public int timeOfPurchase { get; set; }
        public DateTime dateOfPurchase { get; set; }

        public Purchase()
        {
            enrollmentOfPurchase = null;
            timeOfPurchase = 0;
        }

        public Purchase(Enrollment enrollment, int time, DateTime dateTime)
        {
            enrollmentOfPurchase = enrollment;
            timeOfPurchase = time;
            dateOfPurchase = dateTime;
        }
        
    }
}
