using System;
using System.ComponentModel.DataAnnotations;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WorkProposalList.Data;
using WorkProposalList.Extentions;
using WorkProposalList.States;

namespace WorkProposalList.Pages
{
    public partial class Index
    {
        private readonly List<string> methodologyList = new List<string>() { "Основная", "Дополнительная" };

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private ResponsibleState ResponsibleState { get; set; }
        private List<ProposalModel>? proposalList = new List<ProposalModel>();
        private List<ResponsibleModel>? responsiblelList = new List<ResponsibleModel>();
        private ProposalModel? editProposal;
        private ProposalModel? deletedProposal;
        private ResponsibleModel editedResponsible;
        private bool isShowDeletePopup;
        private string popupTitle;
        private string methodology;

        

        private IGrid? ProposalGrid { get; set; }

        protected override void OnInitialized()
        {
            responsiblelList.Add(
                new ResponsibleModel()
                {
                    Id = Guid.NewGuid(),
                    Login = "admin",
                    FullName = "Никитин С.Н.",
                    Password = "password",
                });

            proposalList.Add(
                new ProposalModel()
                {
                    Id = Guid.NewGuid(),
                    ReceiptDate = DateTime.Now,
                    Customer = "Customer text",
                    ProposalNumber = "ProposalNumber text",
                    ProposalDate = DateTime.Now,
                    ShipDate = DateTime.Now,
                    ShipDocumentDate = DateTime.Now,
                    Methodology = "Основная",
                    ResponsibleId = responsiblelList.FirstOrDefault().Id
                });

            proposalList.Add(
                new ProposalModel()
                {
                    Id = Guid.NewGuid(),
                    ReceiptDate = DateTime.Now,
                    Customer = "Customer text 2",
                    ProposalNumber = "ProposalNumber text 2",
                    ProposalDate = DateTime.Now,
                    ShipDate = DateTime.Now,
                    ShipDocumentDate = DateTime.Now,
                    Methodology = "Основная",
                    ResponsibleId = responsiblelList.FirstOrDefault().Id
                });
        }

        private async Task EditModelSaving()
        {
            if (proposalList != null && editProposal != null)
            {
                var proposal = proposalList.FirstOrDefault(p => p.Id == editProposal.Id);                

                if (proposal == null)
                {
                    editProposal.ResponsibleId = editedResponsible?.Id;
                    editProposal.Methodology = methodology; 
                    proposalList.Add(editProposal);
                }
                else
                {
                    editProposal.ResponsibleId = editedResponsible?.Id;
                    editProposal.Methodology = methodology;
                    proposal.ProposalNumber = editProposal.ProposalNumber;
                    proposal.Customer = editProposal.Customer;
                    proposal.ShipDocumentDate = editProposal.ShipDocumentDate;
                    proposal.Methodology = editProposal.Methodology;
                    proposal.ShipDate = editProposal.ShipDate;
                    proposal.ReceiptDate = editProposal.ReceiptDate;
                    proposal.ResponsibleId = editProposal.ResponsibleId;
                    proposal.ProposalDate = editProposal.ProposalDate;
                }
            }

            await CloseEditPopup();
        }

        private void DataItemDeleting()
        {
            if (proposalList != null && deletedProposal != null)
            {
                proposalList.Remove(deletedProposal);
            }

            ToggleShowDeletePopup(null);
        }

        private async Task CloseEditPopup()
        {
            await ProposalGrid.CancelEditAsync();

            editProposal = null;
            editedResponsible = null;
            methodology = null;
        }

        private void ToggleShowDeletePopup(ProposalModel proposal)
        {
            isShowDeletePopup = proposal != null;
            deletedProposal = proposal;
        }

        private void StartEditRow(GridEditStartEventArgs args)
        {
            var data = (ProposalModel)args.DataItem;
            if (data == null)
            {
                editProposal = new ProposalModel();
                popupTitle = "Новая заявка";
                editedResponsible = null;
                methodology = null;
            }
            else
            {
                editProposal = data.Copy();
                popupTitle = "Редактирование заявки";
                editedResponsible = responsiblelList.FirstOrDefault(r => r.Id == editProposal.ResponsibleId);
                methodology = editProposal.Methodology;
            }
        }

        private bool IsValid(ProposalModel proposal)
        {
            var context = new ValidationContext(proposal);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(proposal, context, results, true))
            {
                Console.WriteLine("валидацию");
                return false;
            }
            else
            {
                Console.WriteLine("Пользователь прошел валидацию");
                return true;
            }
        }
        private void LogOut()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
