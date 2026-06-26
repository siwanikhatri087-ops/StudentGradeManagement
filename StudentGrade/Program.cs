using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrade
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter student name: ");
			string studentName = Console.ReadLine();

			Console.WriteLine("Enter student age: ");
			int age = Convert.ToInt32(Console.ReadLine());

			int numberOfSubjects;
			do
			{
				Console.WriteLine("Enter Number of Subjects (between 1 and 5): ");
				numberOfSubjects = int.Parse(Console.ReadLine());
				if (numberOfSubjects < 1 || numberOfSubjects > 5)
				{
					Console.WriteLine("Please enter a number between 1 and 5.");
				}
			} while (numberOfSubjects < 1 || numberOfSubjects > 5);

			double[] subjectMarks = new double[numberOfSubjects];
				 
				for (int i = 0; i < numberOfSubjects; i++)
			{
				int mark;
				bool isValid = false;

				while (!isValid)
				{
					Console.WriteLine($"Enter mark for Subject {i + 1}: ");
					mark = int.Parse(Console.ReadLine());

					if (mark >= 0 && mark <= 100)
					{
						subjectMarks[i] = mark;
						isValid = true;
					}
					else
					{
						Console.WriteLine("Invalid mark! Please enter a value between 0 and 100.");
					}
				}
			}

			double totalMarks = 0;
			for (int i = 0; i < numberOfSubjects; i++)
			{
				totalMarks += subjectMarks[i];
			}

			double averageMarks = (double)totalMarks / numberOfSubjects;

			string grade;
			if (averageMarks >= 90 && averageMarks <= 100)
				grade = "A+";
			else if (averageMarks >= 80 && averageMarks <= 89)
				grade = "A";
			else if (averageMarks >= 70 && averageMarks <= 79)
				grade = "B+";
			else if (averageMarks >= 60 && averageMarks <= 69)
				grade = "B";
			else if (averageMarks >= 50 && averageMarks <= 59)
				grade = "C+";
			else if (averageMarks >= 40 && averageMarks <= 49)
				grade = "C";
			else if (averageMarks >= 30 && averageMarks <= 39)
				grade = "D";
			else
				grade = "Fail";

			bool isPassing = true;
			for (int i = 0; i < numberOfSubjects; i++)
			{
				if (subjectMarks[i] < 50)
				{
					isPassing = false;
					break;
				}
			}

			string status = isPassing ? "Pass" : "Fail";

			bool exit = false;
			while (!exit)
			{
				Console.WriteLine("\n--- Menu ---");
				Console.WriteLine("1. Show Student Info");
				Console.WriteLine("2. Show Marks");
				Console.WriteLine("3. Show Grade");
				Console.WriteLine("4. Exit");
				Console.Write("Choose an option: ");

				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.WriteLine($"\n--- Student Information ---");
						Console.WriteLine($"Name: {studentName}");
						Console.WriteLine($"Age: {age}");
						Console.WriteLine($"Number of Subjects: {numberOfSubjects}");
						break;

					case 2:
						Console.WriteLine($"\n--- Subject Marks ---");
						for (int i = 0; i < numberOfSubjects; i++)
						{
							Console.WriteLine($"Subject {i + 1}: {subjectMarks[i]}");
						}
						Console.WriteLine($"Total Marks: {totalMarks}");
						Console.WriteLine($"Average Marks: {averageMarks:F2}");
						break;

					case 3:
						Console.WriteLine($"\n--- Grade Information ---");
						Console.WriteLine($"Average Marks: {averageMarks:F2}");
						Console.WriteLine($"Grade: {grade}");
						Console.WriteLine($"Status: {status}");
						break;

					case 4:
						Console.WriteLine("Exiting... Goodbye!");
						exit = true;
						break;

					default:
						Console.WriteLine("Invalid option! Please choose 1, 2, 3, or 4.");
						break;
				}
			}
			}
		}
	}


