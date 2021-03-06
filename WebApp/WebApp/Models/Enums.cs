﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public enum TicketType
    {
        time = 0, day=1, month = 2, year = 3
    }

    public enum CustomerType
    {
        normal = 0, student = 1, penzioner = 2
    }

    public enum LineType
    {
        Urban = 0, Suburban = 1
    }

    public enum DayType
    {   
        WorkDay = 0, Saturday, Sunday
    }
}