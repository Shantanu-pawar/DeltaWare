namespace DeltaCore.Controllers
{
    public class MyMapper : IMapper
    {
        public T Map<T>(object source)
        {
            return (T)source;
        }
    }
}
