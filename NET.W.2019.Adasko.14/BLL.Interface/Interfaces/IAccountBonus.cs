using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountBonus
    {
        BankAccount Account { get; set; }

        double GetDepositBonus(decimal value);

        double GetWithdrawBonus(decimal value);
    }
}
