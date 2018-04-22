using System;

using AppKit;
using Foundation;

using EngineLogger.Services;
using Obd2Interface;
using System.Threading.Tasks;

namespace EngineLogger.OSX
{
    public partial class ViewController : NSViewController
    {
        private IObd2Connection connection;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            this.ConnectionStatus.StringValue = "Not connected";
        }

        protected override void Dispose(Boolean disposing)
        {
            base.Dispose(disposing);

            if (connection != null && connection is IDisposable c) c.Dispose();
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void ConnectClicked(Foundation.NSObject sender)
        {
            this.ConnectionProgressIndicator.StartAnimation(this);
            this.ConnectionStatus.StringValue = "Connecting...";
            this.ConnectionStatus.TextColor = NSColor.Black;

            Task.Run(() => {
                this.connection = new Obd2TcpConnection();     
            }).ContinueWith(t => {
                //this.ConnectionStatus.StringValue = "Connected";
                //this.ConnectionStatus.TextColor = NSColor.Green;
                //this.ConnectionProgressIndicator.StopAnimation(this);
            }, TaskContinuationOptions.NotOnFaulted).ContinueWith(t => {
                //this.ConnectionStatus.StringValue = "Could not connect";
                //this.ConnectionStatus.TextColor = NSColor.Red;
                //this.ConnectionProgressIndicator.StopAnimation(this);
            }, TaskContinuationOptions.OnlyOnFaulted);


        }

        partial void StartDiagnosticsClicked(Foundation.NSObject sender)
        {
            this.DiagnosticsReport.StringValue = string.Empty;

            if (this.connection == null)
            {
                this.DiagnosticsReport.StringValue += "Not connected\n";
                return;
            }

            this.DiagnosticsReport.StringValue += "Running diagnostics\n";

            var engineRpm = QueryFactory.GetEngineRpm.Send(this.connection);
            this.DiagnosticsReport.StringValue += "RPM: " + engineRpm.Value + Environment.NewLine;

            var troubleCodes = QueryFactory.GetStoredDiagnosticTroubleCodes.Send(this.connection);
            this.DiagnosticsReport.StringValue += "Trouble code response: " + troubleCodes + Environment.NewLine;
        }
    }
}
