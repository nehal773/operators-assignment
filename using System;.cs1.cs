using System;

namespace OperatorsAssignment
{
    // Defines the Employee class with Id, FirstName, and LastName properties
    public class Employee
    {
        // Unique identifier for the employee
        public int Id { get; set; }
        
        // Employee's first name
        public string FirstName { get; set; }
        
        // Employee's last name
        public string LastName { get; set; }

        // Overloading the "==" operator to compare two Employee objects by their Id property
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Handle cases where either or both objects are null to avoid NullReferenceExceptions
            if (ReferenceEquals(emp1, null))
            {
                // If both are null, they are equal; otherwise, they are not
                return ReferenceEquals(emp2, null);
            }
            if (ReferenceEquals(emp2, null))
            {
                // If emp1 is not null but emp2 is null, they are not equal
                return false;
            }

            // Return true if the Ids match, false otherwise
            return emp1.Id == emp2.Id;
        }

        // C# requires comparison operators to be overloaded in pairs.
        // Overloading the "!=" operator to match the "==" overload.
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            // Simply return the negation of the "==" operator result
            return !(emp1 == emp2);
        }

        // It is a best practice to override Equals() when overloading "=="
        public override bool Equals(object obj)
        {
            // Check if the object is an Employee and compare Ids
            if (obj is Employee otherEmployee)
            {
                return this.Id == otherEmployee.Id;
            }
            return false;
        }

        // It is a best practice to override GetHashCode() when overriding Equals()
        public override int GetHashCode()
        {
            // Return the hash code of the Id property since it defines equality
            return this.Id.GetHashCode();
        }
    }
}
using System;

namespace OperatorsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the first Employee object and assign values to its properties
            Employee employee1 = new Employee()
            {
                Id = 101,
                FirstName = "John",
                LastName = "Doe"
            };

            // Instantiate the second Employee object with an identical ID to test the equality overload
            Employee employee2 = new Employee()
            {
                Id = 101,
                FirstName = "Jane",
                LastName = "Smith"
            };

            // Instantiate a third Employee object with a different ID to test inequality
            Employee employee3 = new Employee()
            {
                Id = 102,
                FirstName = "Bob",
                LastName = "Johnson"
            };

            // Display a header for the output
            Console.WriteLine("--- Employee Comparison Results ---\n");

            // Compare employee1 and employee2 using the overloaded "==" operator
            Console.WriteLine($"Comparing Employee 1 ({employee1.FirstName}) and Employee 2 ({employee2.FirstName}) with matching IDs:");
            if (employee1 == employee2)
            {
                // This block executes because their Id properties are both 101
                Console.WriteLine("Result: The employees are EQUAL (IDs match).\n");
            }
            else
            {
                Console.WriteLine("Result: The employees are NOT EQUAL.\n");
            }

            // Compare employee1 and employee3 using the overloaded "!=" operator
            Console.WriteLine($"Comparing Employee 1 ({employee1.FirstName}) and Employee 3 ({employee3.FirstName}) with different IDs:");
            if (employee1 != employee3)
            {
                // This block executes because their Id properties do not match (101 vs 102)
                Console.WriteLine("Result: The employees are NOT EQUAL (IDs do not match).\n");
            }
            else
            {
                Console.WriteLine("Result: The employees are EQUAL.\n");
            }

            // Keep the console window open until a key is pressed
            Console.ReadLine();
        }
    }
}


