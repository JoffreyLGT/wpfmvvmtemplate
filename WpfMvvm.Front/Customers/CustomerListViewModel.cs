using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using WpfMvvm.Business.Models;
using WpfMvvm.Data.Services;
using WpfMvvm.Front.MvvmUtils;

namespace WpfMvvm.Front.Customers
{
    public class CustomerListViewModel : BindableBase
    {
        // Repository where the data is stored
        private readonly ICustomerRepository repository;

        public CustomerListViewModel(ICustomerRepository repository)
        {
            this.repository = repository;
            // Set the default values
            editMode = false;
            editedCustomer = new Customer();
            selectedCustomer = null;
            // Register the commands
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            EditCommand = new RelayCommand(OnEdit, CanEdit);
            NewCommand = new RelayCommand(OnNew);
            AddCommand = new RelayCommand(OnAdd, CanAdd);
        }

        /// <summary>
        /// Flag to know if we are editing a customer or adding one.
        /// </summary>
        private bool editMode;
        public bool EditMode
        {
            get { return editMode; }
            set { 
                SetProperty(ref editMode, value); 
            }
        }

        /// <summary>
        /// All the customers.
        /// </summary>
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get => customers;
            set { SetProperty(ref customers, value); }
        }

        /// <summary>
        /// Customer currently selected in the list.
        /// </summary>
        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set { 
                SetProperty(ref selectedCustomer, value);
                EditedCustomer = new Customer(selectedCustomer);
                EditMode = true;
                RaiseAllCanExecute();
            }
        }

        /// <summary>
        /// Customer displated in the text blocks.
        /// </summary>
        private Customer editedCustomer;
        public Customer EditedCustomer
        {
            get => editedCustomer;
            set { SetProperty(ref editedCustomer, value); }
        }

        /// <summary>
        /// Triggered when the user click on the New button.
        /// </summary>
        private void OnNew()
        {
            editedCustomer = new Customer();
            SelectedCustomer = null;
            EditMode = false;
            RaiseAllCanExecute();
        }

        /// <summary>
        /// Triggered when the user click on the Add button.
        /// </summary>
        private async void OnAdd()
        {
            if (editMode) return;
            await repository.AddCustomerAsync(EditedCustomer);
            await ClearSelectionAndReload();
        }

        /// <summary>
        /// Triggered when the user click on the Edit button.
        /// </summary>
        private async void OnEdit()
        {
            if (editMode)
            {
                await repository.UpdateCustomerAsync(EditedCustomer);
                await ClearSelectionAndReload();
            }
        }

        /// <summary>
        /// Delete the currently selected customer.
        /// </summary>
        private async void OnDelete()
        {
            await repository.DeleteCustomerAsync(selectedCustomer.Id);
            await LoadCustomers();
            EditMode = false;
            RaiseAllCanExecute();
        }
        /// <summary>
        /// Clear the selected client, set editMode to false and load
        /// the customers.
        /// </summary>
        private async Task ClearSelectionAndReload()
        {
            await LoadCustomers();
            EditMode = false;
            selectedCustomer = null;
            EditedCustomer = new Customer();
            RaiseAllCanExecute();
        }

        public async Task LoadCustomers()
        {
            // Make sure the code is not executed in the designer
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            Customers = new ObservableCollection<Customer>(await repository.GetCustomersAsync());
        }

        #region Commands
        /// <summary>
        /// Raise all the CanExecute commands to update their state.
        /// </summary>
        public void RaiseAllCanExecute()
        {
            AddCommand.RaiseCanExecuteChanged();
            EditCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
        }
        public RelayCommand NewCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        private bool CanDelete()
        {
            return EditMode;
        }

        public RelayCommand EditCommand { get; private set; }
        private bool CanEdit()
        {
            return EditMode;
        }
        public RelayCommand AddCommand { get; private set; }
        private bool CanAdd()
        {
            return !EditMode;
        }
        #endregion
    }
}
