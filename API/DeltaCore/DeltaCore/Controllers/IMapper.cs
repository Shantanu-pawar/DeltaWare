namespace DeltaCore.Controllers
{
    public interface IMapper
    {
        T Map<T>(object source);
    }
}
