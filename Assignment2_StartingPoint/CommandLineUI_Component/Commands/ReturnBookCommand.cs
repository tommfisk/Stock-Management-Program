using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class ReturnBookCommand : Command
    {

        public ReturnBookCommand()
        {
        }

        public void Execute()
        {
            ReturnBookController controller = 
                new ReturnBookController(
                    ConsoleReader.ReadInt("\nMember ID"),
                    ConsoleReader.ReadInt("Book ID"),
                    new MessagePresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
