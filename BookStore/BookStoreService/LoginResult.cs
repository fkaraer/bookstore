using System.Runtime.Serialization;

namespace BookStoreService
{
    [DataContract]
    public class LoginResult
    {
        [DataMember]
        public bool LoginSuccess { get; set; }

        [DataMember]
        public string SecurityToken { get; set; }
    }
}