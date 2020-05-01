using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace BookStoreService.Extension
{
    public class CustomDispatchMessageInspector : IDispatchMessageInspector
    {

        private const string MESSAGE_HEADER_SECURITY_TOKEN = "security-token";
        private const string MESSAGE_HEADER_NAMESPACE = "TokenNameSpace";

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            CheckIfRequestIsAuthentic(request);
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            throw new System.NotImplementedException();
        }

        private void CheckIfRequestIsAuthentic(Message message)
        {
            if (message.Headers.FindHeader(MESSAGE_HEADER_SECURITY_TOKEN, MESSAGE_HEADER_NAMESPACE) == -1)
            {
                throw new FaultException("Unauthenticated request. Security token not present in header");
            }

            var validUserToken = "dXNlcjFwYXNzd29yZDE="; 
            var securityToken = message.Headers.GetHeader<string>(MESSAGE_HEADER_SECURITY_TOKEN, MESSAGE_HEADER_NAMESPACE);

            if (!string.IsNullOrEmpty(securityToken))
            {
                if (securityToken != validUserToken)
                {
                    throw new FaultException("Unauthenticated request. Invalid Security token passed");
                }

            }
            else
            {
                throw new FaultException("Unauthenticated request. Invalid Security token passed");
            }
        }
    }
}