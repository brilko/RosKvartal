namespace RequestsContracts.Interfaces
{
    public interface IExaminationsRequestCreator
    {
        HttpRequestMessage CreateBaseRequest(DateTime startPeriod);
    }
}
