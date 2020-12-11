using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Todo.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        #region Fields
        public string Id { get; set; }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _itemId;
        public string ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }
        #endregion

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await ItemService.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Title;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
