﻿using Raven.Client.Documents;
using Raven.Documentation.Samples.Orders;
using Raven.Documentation.Samples.Indexes.Querying;

namespace Raven.Documentation.Samples.ClientApi.DocumentIdentifiers
{
    class HiloAlgorithm
    {
        public HiloAlgorithm()
        {
            #region return_hilo_1
            var store = new DocumentStore();

            using (var session = store.OpenSession())
            {
                // Store an entity will give us the hilo range (ex. 1-32)
                session.Store(new Employee 
                {
                    FirstName = "John",
                    LastName = "Doe"
                });

                session.SaveChanges();
            }

            store.Dispose(); // returning unused range [last=1, max=32]

            #endregion

            #region return_hilo_2
            var newStore = new DocumentStore();
            using (var session = store.OpenSession())
            {
                // Store an entity after disposing the last store will give us  (ex. 2-33) 
                session.Store(new Employee
                {
                    FirstName = "John",
                    LastName = "Doe"
                });

                session.SaveChanges();
            }
            #endregion
        }
    }
}
