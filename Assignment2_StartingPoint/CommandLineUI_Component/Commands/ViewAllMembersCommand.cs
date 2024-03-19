using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class ViewAllMembersCommand : Command
    {

        public ViewAllMembersCommand()
        {
        }

        public void Execute()
        {
            ViewAllMembersController controller =
                new ViewAllMembersController(
                        new AllMembersPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
