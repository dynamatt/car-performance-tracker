namespace Obd2Interface
{
    public enum Mode : byte
    {
        /// <summary>
        /// Show current data.
        /// </summary>
        ShowCurrentData = 0x01,

        /// <summary>
        /// Show freeze frame data.
        /// </summary>
        ShowFreezeFrameData = 0x02,

        /// <summary>
        /// Show stored diagnostic trouble codes.
        /// </summary>
        ShowStoredDiagnosticTroubleCodes = 0x03,

        /// <summary>
        /// Clear diagnostic trouble codes and stored values.
        /// </summary>
        ClearDiagnosticTroubleCodesAndStoredValues = 0x04,

		/// <summary>
		/// Test results, oxygen sensor monitoring (non CAN only).
		/// </summary>
		TestResultsNonCan = 0x05,

		/// <summary>
		/// Test results, other component/system monitoring (Test results, oxygen sensor monitoring for CAN only).
		/// </summary>
		TestResultsCan = 0x06,

		/// <summary>
		/// Show pending Diagnostic Trouble Codes (detected during current or last driving cycle).
		/// </summary>
		ShowPendingDiagnosticTroubleCodes = 0x07,

		/// <summary>
		/// Control operation of on-board component/system.
		/// </summary>
		ControlOperationOfOnboardComponent = 0x08,

        /// <summary>
        /// Request vehicle information.
        /// </summary>
        RequestVehicleInformation = 0x09,

		/// <summary>
		/// Permanent Diagnostic Trouble Codes (DTCs) (Cleared DTCs).
		/// </summary>
		PermanentDiagnosticTroubleCodes = 0x0A,
    }
}
