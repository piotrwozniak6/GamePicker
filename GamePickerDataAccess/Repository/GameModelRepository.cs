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
        // _db.Update(item);
        var itemDb = _db.GameModels.FirstOrDefault(u=>u.Id==item.Id);
        if (item != null)
        {
            itemDb.Title = item.Title;
            itemDb.Description= item.Description;
            itemDb.Publisher= item.Publisher;
            itemDb.RegularPrice= item.RegularPrice;
            itemDb.Price= item.Price;
            itemDb.Price50= item.Price50;
            itemDb.Price100= item.Price100;
            itemDb.Id = item.Id;
            if (item.ImageUrl != null)
            {
                itemDb.ImageUrl = item.ImageUrl;
            }
        }
    }
}