using LINQs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQs
{
    class Program
    {
        static void Main()
        {
                // List of Employee Teams 
                List<EmployeeTeam> EmployeeTeams = new List<EmployeeTeam>() 
                { 
                new EmployeeTeam(1, 3), new EmployeeTeam(2, 3), new EmployeeTeam(3,1), new EmployeeTeam(4,3), new EmployeeTeam(5,2)
                };
                // List of Teams
                List<Team> Teams = new List<Team>() {
                    new Team(1, "Programs and Operations", 246), new Team(2, "Financial Management", 754), 
                    new Team(3, "Learning and Development", 327)
                    };
                //List of Employees
                List<Employee> Employees = new List<Employee>() { 
                    new Employee(1, "Muna Frank", "marvelousfrank5@gmail.com", 246),
                    new Employee(2, "Nene Frank", "nenefrank41@gmail.com", 327), 
                    new Employee(3, "Temilade Johnson", "temijons@outlook.com", 754),
                    new Employee(4, "Joshua Adenuga", "joshade@yahoo.com", 246),
                    new Employee(5, "Wole soyinka", "wolesoy@gmail.com", 327)
                };

                // INNER JOIN
                // Raw query
                var EmployeeInfo = from ET in EmployeeTeams
                                   join T in Teams on ET.TeamId equals T.Id
                                   join E in Employees on ET.EmployeeId equals E.Id
                                   orderby ET.EmployeeId
                                   select new
                                   {
                                       ET.EmployeeId,
                                       E.FullName,
                                       E.EmpEmail,
                                       T.Name,
                                       T.TeamCode
                                   };

                // Using Lambda and methods
                var EmployeeInfo2 = EmployeeTeams.Join(Teams, ET => ET.TeamId, T => T.Id, 
                                    (ET, T) => new
                                    {
                                        ET.EmployeeId,
                                        T.Name,
                                        T.TeamCode
                                    }).Join(Employees,  ET2 => ET2.EmployeeId, E => E.Id, 
                                    (ET2, E) => new
                                    {
                                        ET2.EmployeeId,
                                        ET2.Name,
                                        ET2.TeamCode,
                                        E.FullName,
                                        E.EmpEmail
                                    });

                // LEFT OUTER JOIN
                //Raw query
                var EmployeeInfo3 =from ET in EmployeeTeams
                                    join T in Teams on ET.TeamId equals T.Id
                                    join E in Employees on ET.EmployeeId equals E.Id into joined
                                    from sub in joined.DefaultIfEmpty()
                                    select new 
                                    {
                                        ET.EmployeeId,
                                        T.Name,
                                        sub.FullName,
                                        sub.EmpEmail,
                                        TeamCode = sub == null ? T.TeamCode : sub.TeamCode
                                    };


            // Using lambdas and methods


            var qry = EmployeeTeams.SelectMany
            (
                ET => Teams.Where(T => T.Id == ET.EmployeeId).DefaultIfEmpty(),
                (ET, T) => new
                {
                    ET.EmployeeId,
                    T.Name,          
                    T.TeamCode
                }
            );

            Console.ReadLine();

            }

        }
    }

