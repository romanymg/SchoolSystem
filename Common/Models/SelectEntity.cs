namespace Common.Models
{
    public class SelectEntity
    {
        public SelectEntity()
        {
        }
        public SelectEntity(int? id, string? title)
        {
            this.Id = id;
            this.Title = title;
        }
        public int? Id { get; set; }
        public string? Title { get; set; }
        public override bool Equals(object o)
        {
            var other = o as SelectEntity;
            return other?.Id == Id;
        }
        public override int GetHashCode() => Id.GetHashCode();
        public override string ToString()
        {
            return Title ?? "";
        }
    }
}
