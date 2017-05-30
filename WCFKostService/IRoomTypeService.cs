using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomTypeService" in both code and config file together.
    [ServiceContract]
    public interface IRoomTypeService
    {
        [OperationContract]
        List<RoomTypeInfo> getTotalRoomType();

        [OperationContract]
        List<RoomTypeInfo> getRoomType();

        [OperationContract]
        List<RoomTypeInfo> getReservation(string id);
    }
}
