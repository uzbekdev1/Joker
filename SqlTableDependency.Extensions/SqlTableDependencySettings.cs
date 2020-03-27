﻿using TableDependency.SqlClient.Base.Abstracts;
using TableDependency.SqlClient.Base.Enums;

namespace SqlTableDependency.Extensions
{        
  /// <summary>
  /// Additional settings for <see cref="SqlTableDependency{T}" /> class.
  /// </summary>
  public class SqlTableDependencySettings<TEntity> 
    where TEntity : class
  {
    /// <value>
    /// Name of the database schema.
    /// </value>
    public string SchemaName { get; set; }
    
    /// <value>
    /// List of columns that need to monitor for changing on order to receive notifications.
    /// </value>
    public IUpdateOfModel<TEntity> UpdateOf { get; set; }
    
    /// <value>
    /// The filter condition translated in WHERE.
    /// </value>
    public ITableDependencyFilter Filter { get; set; }
    
    /// <value>
    /// The notify on Insert, Delete, Update operation.
    /// </value>
    public DmlTriggerType NotifyOn { get; set; } = DmlTriggerType.All;
    
    /// <value>
    /// if set to <c>true</c> [skip user permission check].
    /// </value>
    public bool ExecuteUserPermissionCheck { get; set; } = true;
    
    /// <value>
    /// if set to <c>true</c> [include old values].
    /// </value>
    public bool IncludeOldValues { get; set; }
  }
}