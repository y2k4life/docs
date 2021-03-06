﻿using System;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace Raven.Documentation.Samples.ClientApi.Operations.Server
{
    public class CreateDeleteDatabase
    {
        private class Foo
        {
            public class DeleteDatabasesOperation
            {
                #region delete_database_syntax
                public DeleteDatabasesOperation(
                    string databaseName,
                    bool hardDelete,
                    string fromNode = null,
                    TimeSpan? timeToWaitForConfirmation = null)
                {
                }

                public DeleteDatabasesOperation(DeleteDatabasesOperation.Parameters parameters)
                {
                }

                public class Parameters
                {
                    public string[] DatabaseNames { get; set; }

                    public bool HardDelete { get; set; }

                    public string[] FromNodes { get; set; }

                    public TimeSpan? TimeToWaitForConfirmation { get; set; }
                }
                #endregion
            }

            public class CreateDatabaseOperation
            {
                #region create_database_syntax
                public CreateDatabaseOperation(
                    DatabaseRecord databaseRecord,
                    int replicationFactor = 1)
                {
                }
                #endregion
            }
        }

        public CreateDeleteDatabase()
        {
            using (var store = new DocumentStore())
            {
                #region CreateDatabase
                store.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord("MyNewDatabase")));
                #endregion

                #region DeleteDatabase
                store.Maintenance.Server.Send(new DeleteDatabasesOperation("MyNewDatabase", hardDelete: true, fromNode: null, timeToWaitForConfirmation: null));
                #endregion

                #region DeleteDatabases
                var parameters = new DeleteDatabasesOperation.Parameters
                {
                    DatabaseNames = new[] { "MyNewDatabase", "OtherDatabaseToDelete" },
                    HardDelete = true,
                    FromNodes = new[] { "A", "C" },     // optional
                    TimeToWaitForConfirmation = TimeSpan.FromSeconds(30)    // optional
                };
                store.Maintenance.Server.Send(new DeleteDatabasesOperation(parameters));
                #endregion
            }
        }

        public async Task CreateDeleteDatabaseAsync()
        {
            using (var store = new DocumentStore())
            {
                #region CreateDatabaseAsync
                await store.Maintenance.Server.SendAsync(new CreateDatabaseOperation(new DatabaseRecord("MyNewDatabase")));
                #endregion

                #region DeleteDatabaseAsync
                await store.Maintenance.Server.SendAsync(new DeleteDatabasesOperation("MyNewDatabase", hardDelete: true, fromNode: null, timeToWaitForConfirmation: null));
                #endregion

                #region DeleteDatabasesAsync
                var parameters = new DeleteDatabasesOperation.Parameters
                {
                    DatabaseNames = new[] { "MyNewDatabase", "OtherDatabaseToDelete" },
                    HardDelete = true,
                    FromNodes = new[] { "A", "C" },   // optional
                    TimeToWaitForConfirmation = TimeSpan.FromSeconds(30)    // optional
                };
                await store.Maintenance.Server.SendAsync(new DeleteDatabasesOperation(parameters));
                #endregion
            }
        }
    }
}
