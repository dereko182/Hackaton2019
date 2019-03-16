using Xamarin.Forms;

namespace XamarinApp.Behaviors
{
    public class DisableSelectionBehavior : Behavior<ListView>
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            bindable.ItemSelected += ItemSelectedHandler;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.ItemSelected -= ItemSelectedHandler;
            base.OnDetachingFrom(bindable);
        }

        private void ItemSelectedHandler(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }
    }
}