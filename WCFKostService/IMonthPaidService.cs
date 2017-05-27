using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMonthPaidService" in both code and config file together.
    [ServiceContract]
    public interface IMonthPaidService
    {
        [OperationContract]
        List<MonthPaidInfo> getMonthPaidByIDUser(string id);
    }
}
