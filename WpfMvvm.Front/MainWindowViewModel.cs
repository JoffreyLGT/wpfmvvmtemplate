using WpfMvvm.Front.Home;
using WpfMvvm.Front.MvvmUtils;
using Unity;
using WpfMvvm.Front.Customers;
using WpfMvvm.Data.Services;

namespace WpfMvvm.Front
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly CustomerListViewModel customerListViewModel;
        private readonly HomeViewModel homeViewModel;
        private readonly ICustomerRepository repository;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            customerListViewModel = ContainerHelper.Container.Resolve<CustomerListViewModel>();
            homeViewModel = ContainerHelper.Container.Resolve<HomeViewModel>();
            repository = ContainerHelper.Container.Resolve<ICustomerRepository>();

            currentViewModel = homeViewModel;
        }

        private BindableBase currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "home":
                    CurrentViewModel = homeViewModel;
                    break;
                case "customerList":
                default:
                    CurrentViewModel = customerListViewModel;
                    break;
            }
        }
    }
}
