using System;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountGuidCreateService : IAccountNumberCreateService
    {
        public int CreateId() => Math.Abs(Guid.NewGuid().GetHashCode());
    }
}
