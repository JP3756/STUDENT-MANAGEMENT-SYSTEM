# STUDENT-MANAGEMENT-SYSTEM

```markdown
# Student Linked List Console Application

A professional C# console application that manages student information using a **singly linked list**. This app allows users to **insert, delete, search, update, and display student records** efficiently while validating input and preventing duplicate entries.

---

## Table of Contents
- [Project Overview](#project-overview)
- [Project Structure](#project-structure)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## Project Overview
This project demonstrates a practical implementation of a **singly linked list** in C#. It provides a simple interface for managing student records with input validation, duplicate checks, and interactive display navigation.

---

## Project Structure
```

StudentLinkedList/
│
├─ StudentApp.cs            # Main console application (menu & input handling)
├─ SinglyStudentInfo.cs     # Student class & singly linked list implementation
├─ README.md                # Project documentation
└─ LICENSE                  # License file

````

- **StudentApp.cs**: Handles the menu system and user interactions.  
- **SinglyStudentInfo.cs**: Contains the `Student` class and linked list operations (`Insert`, `Remove`, `Search`, `Display`).  
- **README.md**: Provides project overview and instructions.  
- **LICENSE**: Contains project license information.

---

## Features
- **Add Student:** Insert new students with ID, name, age, course, and year level.
- **Delete Student:** Remove students by ID.
- **Search Student:** Search by ID (unique) or name (multiple matches).
- **Update Student:** Modify existing student details.
- **Display Students:** Interactive viewing with Right Arrow → or 'N', stop with ESC.
- **Validation:**  
  - No leading zeros in IDs  
  - Age must be numeric  
  - Prevents duplicate IDs

---

## Installation
1. Clone the repository:
```bash
git clone https://github.com/yourusername/student-linked-list.git
````

2. Open the project in **Visual Studio** or any C# IDE.
3. Build the project.
4. Run the application.

---

## Usage

1. Launch the application.
2. Choose from the menu:

```
1. Insert New Student
2. Delete Student by ID
3. Search Student
4. Update Student Details
5. Display All Students
6. Exit
```

3. Follow on-screen prompts to manage student data.

**Example – Adding a Student**

```text
Enter Student ID: 101
Enter Name: John Doe
Enter Age: 20
Enter Course: ABM
Enter Year Level: 12
```

**Navigating the Display**

* Press **Right Arrow →** or **N** to view the next student.
* Press **ESC** to stop viewing the list.

---

## Contributing

Contributions are welcome! Follow these steps:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature-name`.
3. Make your changes and commit: `git commit -m "Add feature"`.
4. Push the branch: `git push origin feature-name`.
5. Open a Pull Request.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contact

**Your Name** – cabalunajp7@gmail.com
GitHub:https://github.com/JP3756

```

---

If you want, I can also **add a diagram showing how the Student nodes link together in the singly linked list** to make this README even more **visual and professional** for GitHub.  

Do you want me to add that diagram?
```
