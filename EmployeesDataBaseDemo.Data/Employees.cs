﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDataBaseDemo.Data;
public class Employees
{
    public int Id
    {
        get; set;
    }
    public string FullName
    {
        get; set;
    }

    public DateTime Birthday
    {
        get; set;
    }

    public int? Age
    {
        get;
        set;
    }

    public string? Details
    {
        get; set;
    }
}
