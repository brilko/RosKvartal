namespace RequestsContracts.Interfaces
{
    public interface IExaminationsUri
    {
        Uri BuildUri(int pageNumber, int pageSize);
    }
}
