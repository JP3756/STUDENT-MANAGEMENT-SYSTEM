using System;
using Singly_Student_info;

public class StudentApp
{
    static void Main(string[] args)
    {
        var myLinkedList = new SinglyStudentInfo();
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("STUDENT LINKED LIST MENU");
            Console.WriteLine("1. Insert New Student");
            Console.WriteLine("2. Delete Student by ID");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student Details");
            Console.WriteLine("5. Display All Students");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choiceInput = Console.ReadLine();
            if (!int.TryParse(choiceInput, out choice) || choiceInput.StartsWith("0"))
            {
                Console.WriteLine("Invalid input, please enter a number without leading zeros.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            Console.Clear();
            switch (choice)
            {
                case 1:
                    var student = GetStudentInput();
                    myLinkedList.Insert(student.id, student.name, student.age, student.course, student.year);
                    break;

                case 2:
                    int removeId;
                    string removeIdInput;
                    Console.Write("Enter Student ID to delete: ");
                    removeIdInput = Console.ReadLine();
                    while (!int.TryParse(removeIdInput, out removeId) || (removeIdInput.Length > 1 && removeIdInput.StartsWith("0")))
                    {
                        Console.Write("Invalid ID. Enter Student ID to delete: ");
                        removeIdInput = Console.ReadLine();
                    }
                    myLinkedList.Remove(removeId);
                    break;

                case 3:
                    Console.Write("Enter Student ID or Name to search: ");
                    string searchInput = Console.ReadLine();
                    myLinkedList.Search(searchInput);
                    break;

                case 4:
                    int updateId;
                    string updateIdInput;
                    Console.Write("Enter Student ID to update: ");
                    updateIdInput = Console.ReadLine();
                    while (!int.TryParse(updateIdInput, out updateId) || (updateIdInput.Length > 1 && updateIdInput.StartsWith("0")))
                    {
                        Console.Write("Invalid ID. Enter Student ID to update: ");
                        updateIdInput = Console.ReadLine();
                    }
                    if (StudentExists(myLinkedList, updateId))
                    {
                        var updatedStudent = GetStudentInputForUpdate(updateId);
                        UpdateStudentDetails(myLinkedList, updatedStudent);
                        Console.WriteLine("Student details updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student with this ID does not exist.");
                    }
                    break;

                case 5:
                    myLinkedList.Display();
                    break;

                case 6:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }

            if (choice != 6)
            {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }

        } while (choice != 6);
    }

    static (int id, string name, int age, string course, string year) GetStudentInput()
    {
        int id, age;
        string idInput;
        Console.Write("Enter Student ID: ");
        idInput = Console.ReadLine();
        while (!int.TryParse(idInput, out id) || (idInput.Length > 1 && idInput.StartsWith("0")))
        {
            Console.Write("Invalid ID. Enter Student ID: ");
            idInput = Console.ReadLine();
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.Write("Invalid Age. Enter Age: ");
        }

        Console.Write("Enter Course: ");
        string course = Console.ReadLine();

        Console.Write("Enter Year Level: ");
        string year = Console.ReadLine();

        return (id, name, age, course, year);
    }

    static (int id, string name, int age, string course, string year) GetStudentInputForUpdate(int updateId)
    {
        int age;
        Console.WriteLine("Updating details for Student ID: " + updateId);

        Console.Write("Enter New Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter New Age: ");
        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.Write("Invalid Age. Enter New Age: ");
        }

        Console.Write("Enter New Course: ");
        string course = Console.ReadLine();

        Console.Write("Enter New Year Level: ");
        string year = Console.ReadLine();

        return (updateId, name, age, course, year);
    }

    static void UpdateStudentDetails(SinglyStudentInfo list, (int id, string name, int age, string course, string year) updatedStudent)
    {
        var headField = typeof(SinglyStudentInfo).GetField("head", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var current = (Student)headField.GetValue(list);
        while (current != null)
        {
            if (current.Id == updatedStudent.id)
            {
                current.Name = updatedStudent.name;
                current.Age = updatedStudent.age;
                current.Course = updatedStudent.course;
                current.YearLevel = updatedStudent.year;
                break;
            }
            current = current.Next;
        }
    }

    static bool StudentExists(SinglyStudentInfo list, int id)
    {
        var headField = typeof(SinglyStudentInfo).GetField("head", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var current = (Student)headField.GetValue(list);
        while (current != null)
        {
            if (current.Id == id)
                return true;
            current = current.Next;
        }
        return false;
    }
}
