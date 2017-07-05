using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using SampleOdataService.Models;
using SampleOdataService.Providers;
using SampleOdataService.Results;
using TicketDataService.DataSource;
using TicketDataService.Models;

namespace TicketDataService.Controllers
{
    public class AccountsController : ODataController
    {
        [EnableQuery(MaxTop = 10000)]
        public IQueryable<Account> Get()
        {
            ValidateRequest();

            return AccountDataSource.Instance.Accounts.AsQueryable();
        }

        private void ValidateRequest()
        {
            if (!this.Request.Headers.Contains("abc"))
                throw new InvalidOperationException("Missing request header abc");

            IEnumerable<string> values;
            if (this.Request.Headers.TryGetValues("abc", out values) && values.First() != "testauthentication")
                throw new InvalidOperationException("Invalid value for header abc");

            NameValueCollection qscoll = this.Request.RequestUri.ParseQueryString();
            if (qscoll["xyz"] == null)
                throw new InvalidOperationException("Missing query string xyz");

            if (qscoll["xyz"] != "testauthentication")
                throw new InvalidOperationException("Invalid value for query string xyz");
        }

        [EnableQuery]
        public SingleResult<Account> Get([FromODataUri] Guid key)
        {
            ValidateRequest();
            IQueryable<Account> result = AccountDataSource.Instance.Accounts.AsQueryable()
                .Where(p => p.AccountID == key);
            return SingleResult.Create(result);
        }

    }
}
