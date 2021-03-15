using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var count = Students.Count();
            int knockdown = count / 5;
            if(count < 5)
            {
                throw new InvalidOperationException();
            }
            var grades = new List<double>();
            foreach(var student in Students)
            {
                grades.Add(student.AverageGrade);
            }
            grades.Sort();
            int gradePlace = grades.FindIndex(grade => averageGrade == grade);
            
            int gradesAbove = count - gradePlace - 1;

            int gradeLoss = gradesAbove / knockdown;

            switch (gradeLoss)
            {
                case 0: return 'A';
                case 1: return 'B';
                case 2: return 'C';
                case 3: return 'D';
            }


            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
            return;
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
