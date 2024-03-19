using DTOs;

namespace UseCase
{
    public abstract class AbstractController
    {

        protected AbstractPresenter presenter;

        public AbstractController(AbstractPresenter presenter)
        {
            this.presenter = presenter;
        }

        public IViewData Execute()
        {
            presenter.DataToPresent = ExecuteUseCase();
            return presenter.ViewData;
        }

        public abstract IDto ExecuteUseCase();
    }
}
