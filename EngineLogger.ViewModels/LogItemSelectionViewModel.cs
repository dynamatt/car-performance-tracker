namespace EngineLogger.ViewModels
{
    using Prism.Mvvm;

    public class LogItemSelectionViewModel : BindableBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        private bool isSelected;
        public bool IsSelected 
        { 
            get => this.isSelected; 
            set => this.SetProperty(ref this.isSelected, value); 
        }
    }
}
