using System;

namespace FortuneRegistry.Shared.Models
{
    public class FamilyMember : BaseDbModel
    {
        public FamilyMember()
        {
            
        }
        public FamilyMember(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
    }
}
