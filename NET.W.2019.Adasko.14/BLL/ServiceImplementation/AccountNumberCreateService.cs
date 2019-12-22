using System;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreateService : IAccountNumberCreateService
    {
        public int CreateId() => Guid.NewGuid().GetHashCode();
    }
}
