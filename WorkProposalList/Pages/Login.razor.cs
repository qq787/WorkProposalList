using Microsoft.AspNetCore.Components;
using WorkProposalList.Data;
using WorkProposalList.States;

namespace WorkProposalList.Pages
{
    public partial class Login
    {
        private List<ResponsibleModel> ResponsibleModels { get; set; } = new List<ResponsibleModel>();
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private ResponsibleState ResponsibleState { get; set; }
        private string login;
        private string password;
        private string error;

        protected override void OnInitialized()
        {
            ResponsibleModels.Add(
                new ResponsibleModel()
                {
                    Login = "vlad",
                    Password = "1",
                    FullName = "Владислав Шальнев",
                    JobTitle = "Начальник отделения СИ"
                });
            ResponsibleModels.Add(
                new ResponsibleModel()
                {
                    Login = "stepan",
                    Password = "1",
                    FullName = "Степан Никитин",
                    JobTitle = "Ведущий специалист СИ"
                });
            ResponsibleModels.Add(
                new ResponsibleModel()
                {
                    Login = "admin",
                    Password = "1",
                    FullName = "Admin1"
                });

            login = "admin";
            password = "1";
        }
        private void Auth()
        {
            var responsible = ResponsibleModels.FirstOrDefault(r => r.Login == login);
            if (responsible != null)
            {
                if (responsible.Password == password)
                {
                    ClearError();
                    ResponsibleState.ResponsibleModel = responsible;
                    NavigationManager.NavigateTo("/Index");
                }
                else
                {
                    error = "Pas";
                }
            }
            else
            {
                error = "log";
            }
        }

        private void ClearError()
        {
            error = null;
        }
    }
}
