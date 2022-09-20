using Philnance.Models;

namespace Philnance.Repository
{
    public interface IFinanceNews
    {
        FinanceNews GetFinanceNews(int offset);
    }
}
