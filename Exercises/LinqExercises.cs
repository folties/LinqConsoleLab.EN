using System.Runtime.InteropServices.JavaScript;
using LinqConsoleLab.EN.Data;

namespace LinqConsoleLab.EN.Exercises;

public sealed class LinqExercises
{
    /// <summary>
    /// Task:
    /// Find all students who live in Warsaw.
    /// Return the index number, full name, and city.
    ///
    /// SQL:
    /// SELECT IndexNumber, FirstName, LastName, City
    /// FROM Students
    /// WHERE City = 'Warsaw';
    /// </summary>
    public IEnumerable<string> Task01_StudentsFromWarsaw()
    {
        //query syntax
        var query = from s in UniversityData.Students
            where s.City.Equals("Warsaw")
                select $"{s.IndexNumber}, {s.FirstName}, {s.LastName}";
        
        //method syntax 

        var method = UniversityData.Students
            .Where(s => s.City.Equals("Warsaw"))
            .Select(s => $"{s.IndexNumber}, {s.FirstName}, {s.LastName}");
        
        return query;
        
        
        throw NotImplemented(nameof(Task01_StudentsFromWarsaw));
    }

    /// <summary>
    /// Task:
    /// Build a list of all student email addresses.
    /// Use projection so that you do not return whole objects.
    ///
    /// SQL:
    /// SELECT Email
    /// FROM Students;
    /// </summary>
    public IEnumerable<string> Task02_StudentEmailAddresses()
    {
        var query = from s in UniversityData.Students
            select $"{s.Email}";
        
        return query;
        
        throw NotImplemented(nameof(Task02_StudentEmailAddresses));
        
    }

    /// <summary>
    /// Task:
    /// Sort students alphabetically by last name and then by first name.
    /// Return the index number and full name.
    ///
    /// SQL:
    /// SELECT IndexNumber, FirstName, LastName
    /// FROM Students
    /// ORDER BY LastName, FirstName;
    /// </summary>
    public IEnumerable<string> Task03_StudentsSortedAlphabetically()
    {
        
        var query = from s in UniversityData.Students
            orderby s.LastName, s.FirstName descending
                select $"{s.IndexNumber}, {s.FirstName}, {s.LastName}";
        
        return  query;
        throw NotImplemented(nameof(Task03_StudentsSortedAlphabetically));
    }

    /// <summary>
    /// Task:
    /// Find the first course from the Analytics category.
    /// If such a course does not exist, return a text message.
    ///
    /// SQL:
    /// SELECT TOP 1 Title, StartDate
    /// FROM Courses
    /// WHERE Category = 'Analytics';
    /// </summary>
    public IEnumerable<string> Task04_FirstAnalyticsCourse()
    {
        var query = (from c in UniversityData.Courses
            where c.Category.Equals("Analytics")
                select $"{c.Title}, {c.StartDate}").FirstOrDefault();

        var method = UniversityData.Courses
            .Where(c => c.Category.Equals("Analytics"))
                .Select(c => $"{c.Title}, {c.StartDate}")
                    .FirstOrDefault();
        

        return query != null ?  [query] : ["Such course doesn't exist"];
        
        throw NotImplemented(nameof(Task04_FirstAnalyticsCourse));
    }

    /// <summary>
    /// Task:
    /// Check whether there is at least one inactive enrollment in the data set.
    /// Return one line with a True/False or Yes/No answer.
    ///
    /// SQL:
    /// SELECT CASE WHEN EXISTS (
    ///     SELECT 1
    ///     FROM Enrollments
    ///     WHERE IsActive = 0
    /// ) THEN 1 ELSE 0 END;
    /// </summary>
    public IEnumerable<string> Task05_IsThereAnyInactiveEnrollment()
    {
        var query = (from e in UniversityData.Enrollments
            where e.IsActive == false
                select e).Any();

        return new[] { query ?  "True" : "False" };

        var method = UniversityData.Enrollments.Any(e => !e.IsActive);
        
        throw NotImplemented(nameof(Task05_IsThereAnyInactiveEnrollment));
    }

    /// <summary>
    /// Task:
    /// Check whether every lecturer has a department assigned.
    /// Use a method that validates the condition for the whole collection.
    ///
    /// SQL:
    /// SELECT CASE WHEN COUNT(*) = COUNT(Department)
    /// THEN 1 ELSE 0 END
    /// FROM Lecturers;
    /// </summary>
    public IEnumerable<string> Task06_DoAllLecturersHaveDepartment()
    {
        var method = UniversityData.Lecturers.All(l => l.Department != null);

        return new[] { method ? "True" : "False" };
        
        throw NotImplemented(nameof(Task06_DoAllLecturersHaveDepartment));
    }

    /// <summary>
    /// Task:
    /// Count how many active enrollments exist in the system.
    ///
    /// SQL:
    /// SELECT COUNT(*)
    /// FROM Enrollments
    /// WHERE IsActive = 1;
    /// </summary>
    public IEnumerable<string> Task07_CountActiveEnrollments()
    {
        var method = UniversityData.Enrollments.Count(e => e.IsActive);

        return [$"{method}"];
        
        throw NotImplemented(nameof(Task07_CountActiveEnrollments));
    }

    /// <summary>
    /// Task:
    /// Return a sorted list of distinct student cities.
    ///
    /// SQL:
    /// SELECT DISTINCT City
    /// FROM Students
    /// ORDER BY City;
    /// </summary>
    public IEnumerable<string> Task08_DistinctStudentCities()
    {
        var method = UniversityData.Students.Select(c => c.City).Distinct().OrderBy(c => c);
        
        return method;
        
        throw NotImplemented(nameof(Task08_DistinctStudentCities));
    }

    /// <summary>
    /// Task:
    /// Return the three newest enrollments.
    /// Show the enrollment date, student identifier, and course identifier.
    ///
    /// SQL:
    /// SELECT TOP 3 EnrollmentDate, StudentId, CourseId
    /// FROM Enrollments
    /// ORDER BY EnrollmentDate DESC;
    /// </summary>
    public IEnumerable<string> Task09_ThreeNewestEnrollments()
    {
        var method = UniversityData.Enrollments.OrderByDescending(e => e.EnrollmentDate)
            .Take(3).Select(e => $"{e.EnrollmentDate}, {e.StudentId}, {e.CourseId}");

        return method;
        
        throw NotImplemented(nameof(Task09_ThreeNewestEnrollments));
    }

    /// <summary>
    /// Task:
    /// Implement simple pagination for the course list.
    /// Assume a page size of 2 and return the second page of data.
    ///
    /// SQL:
    /// SELECT Title, Category
    /// FROM Courses
    /// ORDER BY Title
    /// OFFSET 2 ROWS FETCH NEXT 2 ROWS ONLY;
    /// </summary>
    public IEnumerable<string> Task10_SecondPageOfCourses()
    {
        var method = UniversityData.Courses
            .OrderBy(c => c.Title).Skip(2).Take(2)
            .Select(c => $"{c.Title}, {c.Category}");
        
        return method;
        
        throw NotImplemented(nameof(Task10_SecondPageOfCourses));
    }

    /// <summary>
    /// Task:
    /// Join students with enrollments by StudentId.
    /// Return the full student name and the enrollment date.
    ///
    /// SQL:
    /// SELECT s.FirstName, s.LastName, e.EnrollmentDate
    /// FROM Students s
    /// JOIN Enrollments e ON s.Id = e.StudentId;
    /// </summary>
    public IEnumerable<string> Task11_JoinStudentsWithEnrollments()
    {
        var method = UniversityData.Students.
            Join(UniversityData.Enrollments, s => s.Id, e => e.StudentId,
            (s, e) => $"{s.FirstName} {s.LastName}, {e.EnrollmentDate}");

        return method;
            
        
        throw NotImplemented(nameof(Task11_JoinStudentsWithEnrollments));
    }

    /// <summary>
    /// Task:
    /// Prepare all student-course pairs based on enrollments.
    /// Use an approach that flattens the data into a single result sequence.
    ///
    /// SQL:
    /// SELECT s.FirstName, s.LastName, c.Title
    /// FROM Enrollments e
    /// JOIN Students s ON s.Id = e.StudentId
    /// JOIN Courses c ON c.Id = e.CourseId;
    /// </summary>
    public IEnumerable<string> Task12_StudentCoursePairs()
    {
        var method = UniversityData.Enrollments
            .Join(UniversityData.Students, e => e.StudentId, s => s.Id,
                (e, s) => (e, s))
            .Join(UniversityData.Courses, es => es.e.CourseId, c => c.Id,
                (es, c) => $"{es.s.FirstName}, {es.s.LastName}, {c.Title}");

        return method;
        throw NotImplemented(nameof(Task12_StudentCoursePairs));
    }

    /// <summary>
    /// Task:
    /// Group enrollments by course and return the course title together with the number of enrollments.
    ///
    /// SQL:
    /// SELECT c.Title, COUNT(*)
    /// FROM Enrollments e
    /// JOIN Courses c ON c.Id = e.CourseId
    /// GROUP BY c.Title;
    /// </summary>
    public IEnumerable<string> Task13_GroupEnrollmentsByCourse()
    {
        var method = UniversityData.Enrollments
            .Join(
                UniversityData.Courses,  
                e => e.CourseId, 
                c => c.Id, 
                (e,c) => c.Title)
            .GroupBy(title => title)
            .Select(g => $"{g.Key}, {g.Count()}");

        return method;
                
            
        
        throw NotImplemented(nameof(Task13_GroupEnrollmentsByCourse));
    }

    /// <summary>
    /// Task:
    /// Calculate the average final grade for each course.
    /// Ignore records where the final grade is null.
    ///
    /// SQL:
    /// SELECT c.Title, AVG(e.FinalGrade)
    /// FROM Enrollments e
    /// JOIN Courses c ON c.Id = e.CourseId
    /// WHERE e.FinalGrade IS NOT NULL
    /// GROUP BY c.Title;
    /// </summary>
    public IEnumerable<string> Task14_AverageGradePerCourse()
    {
        var method = UniversityData.Enrollments
            .Where(e => e.FinalGrade is not null)
            .Join(UniversityData.Courses, e => e.CourseId, c => c.Id, (e, c) => (c.Title, e.FinalGrade))
            .GroupBy(x => x.Title)
            .Select(g => $"{g.Key}, {g.Average(x => x.FinalGrade)}");

        return method;
        
        throw NotImplemented(nameof(Task14_AverageGradePerCourse));
    }

    /// <summary>
    /// Task:
    /// For each lecturer, count how many courses are assigned to that lecturer.
    /// Return the full lecturer name and the course count.
    ///
    /// SQL:
    /// SELECT l.FirstName, l.LastName, COUNT(c.Id)
    /// FROM Lecturers l
    /// LEFT JOIN Courses c ON c.LecturerId = l.Id
    /// GROUP BY l.FirstName, l.LastName;
    /// </summary>
    public IEnumerable<string> Task15_LecturersAndCourseCounts()
    {
        var query = from l in UniversityData.Lecturers
            join c in UniversityData.Courses
                on l.Id equals c.LecturerId into grouping
            from c in grouping.DefaultIfEmpty()
                group c by (l.FirstName, l.LastName) into g
                select $"{g.Key.FirstName}, {g.Key.LastName}, {g.Count(x => x != null)}";
        
        return query;
        
        throw NotImplemented(nameof(Task15_LecturersAndCourseCounts));
    }

    /// <summary>
    /// Task:
    /// For each student, find the highest final grade.
    /// Skip students who do not have any graded enrollment yet.
    ///
    /// SQL:
    /// SELECT s.FirstName, s.LastName, MAX(e.FinalGrade)
    /// FROM Students s
    /// JOIN Enrollments e ON s.Id = e.StudentId
    /// WHERE e.FinalGrade IS NOT NULL
    /// GROUP BY s.FirstName, s.LastName;
    /// </summary>
    public IEnumerable<string> Task16_HighestGradePerStudent()
    {
        var query = from s in UniversityData.Students
            join e in UniversityData.Enrollments on s.Id equals e.StudentId
                where e.FinalGrade is not null
                group e by new {s.FirstName, s.LastName} into g
                select  $"{g.Key.FirstName}, {g.Key.LastName}, {g.Max(x => x.FinalGrade)}";

        return query;
        
        throw NotImplemented(nameof(Task16_HighestGradePerStudent));
    }

    /// <summary>
    /// Challenge:
    /// Find students who have more than one active enrollment.
    /// Return the full name and the number of active courses.
    ///
    /// SQL:
    /// SELECT s.FirstName, s.LastName, COUNT(*)
    /// FROM Students s
    /// JOIN Enrollments e ON s.Id = e.StudentId
    /// WHERE e.IsActive = 1
    /// GROUP BY s.FirstName, s.LastName
    /// HAVING COUNT(*) > 1;
    /// </summary>
    public IEnumerable<string> Challenge01_StudentsWithMoreThanOneActiveCourse()
    {
        var query = from s in UniversityData.Students 
            join e in UniversityData.Enrollments on s.Id equals e.StudentId 
                where e.IsActive
                group e by new {s.FirstName, s.LastName} into g
                where g.Count() > 1
                select $"{g.Key.FirstName}, {g.Key.LastName}, {g.Count()}";
        
        return query;
                
        
        
        throw NotImplemented(nameof(Challenge01_StudentsWithMoreThanOneActiveCourse));
    }

    /// <summary>
    /// Challenge:
    /// List the courses that start in April 2026 and do not have any final grades assigned yet.
    ///
    /// SQL:
    /// SELECT c.Title
    /// FROM Courses c
    /// JOIN Enrollments e ON c.Id = e.CourseId
    /// WHERE MONTH(c.StartDate) = 4 AND YEAR(c.StartDate) = 2026
    /// GROUP BY c.Title
    /// HAVING SUM(CASE WHEN e.FinalGrade IS NOT NULL THEN 1 ELSE 0 END) = 0;
    /// </summary>
    public IEnumerable<string> Challenge02_AprilCoursesWithoutFinalGrades()
    {

        var query = from c in UniversityData.Courses
            join e in UniversityData.Enrollments on c.Id equals e.CourseId
            where c.StartDate.Month.Equals(4) && c.StartDate.Year.Equals(2026)
            group e by c.Title
            into g
            where g.All(x => x.FinalGrade == null)
            select $"{g.Key}";
        
        return query;

    throw NotImplemented(nameof(Challenge02_AprilCoursesWithoutFinalGrades));
    }

    /// <summary>
    /// Challenge:
    /// Calculate the average final grade for every lecturer across all of their courses.
    /// Ignore missing grades but still keep the lecturers in mind as the reporting dimension.
    ///
    /// SQL:
    /// SELECT l.FirstName, l.LastName, AVG(e.FinalGrade)
    /// FROM Lecturers l
    /// LEFT JOIN Courses c ON c.LecturerId = l.Id
    /// LEFT JOIN Enrollments e ON e.CourseId = c.Id
    /// WHERE e.FinalGrade IS NOT NULL
    /// GROUP BY l.FirstName, l.LastName;
    /// </summary>
    public IEnumerable<string> Challenge03_LecturersAndAverageGradeAcrossTheirCourses()
    {
        
        var query = from l in UniversityData.Lecturers
            join c in UniversityData.Courses
                on  l.Id equals c.LecturerId into g
            from c in g.DefaultIfEmpty()
                join e in UniversityData.Enrollments
                on c.Id equals e.CourseId into g2
            from  e in g2.DefaultIfEmpty()
                where e.FinalGrade is not null
                group e by new {l.FirstName, l.LastName} into g3
                select $"{g3.Key.FirstName}, {g3.Key.LastName}, {g3.Average(c => c.FinalGrade)}";

        return query;
        
        throw NotImplemented(nameof(Challenge03_LecturersAndAverageGradeAcrossTheirCourses));
    }

    /// <summary>
    /// Challenge:
    /// Show student cities and the number of active enrollments created by students from each city.
    /// Sort the result by the active enrollment count in descending order.
    ///
    /// SQL:
    /// SELECT s.City, COUNT(*)
    /// FROM Students s
    /// JOIN Enrollments e ON s.Id = e.StudentId
    /// WHERE e.IsActive = 1
    /// GROUP BY s.City
    /// ORDER BY COUNT(*) DESC;
    /// </summary>
    public IEnumerable<string> Challenge04_CitiesAndActiveEnrollmentCounts()
    {
        
        var query =  from s in UniversityData.Students
            join e in UniversityData.Enrollments on s.Id equals e.StudentId
                where e.IsActive
                group e by new {s.City} into g
                orderby  g.Count() descending
                select  $"{g.Key}, {g.Count()}";

        return query; 
        
        throw NotImplemented(nameof(Challenge04_CitiesAndActiveEnrollmentCounts));
    }

    private static NotImplementedException NotImplemented(string methodName)
    {
        return new NotImplementedException(
            $"Complete method {methodName} in Exercises/LinqExercises.cs and run the command again.");
    }
}
