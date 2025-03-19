using System.Linq;
using TMPro;
using UnityEngine;
using System;

namespace LearnXR.Core.Utilities
{
    // based on
    // Dilmer Valecillos
    // https://github.com/dilmerv/com.learnxr.core/tree/master/Runtime/Scripts/Core/Utilities
    // https://learnxr.com
    // 
    // Upate Nis
    // catches all standard Logs Application.logMessageReceived

    public class SpatialLogger : Singleton<SpatialLogger>
    {
        [SerializeField] private TextMeshProUGUI debugAreaText;
        [SerializeField] private bool enableDebug;
        [SerializeField] private int maxLines = 15;
        
        void Awake()
        {
            if (debugAreaText == null)
            {
                debugAreaText = GetComponent<TextMeshProUGUI>();
            }
            debugAreaText.text = string.Empty;
            Application.logMessageReceived += HandleLog; 
        }

        void OnEnable()
        {
            debugAreaText.enabled = enableDebug;
            enabled = enableDebug;

            if (enabled)
            {
                debugAreaText.text += $"<color=\"white\">{DateTime.Now:HH:mm:ss.fff} {GetType().Name} enabled</color>\n";
            }
        }

        public void Clear() => debugAreaText.text = string.Empty;

        public void LogInfo(string message)
        {
            ClearLines();
            debugAreaText.text += $"<color=\"black\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n";
        }

        public void LogError(string message)
        {
            ClearLines();
            debugAreaText.text += $"<color=\"red\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n";
        }

        public void LogWarning(string message)
        {
            ClearLines();
            debugAreaText.text += $"<color=\"blue\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n";
        }

        private void ClearLines()
        {
            if (debugAreaText.text.Split('\n').Count() >= maxLines)
            {
                debugAreaText.text = string.Empty;
            }
        }

        void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (type == LogType.Log) LogInfo(">> " + logString);
            if (type == LogType.Warning) LogWarning(">> " + logString);
            if (type == LogType.Error) LogError(">> " + logString);
        }
    }
}
