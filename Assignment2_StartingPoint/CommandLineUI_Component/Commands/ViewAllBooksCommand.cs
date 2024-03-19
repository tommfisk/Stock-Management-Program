using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class ViewAllBooksCommand : Command
    {

        public ViewAllBooksCommand()
        {
        }

        public void Execute()
        {
            ViewAllBooksController controller =
                new ViewAllBooksController(
                        new AllBooksPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
