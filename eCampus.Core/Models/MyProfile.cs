using System.Collections.Generic;

namespace eCampus.Core.Models
{
    public class MyProfile
    {
        public Data Data { get; set; }
    }
    public class Data
    {
        public int UserAccountId { get; set; }
        public string Photo { get; set; }
        public string FullName { get; set; }
        public object ScientificInterest { get; set; }
        public List<Personality> Personalities { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Profile> Profiles { get; set; }
    }
    public class Profile
    {
        public string SubsystemName { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
    }
    public class Employee
    {
        public int SubdivisionId { get; set; }
        public string SubdivisionName { get; set; }
        public string Position { get; set; }
        public string AcademicDegree { get; set; }
        public string AcademicStatus { get; set; }
    }
    public class Personality
    {
        public int SubdivisionId { get; set; }
        public string SubdivisionName { get; set; }
        public string StudyGroupName { get; set; }
        public bool IsContract { get; set; }
        public string Specialty { get; set; }
    }
}
