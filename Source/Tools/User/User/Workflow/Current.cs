﻿using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using PZone.Activities;
using PZone.Common.Workflow;


namespace PZone.UserTools.Workflow
{
    /// <summary>
    /// Получение текущих пользователей, кто инициировал запуск процесса и от чьего имени выполняется процесс.
    /// </summary>
    public class Current : WorkflowBase
    {
        /// <summary>
        /// Пользователь, от имени которого выполняется процесс.
        /// </summary>
        [Output("Current User")]
        [ReferenceTarget("systemuser")]
        public OutArgument<EntityReference> CurrentUser { get; set; }


        /// <summary>
        /// Пользователь, инициировавший запуск процесса.
        /// </summary>
        [Output("Initiating User")]
        [ReferenceTarget("systemuser")]
        public OutArgument<EntityReference> InitiatingUser { get; set; }


        /// <inheritdoc />
        protected override void Execute(Context context)
        {
            CurrentUser.Set(context, new EntityReference("systemuser", context.SourceContext.UserId));
            InitiatingUser.Set(context, new EntityReference("systemuser", context.SourceContext.InitiatingUserId));
        }
    }
}