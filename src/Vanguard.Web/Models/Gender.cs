namespace Vanguard.Web.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}