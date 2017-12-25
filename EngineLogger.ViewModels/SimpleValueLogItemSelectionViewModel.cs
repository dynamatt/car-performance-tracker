namespace EngineLogger.ViewModels
{
    using Obd2Interface;

    public abstract class SimpleValueLogItemSelectionViewModelBase
        : LogItemSelectionViewModel
    {
        public abstract void Refresh(IObd2Connection connection);

        private double val;
        public double Value
        {
            get => this.val;
            protected set => this.SetProperty(ref this.val, value);
        }
    }

    public class SimpleValueLogItemSelectionViewModel<Q, R>
        : SimpleValueLogItemSelectionViewModelBase
        where Q : ShowCurrentDataQuery<R>
        where R : SimpleValueResponse, new()
    {
        public Q Query { get; set; }

        public override void Refresh(IObd2Connection connection)
        {
            var response = this.Query.Send(connection);
            this.Value = response.Value;
        }
    }
}
