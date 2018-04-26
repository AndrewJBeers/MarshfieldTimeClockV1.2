using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarshfieldTimeClock_V1._1
{
    public class Employee
    {
        private int employeeNumber;
        private List<string> rolesDescription = new List<string>();
        private List<DateTime> daysWorked = new List<DateTime>();
        private List<double> hoursWorked = new List<double>();

        public int EmployeeNumber
        {
            get
            {
                return employeeNumber;
            }

            set
            {
                employeeNumber = value;
            }
        }

        public List<string> RolesDescription
        {
            get
            {
                return rolesDescription;
            }

            set
            {
                rolesDescription = value;
            }
        }

        public List<DateTime> DaysWorked
        {
            get
            {
                return daysWorked;
            }

            set
            {
                daysWorked = value;
            }
        }

        public List<double> HoursWorked
        {
            get
            {
                return hoursWorked;
            }

            set
            {
                hoursWorked = value;
            }
        }

        public Employee(int employeeNumber, List<string> rolesDescription, List<DateTime> daysWorked, List<double> hoursWorked)
        {
            this.EmployeeNumber = employeeNumber;
            this.RolesDescription = rolesDescription;
            this.DaysWorked = daysWorked;
            this.HoursWorked = hoursWorked;
        }

        public Employee()
        {
        }
    }
}