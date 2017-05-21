using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUser" in both code and config file together.
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        List<User> getUserInfo();

        [OperationContract]
        List<User> getUserID();

        [OperationContract]
        string insertUser(User data);

        [OperationContract]
        string updateUser(User data);
    }
}
