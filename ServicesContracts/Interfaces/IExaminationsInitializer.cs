namespace ServicesContracts.Interfaces
{
    /// <summary>
    /// Скачивает из госуслуг проверки за период определённый в параметре, загружает их в базу данных
    /// </summary>
    public interface IExaminationsInitializer
    {
        Task Initialize();
    }
}
