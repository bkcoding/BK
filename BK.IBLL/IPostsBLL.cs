using BK.Models;
namespace BK.IBLL
{
    public interface IPostsBLL:IBaseBLL<posts>
    {
        posts Read(int id);
    }
}
