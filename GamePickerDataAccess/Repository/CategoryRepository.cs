using GamePickerDataAccess.Data;
using GamePickerDataAccess.Repository.IRepository;
using GamePickerModels.Models;

namespace GamePickerDataAccess.Repository;

public class CategoryRepository: Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db): base(db)
    {
        _db = db;
    }
    
    public void Update(Category item)
    {
        _db.Update(item);
    }
}