using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using NuGet.Common;

namespace DocumentDBPerson.repository
{
	class PersonRepositry : Repository<Person>
	{
        public PersonRepositry(DocumentClient client, string dbID, string collectionID) : base(client, dbID, collectionID)
        {

        }
    }
}
