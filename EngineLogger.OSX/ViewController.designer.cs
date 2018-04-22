// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace EngineLogger.OSX
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSProgressIndicator ConnectionProgressIndicator { get; set; }

		[Outlet]
		AppKit.NSTextField ConnectionStatus { get; set; }

		[Outlet]
		AppKit.NSTextField DiagnosticsReport { get; set; }

		[Action ("ConnectClicked:")]
		partial void ConnectClicked (Foundation.NSObject sender);

		[Action ("StartDiagnosticsClicked:")]
		partial void StartDiagnosticsClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ConnectionStatus != null) {
				ConnectionStatus.Dispose ();
				ConnectionStatus = null;
			}

			if (ConnectionProgressIndicator != null) {
				ConnectionProgressIndicator.Dispose ();
				ConnectionProgressIndicator = null;
			}

			if (DiagnosticsReport != null) {
				DiagnosticsReport.Dispose ();
				DiagnosticsReport = null;
			}
		}
	}
}
