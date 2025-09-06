using System;

namespace Singly_Student_info
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public Student Next { get; set; }

        public Student(int id, string name, int age, string course, string yearLevel)
        {
            Id = id;
            Name = name;
            Age = age;
            Course = course;
            YearLevel = yearLevel;
            Next = null;
        }
    }

    public class SinglyStudentInfo
    {
        private Student head;

        public void Insert(int id, string name, int age, string course, string yearLevel)
        {
            Student temp = head;
            while (temp != null)
            {
                if (temp.Id == id)
                {
                    Console.WriteLine("Duplicate ID detected. Student not inserted.");
                    return;
                }
                temp = temp.Next;
            }

            Student newStudent = new Student(id, name, age, course, yearLevel);
            if (head == null)
            {
                head = newStudent;
            }
            else
            {
                temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newStudent;
            }
            Console.WriteLine("Student inserted successfully.");
        }

        // Unified Search (ID or Name) with leading zero check + multiple name matches
        public void Search(string input)
        {
            Student temp = head;
            bool found = false;

            if (int.TryParse(input, out int id)) // If numeric
            {
                if (input.Length > 1 && input.StartsWith("0"))
                {
                    Console.WriteLine("Invalid ID. Leading zeros are not allowed.");
                    return;
                }

                // Search by ID (unique)
                while (temp != null)
                {
                    if (temp.Id == id)
                    {
                        Console.WriteLine($"Found Student -> ID: {temp.Id}, Name: {temp.Name}, Age: {temp.Age}, Course: {temp.Course}, Year: {temp.YearLevel}");
                        found = true;
                        break;
                    }
                    temp = temp.Next;
                }
            }
            else // Search by Name (may return multiple results)
            {
                Console.WriteLine($"Searching for students with the name \"{input}\"...");
                while (temp != null)
                {
                    if (string.Equals(temp.Name, input, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Found Student -> ID: {temp.Id}, Name: {temp.Name}, Age: {temp.Age}, Course: {temp.Course}, Year: {temp.YearLevel}");
                        found = true;
                    }
                    temp = temp.Next;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void Remove(int id)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty. No student to remove.");
                return;
            }

            if (head.Id == id)
            {
                head = head.Next;
                Console.WriteLine("Student removed successfully.");
                return;
            }

            Student current = head;
            while (current.Next != null && current.Next.Id != id)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                Console.WriteLine("Student removed successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        // Enhanced Display with →, N, ESC
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("No students in the list.");
                return;
            }

            Student temp = head;
            int count = 1;
            Console.WriteLine("Student Linked List:");

            while (temp != null)
            {
                Console.WriteLine($"{count}. ID: {temp.Id}, Name: {temp.Name}, Age: {temp.Age}, Course: {temp.Course}, Year: {temp.YearLevel}");
                temp = temp.Next;
                count++;

                if (temp != null)
                {
                    Console.WriteLine("Press → (Right Arrow) or 'N' to view next student, ESC to stop...");
                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Display stopped by user.");
                        break;
                    }
                    else if (key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.N)
                    {
                        Console.WriteLine("Invalid key. Use → or N for next, ESC to stop.");
                    }
                }
                else
                {
                    Console.WriteLine("End of student list.");
                }
            }
        }
    }
}
