namespace GamePickerDataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    IGameModelRepository GameModelRepository { get; }

    void Save();
}