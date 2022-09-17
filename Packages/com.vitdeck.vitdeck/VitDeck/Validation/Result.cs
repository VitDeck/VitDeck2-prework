using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace VitDeck.Validation
{
    public class Result : ScriptableObject
    {
        public string Message { get; private set; }
        
        [SerializeField] private List<LogBase> logs = new List<LogBase>();
        public IReadOnlyList<LogBase> Logs => logs;

        public void Initialize(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public void AddLog(LogBase log)
        {
            logs.Add(log);
        }

        public void AddLog(LogType type, string message)
        {
            logs.Add(MessageLog.Create(type, message));
        }
        
    }
}