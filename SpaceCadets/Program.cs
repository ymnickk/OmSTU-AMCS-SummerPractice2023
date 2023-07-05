using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpaceCadets;
public class Program
{
    public class Student
    {
        public string Name = "";
        public string Group = "";
        public string Discipline = "";
        public double Mark = 0;
    }

    public static void Main(string[] way)
    {
        string path_to_input_file = way[0];
        string path_to_output_file = way[1];

        string file = File.ReadAllText(path_to_input_file);

        dynamic json_file = JsonConvert.DeserializeObject(file) ?? new JObject();
        List<Student> students = json_file.data.ToObject<List<Student>>();
        string scenario = json_file.taskName;
        List<dynamic> total;

        switch (scenario)
        {
            case "GetStudentsWithHighestGPA":
                {
                    total = GetStudentsWithHighestGPA(students);
                    break;
                }
            case "CalculateGPAByDiscipline":
                {
                    total = CalculateGPAByDiscipline(students);
                    break;
                }
            case "GetBestGroupsByDiscipline":
                {
                    total = GetBestGroupsByDiscipline(students);
                    break;
                }
            default:
                throw new Exception();
        }
        string output_file = JsonConvert.SerializeObject(new { Response = total },
         Formatting.Indented);

        File.WriteAllText(path_to_output_file, output_file);
    }

    public static List<dynamic> GetStudentsWithHighestGPA(List<Student> students)
    {
        var students_with_all_marks = students.GroupBy(p => p.Name).Select(g => new
        {
            Name = g.Key,
            Marks = g.Select(p => p.Mark).ToArray()
        });

        double HighestGpa = students_with_all_marks.Max(student => (student.Marks.Sum()) /
         student.Marks.Length);
        var total = students_with_all_marks.Where(student => (student.Marks.Sum()) /
         student.Marks.Length == HighestGpa).Select(student => new
        {
            Name = student.Name,
            Mark = Math.Round((student.Marks.Sum()/ student.Marks.Length),2)
        });
        List<dynamic> exit_list = total.ToList<dynamic>();
        return exit_list;
    }

    public static List<dynamic> CalculateGPAByDiscipline(List<Student> students)
    {
        var disciplines_with_all_marks = students.GroupBy(p => p.Discipline).Select(g => new
        {
            Discipline = g.Key,
            Marks = g.Select(p => p.Mark).ToArray()
        });

        var total = disciplines_with_all_marks.Select(p => new
        {
            Discipline = p.Discipline,
            Mark = Math.Round(p.Marks.Sum() / p.Marks.Length, 3)
        });

        List<dynamic> exit_list = total.ToList<dynamic>();
        return exit_list;
    }

    public static List<dynamic> GetBestGroupsByDiscipline(List<Student> students)
    {
        var best_group = students.GroupBy(p => new { Discipline = p.Discipline,
         Group = p.Group }).Select(g => new
        {
            Discipline = g.Key.Discipline,
            Group = g.Key.Group,
            Mark = g.Average(v => v.Mark)
        }).GroupBy(p => p.Discipline)
            .Select(q => new
            {
                Discipline = q.Key,
                Group = q.Where(k => k.Mark == q.Max(z => z.Mark)).Select(k => k.Group).ToArray()[0],
                GPA = q.Max(k => k.Mark)
            }).ToList<dynamic>();
        return best_group;
    }
}