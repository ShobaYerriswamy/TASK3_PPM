using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPM.MAIN.PPM.MODEL;
namespace Domain
{
    public class ProjectManager
    {
        public List<Project>projects = new List<Project>();
        EmployeeManager EM = new EmployeeManager();


        public void AddingProjects(Project project)
        {
            projects.Add(project);
        }

        public void ViewProject(Project project)
        {
            Console.WriteLine("Name of the Project - " + project.projectName + "\n Project ID - " + project.id + "\n Start Date of Project -" + project.startDate + "\n End Date of Project -" + project.endDate);
        }

        public void DisplayAllProjects()
        {
            if(projects.Count == 0)
            {
                Console.WriteLine("The List is Empty!");
            }
            else
            {
                foreach (var i in projects)
                {
                    ViewProject(i);
                }
            }
        }

        public void Display()
        {
            for (int j=0; j<projects.Count; j++)
            {
                if(projects[j].employeeListfromEmployeeManager.Count == 0)
                {
                    Console.WriteLine("No Employee in the Project");
                }
                else
                {
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Project Name - "+ projects[j].projectName);
                    Console.WriteLine("Below are the Details of Employees in this Project");
                    for(int i=0; i<projects[j].employeeListfromEmployeeManager.Count; i++)
                    {
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine(projects[j].employeeListfromEmployeeManager[i].employeefirstName+" ["+projects[j].employeeListfromEmployeeManager[i].roleName + "]");
                    } 
                }
            }
        }

        public void DisplayEmployeesInProjectById(int readingemployeeId)
        {
            for(int j=0; j<projects.Count; j++)
            {
                if(Exist(readingemployeeId))
                {
                    if(readingemployeeId == projects[j].id)
                    {
                        Console.WriteLine("******************************************");
                        Console.WriteLine("Project Name - " + projects[j].projectName);
                        Console.WriteLine("Below are the Details of Employees in this Project");
                        for(int i=0; i<projects[j].employeeListfromEmployeeManager.Count; i++)
                        {
                            Console.WriteLine("-------------------------------------------"); 
                            Console.WriteLine(projects[j].employeeListfromEmployeeManager[i].employeefirstName+" ["+projects[j].employeeListfromEmployeeManager[i].roleName + "]");
                        }
                    }
                }

                else
                {
                    Console.WriteLine("No Project Found");
                }
            }
        }

        public void EmployeeToproject(int pid, Employee ename)
        {
            if(!EM.Exist(pid))
            {
                for(int i=0; i<projects.Count; i++)
                {
                    if(projects[i].id==pid)
                    {
                        projects[i].employeeListfromEmployeeManager.Add(ename);
                    }
                }
            }

            else
            {
                Console.WriteLine("With this ID the Employee already exists in this Project");
                Console.WriteLine("Enter any key to get Main Menu");
                Console.ReadLine();
            }
        }

        public void EmployeeFromProject(int pid, Employee ename)
        {
            for(int i=0; i<projects.Count; i++)
            {
                if(projects[i].id==pid)
                {
                    projects[i].employeeListfromEmployeeManager.Remove(ename);
                }
            }
        }

        public Boolean Exist(int pid)
        {
            for(int i=0; i<projects.Count; i++)
            {
                if(pid== projects[i].id)
                {
                    return true;
                }
            }
            return false;
        }

        public void ShowProject(int eid)
        {
            foreach (Project e in projects)
            {
                if (e.id == eid)
                {
                    Console.WriteLine(" Name of the Project - " + e.projectName + " \n Project ID - " + e.id + " \n Start Date of Project -" + e.startDate + "\n End Date of Project -" + e.endDate);
                }
                else
                {
                    Console.WriteLine("ID not Found");
                }
            }
        }

        public void SearchProject(string search)
        {
            var match = projects.Where(c => c.projectName.Contains(search));
            foreach(var i in match)
            {
                Console.WriteLine("Name of the Project - " + i.projectName + "\n Project ID - " + i.id + "\n Start Date of Project -" + i.startDate + "\n End Date of Project -" + i.endDate);
            }
        }
    }
    

    public class EmployeeManager
    {
        public List<Employee> employeeList = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employeeList.Add(employee);
        }

        public void ViewEmployee(Employee employee)
        {
            Console.WriteLine("Employee ID -" + employee.employeeID + "\n Employee First Name -" + employee.employeefirstName + "\n Employee Last Name -" + employee.lastName + "\n Employee Email ID -" + employee.email + "\n Employee Mobile Number  -" + employee.mobile + "\n Employee Address -" + employee.address + "\n  Role ID -" + employee.roleId + "\n Role Name -" + employee.roleName);
        }

        public Employee EmployeeDetails(int eid)
        {
            Employee employee = new Employee();
            for(int i=0; i<employeeList.Count; i++)
            {
                if(eid==employeeList[i].employeeID)
                {
                    employee=employeeList[i];
                    return employee;
                }
            }
            return employee;
        }

        public void ShowEmployees() 
        {
            if(employeeList.Count == 0)
            {
                Console.WriteLine("No Employees Available");
            }
            else
            {
                foreach (var i in employeeList)
                {
                    ViewEmployee(i);
                }
            }
        }

        public void ShowEmployee(int eid)
        {
            foreach (Employee i in employeeList)
            {

                if (i.employeeID == eid)
                {
                    Console.WriteLine(" Name of the Employee - " + i.employeefirstName + " " + i.lastName + "\n Employee ID - " + i.employeeID);
                }
                else
                {
                    Console.WriteLine("ID not Found");
                }
            }
        }

        public Boolean Exist(int eid)
        {
            for(int i=0; i<employeeList.Count; i++)
            {
                if(eid==employeeList[i].employeeID)
                {
                    return true;
                }       
            }
            return false;
        }
    }

 
    public class RoleManager
    {
        public List<Role> roleList = new List<Role>();

        public void RoleAdd(Role role)
        {
            roleList.Add(role);
        } 

        public void ViewRole()
        {
            foreach (Role i in roleList)
            {
                Console.WriteLine("Name of the Role -" + i.roleName+ "\n Role ID - " + i.roleId);
            }
        }

        public Boolean Exists(int roleId)
        {
            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleList[i].roleId == roleId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}