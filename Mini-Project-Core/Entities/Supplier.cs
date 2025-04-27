namespace Mini_Project_Core
{
    public class Supplier
    {
        public long ID { get; set; }
        public bool IsDeleted { get; set; }
        public string? CompanyCode { get; set; }
        public string CompanyName { get; set; } = null!;
        public string TelephoneNumber { get; set; } = null!;
    }
}
