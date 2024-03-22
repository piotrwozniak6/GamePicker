using GamePickerDataAccess.Data;
using GamePickerDataAccess.Repository.IRepository;
using GamePickerModels.Models;

namespace GamePickerDataAccess.Repository;

public class GameModelRepository: Repository<GameModel>, IGameModelRepository 
{
    private ApplicationDbContext _db;

    public GameModelRepository(ApplicationDbContext db): base(db)
    {
        _db = db;
    }
    
    public void Update(GameModel item)
    {
        _db.Update(item);
    }
}