using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class ViewCurrentLoansCommand : Command
    {

        public ViewCurrentLoansCommand()
        {
        }

        public void Execute()
        {
            ViewCurrentLoansController controller =
                new ViewCurrentLoansController(
                        new CurrentLoansPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
