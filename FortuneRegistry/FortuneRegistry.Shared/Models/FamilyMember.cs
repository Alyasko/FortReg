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

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
