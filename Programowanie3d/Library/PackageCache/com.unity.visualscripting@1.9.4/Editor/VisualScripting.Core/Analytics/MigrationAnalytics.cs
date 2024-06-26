using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Unity.VisualScripting.Analytics
{
    internal static class MigrationAnalytics
    {
        private const int MaxEventsPerHour = 120;
        private const int MaxNumberOfElements = 1000;
        private const string VendorKey = "unity.visualscripting";
        private const string EventName = "VScriptMigration";
        private static bool _isRegistered = false;

        internal static void Send(Data data)
        {
            if (!EditorAnalytics.enabled)
                return;

            if (!RegisterEvent())
                return;

            EditorAnalytics.SendEventWithLimit(EventName, data);
        }

        private static bool RegisterEvent()
        {
            if (!_isRegistered)
            {
                var result = EditorAnalytics.RegisterEventWithLimit(EventName, MaxEventsPerHour, MaxNumberOfElements, VendorKey);
                if (result == UnityEngine.Analytics.AnalyticsResult.Ok)
                {
                    _isRegistered = true;
                }
            }

            return _isRegistered;
        }

        [Serializable]
        internal class Data
        {
            [SerializeField]
            internal MigrationStepAnalyticsData total;
            [SerializeField]
            internal List<MigrationStepAnalyticsData> steps;
        }

        [Serializable]
        internal class MigrationStepAnalyticsData
        {
            [SerializeField]
            internal string pluginId;
            [SerializeField]
            internal string from;
            [SerializeField]
            internal string to;
            [SerializeField]
            internal bool success;
            [SerializeField]
            internal string exception;
        }
    }
}
