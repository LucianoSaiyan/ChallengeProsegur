using ChallengeProsegur.Abtractions;

namespace ChallengeProsegur.Entities.Model
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }

}