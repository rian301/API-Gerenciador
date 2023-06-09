﻿using Dufry.Domain.Enums;
using Black.Domain.Core.Models;
using System;

namespace Black.Domain.Models
{
    public class LogAudit : Entity<LogAudit, Guid>
    {
        #region Properties
        public DateTime LogDate { get; private set; }
        public int? UserId { get; private set; }
        public LogAuditType LogType { get; private set; }
        public string TableName { get; private set; }
        public string KeyValues { get; private set; }
        public string OldValues { get; private set; }
        public string NewValues { get; private set; }
        public string ChangedColumns { get; private set; }

        #endregion

        #region Constructors
        public LogAudit()
        {
        }

        public LogAudit(int? userId, LogAuditType logType, string tableName, string keyValues, string oldValues, string newValues, string changedColumns)
        {
            Id = Guid.NewGuid();
            LogDate = DateTime.Now;
            UserId = userId;
            LogType = logType;
            TableName = tableName;
            KeyValues = keyValues;
            OldValues = oldValues;
            NewValues = newValues;
            ChangedColumns = changedColumns;

        }
        #endregion

        #region Methods
        public override bool IsValid()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
