using GamePickerModels.Models;

namespace GamePickerDataAccess.Repository.IRepository;

public interface IGameModelRepository: IRepository<GameModel>
{
     void Update(GameModel item);
}