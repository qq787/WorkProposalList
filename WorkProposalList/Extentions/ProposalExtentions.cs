using WorkProposalList.Data;

namespace WorkProposalList.Extentions
{
    public static class ProposalExtentions
    {
        public static ProposalModel Copy(this ProposalModel proposal)
        {
            return new ProposalModel()
            {
                Id = proposal.Id,
                ReceiptDate = proposal.ReceiptDate,
                Customer = proposal.Customer,
                ProposalNumber = proposal.ProposalNumber,
                ProposalDate = proposal.ProposalDate,
                ShipDate = proposal.ShipDate,
                ShipDocumentDate = proposal.ShipDocumentDate,
                Methodology = proposal.Methodology,
                ResponsibleId = proposal.ResponsibleId
            };
        }
    }
}
