using System.ComponentModel.DataAnnotations;

namespace WorkProposalList.Data
{
    public class ProposalModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        [StringLength(890, MinimumLength = 15)]
        public string Customer { get; set; }
        public string ProposalNumber { get; set; }
        public DateTime ProposalDate { get; set; } = DateTime.Now;
        public DateTime ShipDate { get; set; } = DateTime.Now;
        public DateTime ShipDocumentDate { get; set; } = DateTime.Now;
        public string Methodology { get; set; }
        public Guid? ResponsibleId { get; set; }
    }
}