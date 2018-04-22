namespace Obd2Interface
{
    using Commands;

    public static class QueryFactory
    {
        #region Mode 1 - Show Current Data

        public static GetEngineRpm GetEngineRpm => new GetEngineRpm();

        public static GetVehicleSpeed GetVehicleSpeed => new GetVehicleSpeed();

        #endregion


        #region Diagnostic Trouble Codes

        public static GetStoredTroubleCodesQuery GetStoredDiagnosticTroubleCodes => new GetStoredTroubleCodesQuery();

        public static GetPendingTroubleCodesQuery GetPendingDiagnosticTroubleCodes => new GetPendingTroubleCodesQuery();

        public static GetPermanentTroubleCodesQuery GetPermanentDiagnosticTroubleCodes => new GetPermanentTroubleCodesQuery();

        #endregion
    }
}
