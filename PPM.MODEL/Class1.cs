using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.MAIN.PPM.MODEL
{
    public class Project
    {
        public List<Employee>employeeListfromEmployeeManager = new List<Employee>();
        public string projectName {get; set;} = default!;
        public string startDate {get; set;} = default!;
        public string endDate {get; set;} = default!;
        public int? id {get; set;} = default!;
        
        public int employeeId;

        public Project (string projectname, string startdate, string enddate, int Id )
        {
            this.projectName = projectname;
            this.startDate = startdate;
            this.endDate = enddate;
            this.id = Id;
        }

        public Project (int empid)
        {
            this.employeeId = empid;
        }
        public Project()
        {

        }
    }

    public class Employee
    {
        public int employeeID {get; set;} = default!;

        public string employeefirstName{get;set;} = default!;
        public string lastName {get; set;} = default!;
        public string email {get; set;} = default!;
        public string mobile {get; set;} = default!;
        public string address {get; set;} = default!;
        public int roleId {get; set;} = default!;
        public string roleName { get; set; } = default!;

        public Employee(int employeeid, string FirstName, string LastName, string Email, string Mobile, string Address, int RoleID, string Rolename)
        {
            this.employeeID = employeeid;  
            this.employeefirstName = FirstName;
            this.lastName = LastName;
            this.email = Email;
            this.mobile = Mobile;
            this.address = Address;
            this.roleId = RoleID;
            this.roleName = Rolename;
        }

        public Employee()
        {

        }
    }

    public class Role
    {
        public string? roleName {get; set;} 
        public int? roleId {get; set;} 

        public Role(int roleid, string roleName)
        {
            this.roleName = roleName;
            roleId = roleid;
        }

        public Role()
        {
            
        }
    }
}