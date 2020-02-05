using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace FortuneRegistry.Shared.Models
{
    public interface IBaseDbModel
    {
        ObjectId Id { get; set; }
    }
}
