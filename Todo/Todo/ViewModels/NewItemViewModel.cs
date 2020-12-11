using System;
using Todo.Models;
using Xamarin.Forms;

namespace Todo.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        #region Fields
        private bool ValidateSave() => !string.IsNullOrWhiteSpace(text)
                && !string.IsNullOrWhiteSpace(description);

        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        #endregion

        #region Constructors
        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        #endregion

        private async void OnCancel() =>
        // This will pop the current page off the navigation stack
        await Shell.Current.GoToAsync("..");

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Title = Text,
                Description = Description
            };

            await ItemService.CreateAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
