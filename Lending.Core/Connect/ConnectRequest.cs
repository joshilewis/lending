using System;

namespace Lending.Core.Connect
{
    public class ConnectRequest
    {
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }

        public ConnectRequest()
        {
            
        }

        public ConnectRequest(long fromUserId, long toUserId)
        {
            FromUserId = fromUserId;
            ToUserId = toUserId;
        }
    }
}