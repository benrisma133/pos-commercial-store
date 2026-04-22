using Repository.Models;
using Repository.Repositories;
using Service.Services;

namespace POSApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            Category category = new Category
            {
                Name = "Test99"
            };

            CategoryService categoryService = new CategoryService(category);

            string result = categoryService.Save() ? $"Category saved successfully with ID = {categoryService.CategoryId}." : "Failed to save category.";

            lblResult.Text = result;

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
