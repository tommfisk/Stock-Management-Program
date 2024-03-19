using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class RenewLoanCommand : Command
    {

        public RenewLoanCommand()
        {
        }

        public void Execute()
        {
            RenewLoanController controller = 
                new RenewLoanController(
                    ConsoleReader.ReadInt("\nMember ID"),
                    ConsoleReader.ReadInt("Book ID"),
                    new MessagePresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
