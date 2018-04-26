using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarshfieldTimeClock_V1._1
{
    public class Employee
    {
        private string employeeID;

        private List<string> rolesDescription = new List<string>();
        private List<string> WorkID = new List<string>();

        private List<DateTime> daysWorked = new List<DateTime>();
        private List<double> hoursWorked = new List<double>();


        public Employee(string employeeId)
        {
            employeeID = employeeId;
        }


        public string EmployeeID
        {
            get { return employeeID;}
        }
        public List<string> RolesDescription
        {
            get{ return rolesDescription; }
            set { rolesDescription = value;}
        }

        public List<string> WorkID1
        {
            get { return WorkID;}
            set { WorkID = value;}
        }

        public List<DateTime> DaysWorked
        {
            get{return daysWorked; }
            set { daysWorked = value;}
        }

        public List<double> HoursWorked
        {
            get {return hoursWorked; }
            set { hoursWorked = value; }
        }



       
    }
}