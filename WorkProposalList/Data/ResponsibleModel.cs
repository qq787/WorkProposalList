namespace WorkProposalList.Data
{
    public class ResponsibleModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Login { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string JobTitle { get; set; }
    }
}
