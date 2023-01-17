using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PPM.MAIN.PPM.MODEL;
using Domain;

namespace PPM.MAIN.PPM.UI
{
    public class Viewing
    {
        public void View()
        {
            Console.WriteLine(" ======= HELLO PROLIFICS EMPLOYEE ======= ");
            Console.WriteLine("Enter 1 to Adding Project");
            Console.WriteLine("Enter 2 to View all Projects");
            Console.WriteLine("Enter 3 to Adding Employee");
            Console.WriteLine("Enter 4 to View all Employees");
            Console.WriteLine("Enter 5 to Adding Role");
            Console.WriteLine("Enter 6 to View all Roles");
            Console.WriteLine("Enter 7 to Searching Project");
            Console.WriteLine("Enter 8 to Searching Project through ID");
            Console.WriteLine("Enter 9 to Adding Employees to Project");
            Console.WriteLine("Enter 10 to View Projects with Employees");
            Console.WriteLine("Enter 11 to View Employee in a particular Project");
            Console.WriteLine("Enter 12 to Delete Employee from Project");
            Console.WriteLine("Enter 'S' to QUIT the Application");

            ProjectManager PM =  new ProjectManager();
            EmployeeManager EM = new EmployeeManager();
            RoleManager RM = new RoleManager();
            Project project = new Project();
            Employee employee = new Employee();
            Role role = new Role();

            RM.roleList.Add(new Role(1, "Software Engineer"));
            RM.roleList.Add(new Role(2, "Associate Software Engineer"));
            RM.roleList.Add(new Role(3, "Trainee Software Engineer"));
            RM.roleList.Add(new Role(4, "Technical Lead"));

            Boolean error = false;

            Regex phonenumber = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");
            Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex date = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            var UserInput = Console.ReadLine();

            while (true)
            {
                repeat:

                switch (UserInput)
                {
                    case "1":
                        do
                        {
                            try
                            {
                                inputprojectid:
                                Console.WriteLine("Enter the Project ID");
                                int projectid = Convert.ToInt32(Console.ReadLine());
                                for (int i=0; i<PM.projects.Count; i++)
                                {
                                    if (PM.projects[i].id == projectid)
                                    {
                                        Console.WriteLine("This ID already exists try new ID");
                                        Console.WriteLine("Enter any key to Try Again");
                                        Console.WriteLine("Enter  \"x\" to Exit to  Main Menu");
                                        string? idTry = Console.ReadLine();

                                        if (idTry == "x")
                                        {
                                            goto breakage;
                                        }
                                        else
                                        {
                                            goto inputprojectid;
                                        }
                                    }
                                }
                                Console.WriteLine("Enter the Name of Project");
                                string? name = Console.ReadLine();
                                
                                StartDate:
                                Console.WriteLine("Enter the Start Date of Project DD/MM/YYYY format");
                                string? start = Console.ReadLine();
                                if(!date.IsMatch(start))
                                {
                                    Console.WriteLine("Invalid Date Format");
                                    Console.WriteLine("Enter any key to Try Again");
                                    Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                    var sDateread=Console.ReadLine();

                                    if(sDateread == "x")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        goto StartDate;
                                    }
                                }
                                
                                EndDate:
                                Console.WriteLine("Enter End Date of Project in DD/MM/YYYY format");
                                string? end = Console.ReadLine();
                                if (!date.IsMatch(end))
                                {
                                    Console.WriteLine("Invalid Date Format");
                                    Console.WriteLine("Enter any key to Try Again");
                                    Console.WriteLine("Enter \"x\" to Exit to  Main Menu");
                                    
                                    var eDateread = Console.ReadLine();
                                    if (eDateread == "x")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        goto EndDate;
                                    }

                                }

                                Project project1 = new Project(name, start, end, projectid);
                                PM.AddingProjects(project1);
                                project = project1;
                                
                                Console.WriteLine("Added Successfully");
                                Console.WriteLine("Enter any key to get Main Menu");
                                Console.ReadLine();
                            }

                            catch(FormatException)
                            {
                                Console.WriteLine("\nError : only use Numbers for ID");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to get Main Menu");
                            
                                UserInput= Console.ReadLine();
                                if(UserInput == "x")
                                {
                                    break;
                                }
                                error = true;
                            }
                        
                            catch (Exception)
                            {
                                Console.WriteLine("\nError : Only use Numbers for ID");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to get Main Menu");
                            
                                
                                UserInput = Console.ReadLine();
                                if(UserInput == "x")
                                {
                                    
                                    break;
                                }
                                error = true;
                            }
                        }

                        while(error);
                        breakage:
                        break;
                        

                    case "2":
                        PM.DisplayAllProjects();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "3":

                        tryagain:

                        try
                        {
                            inputempid:

                            Console.WriteLine("Enter the ID of Employee");
                            int empId = Convert.ToInt32(Console.ReadLine());
                            for(int i =0;i<EM.employeeList.Count;i++)
                            {
                                if (empId == EM.employeeList[i].employeeID)
                                {
                                    Console.WriteLine("The ID already exists try new ID");
                                    Console.WriteLine("Enter any key to Try Again");
                                    Console.WriteLine("Enter  \"x\" to Exit to  Main Menu");
                                    string? empidTry = Console.ReadLine();

                                    if (empidTry == "x") 
                                    {
                                        goto breakage;
                                    }
                                    else
                                    {
                                        goto inputempid;
                                    }
                                }
                            }

                            Console.WriteLine("Enter Employee Fist Name");
                            var fname = Console.ReadLine();
                            Console.WriteLine("Enter Employee Last Name");
                            var lname = Console.ReadLine();

                            Email:

                            Console.WriteLine("Enter Employee Email ID");
                            var EMAIL= Console.ReadLine();
                            if(!email.IsMatch(EMAIL))
                            {
                                Console.WriteLine("Invalid Email Format");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to get Main Menu");
                                
                                var emailread=Console.ReadLine();

                                if(emailread=="x")
                                {
                                    break;
                                }
                                else
                                {
                                    goto Email;
                                }
                            }

                            mobile:

                            Console.WriteLine("Enter Employee Mobile Number");
                            var mobile = Console.ReadLine();
                            if(!phonenumber.IsMatch(mobile))
                            {
                                Console.WriteLine("Invalid Mobile Number format");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to get Main Menu");
                                var mobileread=Console.ReadLine();

                                if(mobileread=="x")
                                {
                                    break;
                                }
                                else
                                {
                                    goto mobile;
                                }
                            }
                            
                            Console.WriteLine("Enter Employee Address");
                            var address = Console.ReadLine();

                            Option:

                            Console.WriteLine("Select 1 for Assinging Employee with New Role Name and New Role ID");
                            Console.WriteLine("Select 2 for Assinging Existing Role to the Employee");
                            int selection = Convert.ToInt32(Console.ReadLine());

                            if(selection == 1)
                            {
                                try
                                {
                                    Console.WriteLine("Enter the Role ID");
                                    int roleID = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter the Name of Role");
                                    string? rolename = Console.ReadLine();
                                    Console.WriteLine(rolename);

                                    Role role1 = new Role(roleID, rolename);
                                    RM.RoleAdd(role1);

                                    Employee employee1 = new Employee(empId, fname, lname, EMAIL, mobile, address, roleID,  rolename);
                                    EM.AddEmployee(employee1);
                                    employee = employee1;
                                    Console.WriteLine("Added Successfully");
                                }

                                catch(Exception)
                                {
                                    Console.WriteLine("Role ID should be in Numbers only");
                                }
                            }

                            else if (selection == 2)
                            {
                                try
                                {
                                    Selectrole:

                                    RM.ViewRole();
                                    Console.WriteLine("Select Role ID from Above List to assign Role to Employee");
                                    int role1 = Convert.ToInt32(Console.ReadLine());
                                    string? roleNAME1 = null;
                                    switch (role1)
                                    {
                                        case 1:
                                            roleNAME1 = "Software Engineer";
                                            break;
                                        case 2:
                                            roleNAME1 = "Associate Software Engineer";
                                            break;
                                        case 3:
                                            roleNAME1 = "Trainee Software Engineer";
                                            break;
                                        case 4:
                                            roleNAME1 = "Technical Lead";
                                            break;

                                        default:
                                            Console.WriteLine("Invalid Entry");
                                            Console.WriteLine("Enter any key to Try Again");
                                            Console.WriteLine("Enter  \"x\" to get Main Menu");
                                            string? tryemprole = Console.ReadLine();

                                            if(tryemprole == "x")   
                                            {
                                                goto repeat;
                                            }
                                            else
                                            {
                                                goto Selectrole;
                                            }
                                    }   
                                
                                    Employee employee1 = new Employee(empId, fname, lname, EMAIL, mobile, address, role1, roleNAME1);
                                    EM.AddEmployee(employee1);
                                    employee = employee1;
                                    Console.WriteLine("Added Successfully!");
                                }
                                
                                catch (Exception)
                                {
                                    Console.WriteLine("Employee ID should be in Numbers only");
                                }
                            }
                            
                            else
                            {
                                Console.WriteLine("Invalid entry");
                                Console.WriteLine("Try Again");
                                goto Option;
                            }
                        }

                        catch(FormatException)
                        {
                            Console.WriteLine("ID can only be in Numbers");
                            Console.WriteLine("Enter any key to Try Again");
                            Console.WriteLine("Enter  \"x\" to get Main Menu");

                            string? EmpIdTry = Console.ReadLine();

                            if(EmpIdTry == "x")
                            {
                                goto breaking;
                            }

                            else
                            {
                                goto tryagain;
                            }
                        }

                        catch(Exception)
                        {
                            Console.WriteLine("Invalid Entry");
                            Console.WriteLine("Enter any key to Try Again");
                            Console.WriteLine("Enter  \"x\" to get Main Menu");
                            
                            string? EmpIdTry1 = Console.ReadLine();

                            if(EmpIdTry1 == "x")
                            {
                                goto breaking;
                            }

                            else
                            {
                                goto tryagain;
                            }
                        }
                            
                            Console.WriteLine("Enter any key to get to Main Menu");
                            Console.ReadLine();
                            breaking:
                            break;
                    
                    case "4":
                        EM.ShowEmployees();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "5":
                        try
                        {
                            inputroleid:
                            Console.WriteLine("Enter the Role Id");
                            int roleIDD = Convert.ToInt32(Console.ReadLine());
                            for(int i = 0;i<RM.roleList.Count;i++)
                            {
                                if(roleIDD == RM.roleList[i].roleId)
                                {
                                    Console.WriteLine("The ID already exists try new ID");
                                    Console.WriteLine("Enter any key to Try Again");
                                    Console.WriteLine("Enter \"x\" to get Main Menu");
                                    string? roleidTry = Console.ReadLine();

                                    if (roleidTry == "x") 
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        goto inputroleid;
                                    }
                                }
                            }

                            Console.WriteLine("Enter the Name of Role");
                            string? role_name = Console.ReadLine();
                            Role newRole = new Role(roleIDD, role_name);
                            RM.RoleAdd(newRole);
                            Console.WriteLine("Added Successfully!");

                            Console.WriteLine("Enter any key to get Main Menu");
                            Console.ReadLine();
                        }
                        
                        catch (Exception)
                        {
                            Console.WriteLine("Role ID should be in Numbers only");
                            Console.ReadLine();
                        }

                        break;

                    case "6":
                        RM.ViewRole();
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "7":
                        Console.WriteLine("Type to Search for Project");
                        UserInput = Console.ReadLine();
                        PM.SearchProject(UserInput);
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;
                    
                    case "8":
                        try
                        {
                            Console.WriteLine("Search Via Project ID");
                            Console.WriteLine("Enter the ID of Project");
                            int eid = Convert.ToInt32(Console.ReadLine());
                            PM.ShowProject(eid);
                            Console.WriteLine("Enter any key to get Main Menu");
                            Console.ReadLine();
                        }

                        catch (Exception)
                        {
                            Console.WriteLine("ID should be in Numbers only");
                        }
                        break;

                    case "9":
                        try
                        {
                            PM.DisplayAllProjects();
                            Console.WriteLine("Above are the Available Projects");
                            EM.ShowEmployees();
                            Console.WriteLine("Above are the Available Employees");
                            Console.WriteLine("Enter the Project ID for which you want to add Employees");

                            int PROJId =Convert.ToInt32(Console.ReadLine());
                        
                            if(PM.Exist(PROJId))
                            {
                                Console.WriteLine("Enter the ID of Employee to Add Into Project");
                                int EmpId = Convert.ToInt32(Console.ReadLine());
                        
                                if(EM.Exist(EmpId))
                                {
                                    employee = EM.EmployeeDetails(EmpId);
                                    PM.EmployeeToproject(PROJId,employee);
                                    Console.WriteLine("Added Successfully");
                                }
                            
                                else
                                {
                                    Console.WriteLine("Employee Does Not Exist");
                                }
                            }

                            else
                            {
                                Console.WriteLine("Project Does Not Exist");
                            }
                        }
                    
                        catch(Exception )
                        {
                            Console.WriteLine("Invalid Entry");
                        }

                            Console.WriteLine("Enter any key to get Main Menu");
                            Console.ReadLine();
                            break;

                    case "10":
                        PM.Display();
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Enter any key to get Main menu");
                        Console.ReadLine();
                        break;

                    case "11": 
                        Console.WriteLine("Enter Project ID");
                        int readForId =Convert.ToInt32(Console.ReadLine());
                        PM.DisplayEmployeesInProjectById(readForId);
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Enter any key to get Main Menu");
                        Console.ReadLine();
                        break;

                    case "12":
                        try
                        {
                            Console.WriteLine("Enter the ID of the Project for which you want to Delete Employees");
                            int PROJId1 = Convert.ToInt32(Console.ReadLine());
                            if(PM.Exist(PROJId1))
                            {
                                Console.WriteLine("Enter the ID of Employee to Delete Into Project");
                                int EmpId1 = Convert.ToInt32(Console.ReadLine());
                                employee = EM.EmployeeDetails(EmpId1);
                                PM.EmployeeFromProject(PROJId1,employee);
                                Console.WriteLine("\n Successfully Deleted");
                            }

                            else
                            {
                                Console.WriteLine("The Project Does Not Exist");
                            }
                        }

                        catch(FormatException)
                        {
                            Console.WriteLine("ID can only be Integer");
                        }

                        Console.WriteLine("Enter any key to get to Main Menu");
                        Console.ReadLine();
                        break;

                    case "S":
                        return;

                    default:
                        Console.WriteLine("Invalid Entry");
                        break; 
                }

                    Console.WriteLine(" ======= LIST ======= ");
                    Console.WriteLine("Enter 1 to Adding Project");
                    Console.WriteLine("Enter 2 to View all projects");
                    Console.WriteLine("Enter 3 to Adding Employee");
                    Console.WriteLine("Enter 4 to View all Employees");
                    Console.WriteLine("Enter 5 to Adding Role");
                    Console.WriteLine("Enter 6 to View all Roles");
                    Console.WriteLine("Enter 7 to Searching Project");
                    Console.WriteLine("Enter 8 to Searching Project through ID");
                    Console.WriteLine("Enter 9 to Adding Employees to Project");
                    Console.WriteLine("Enter 10 to View Projects with Employees");
                    Console.WriteLine("Enter 11 to View Employee in a particular Project");
                    Console.WriteLine("Enter 12 to Delete Employee from Project");
                    Console.WriteLine("Enter 'S' to QUIT the application");
                
                    UserInput = Console.ReadLine();
            }    
        }
    }
}