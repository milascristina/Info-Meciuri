namespace lab10.Repository;

using System;
using System.Collections.Generic;
public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : class, IEntity<ID> 
    {
        private readonly Dictionary<ID, E> _entities;

        public InMemoryRepository()
        {
            _entities = new Dictionary<ID, E>();
        }

        public E FindOne(ID id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "id-ul nu trebuie sa fie null");
            
            _entities.TryGetValue(id, out E entity);
            return entity;
        }

        public IEnumerable<E> FindAll()
        {
            return _entities.Values;
        }

        public virtual E Save(E entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "entity-ul nu trebuie sa fie null");
    
            if (_entities.ContainsKey(entity.Id))
            {
                return entity;
            }
            else
            {
                _entities[entity.Id] = entity;
                return null;
            }
        }

        public E Delete(ID id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "id-ul nu trebuie sa fie null");
            
            if (_entities.Remove(id, out E entity))
            {
                return entity;
            }
            return null;
        }

        public E Update(E entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "entity-ul nu trebuie sa fie null");
            
            if (_entities.ContainsKey(entity.Id))
            {
                _entities[entity.Id] = entity;
                return null;
            }
            return entity;
        }
    }




public interface IEntity<ID>
{
    ID Id { get; set; }
}
