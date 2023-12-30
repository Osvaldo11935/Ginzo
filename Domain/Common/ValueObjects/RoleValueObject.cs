using Domain.Entities;

namespace Domain.Common.ValueObjects;

public static class RoleValueObject
{
    public static string AdminName = "Admin";
    public static string StudentName = "Aluno";
    public static string TeacherName = "Professor(a)";
 
    
    public static string AdminId = "30963a2f-adbd-41e4-ae25-c3e9c5774c3d";
    public static string StudentId = "47ecebc6-5682-45c1-8ec4-b5b8cc1da0e1";
    public static string TeacherId = "7395136a-692d-4d60-a2b3-80c1967ba6f7";

    public static List<Role> AddRole()
    {
        return new List<Role>()
        {
            new Role()
            { 
                Id = AdminId,
               Name = AdminName,
               NormalizedName = AdminName.ToUpper()
            },
            new Role()
            {
                Id = StudentId,
                Name = StudentName,
                NormalizedName = StudentName.ToUpper()
            },
            new Role()
            {
                Id = TeacherId,
                Name = TeacherName,
                NormalizedName = TeacherName.ToUpper()
            }
        };
    }
}