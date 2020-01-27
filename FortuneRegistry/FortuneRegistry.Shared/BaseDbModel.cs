using FortuneRegistry.Shared.Models;
using MongoDB.Bson;

namespace FortuneRegistry.Shared
{
    public abstract class BaseDbModel : IBaseDbModel
    {
        public ObjectId Id { get; set; }
    }
}
