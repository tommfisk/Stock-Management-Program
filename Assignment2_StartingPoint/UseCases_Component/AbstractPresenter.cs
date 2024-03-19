using DTOs;

namespace UseCase
{
    public abstract class AbstractPresenter
    {

        public IDto DataToPresent { get; set; }

        public abstract IViewData ViewData { get; }
    }
}
