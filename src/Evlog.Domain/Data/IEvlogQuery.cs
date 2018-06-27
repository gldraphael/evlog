namespace Evlog.Domain.Data
{
    public interface IEvlogQuery<T>
    {
         T Query();
    }
}
