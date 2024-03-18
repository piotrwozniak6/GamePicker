using GamePickerModels.Models;

namespace GamePickerDataAccess.Repository.IRepository;

public interface ICategoryRepository: IRepository<Category>
{
     void Update(Category item);
}