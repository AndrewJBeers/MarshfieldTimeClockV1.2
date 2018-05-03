using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarshfieldTimeClock_V1._1
{
    public class Employee
    {
        private string employeeID;
        private DateTime fogottenClockout;

        private List<string> roles= new List<string>();
        private List<string> workID = new List<string>();

        private List<DateTime> daysWorked = new List<DateTime>();
        private List<double> hoursWorked = new List<double>();


        public Employee()
        {
        }
        public Employee(string empID)
        {
            employeeID = empID;
        }

        public string EmployeeID
        {
            
            get { return employeeID;}
            set { employeeID = value; }
        }
        public List<string> Roles
        {
            get{ return roles; }
            set { roles = value;}
        }

        public List<string> WorkID
        {
            get { return workID;}
            set { workID = value;}
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

        public DateTime FogottenClockout
        {
            get  {  return fogottenClockout; }
            set {  fogottenClockout = value; }
        }
    }
}