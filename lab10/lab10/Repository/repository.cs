namespace lab10.Repository;
using System;
using System.Collections.Generic;

public interface IRepository<ID, E> where E : IEntity<ID>
{
    /// <summary>
    /// Finds the entity with the specified id.
    /// </summary>
    /// <param name="id">The id of the entity to be returned. Id must not be null.</param>
    /// <returns>The entity with the specified id, or null if no entity is found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the id is null.</exception>
    E FindOne(ID id);

    /// <summary>
    /// Returns all entities.
    /// </summary>
    /// <returns>An enumerable collection of all entities.</returns>
    IEnumerable<E> FindAll();

    /// <summary>
    /// Saves the given entity.
    /// </summary>
    /// <param name="entity">The entity to be saved. The entity must not be null.</param>
    /// <returns>Null if the entity is saved, or the entity itself if the id already exists.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the entity is null.</exception>
    /// <exception cref="ValidatorException">Thrown if the entity is not valid.</exception>
    E Save(E entity);

    /// <summary>
    /// Removes the entity with the specified id.
    /// </summary>
    /// <param name="id">The id of the entity to be removed. Id must not be null.</param>
    /// <returns>The removed entity, or null if no entity with the given id is found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the id is null.</exception>
    E Delete(ID id);

    /// <summary>
    /// Updates the given entity.
    /// </summary>
    /// <param name="entity">The entity to be updated. The entity must not be null.</param>
    /// <returns>Null if the entity is updated, or the entity itself if the id does not exist.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the entity is null.</exception>
    /// <exception cref="ValidatorException">Thrown if the entity is not valid.</exception>
    E Update(E entity);
}


