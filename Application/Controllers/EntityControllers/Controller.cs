using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using SCS.Entities;
using Pages.Tables;
using Input.Fields;

namespace SCS.Controllers
{
    /// <summary>
    /// Base class for an entity controller.
    /// </summary>
    abstract class Controller<T> where T : Entity
    {
        public Table table;

        /// <summary>
        /// Entity object collection list.
        /// </summary>
        public abstract List<T> Collection { get; }

        /// <summary>
        /// Adds a new object to the corresponding entity collection.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        public void Add(T entity) => Collection.Add(entity);
        /// <summary>
        /// Adds a multiple objects to the corresponding entity collection.
        /// </summary>
        /// <param name="entities">An array of entities to be added.</param>
        public void Add(T[] entities) => entities.ToList().ForEach(x => Add(x));
        /// <summary>
        /// Updates an existing object from the corresponding entity collection.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <param name="id">The entity's index on the collection.</param>
        public void Update(T entity, int id) => Collection[id] = entity;
        /// <summary>
        /// Deletes an object from the corresponding entity collection.
        /// </summary>
        /// <param name="id">The entity's index on the collection.</param>
        public void Delete(int id) => Collection.RemoveAt(id);
        /// <summary>
        /// Deletes an object from the corresponding entity collection.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        public void Delete(T entity) => Collection.Remove(entity);
       
        /// <summary>
        /// Prints a table of entity objects on the console.
        /// </summary>
        /// <param name="list">The list of the entities to appear on the table. If left null, all are selected.</param>
        public void ShowTable(T[] list = null)
        {
            if (list is null) list = Collection.ToArray();
            foreach (var item in list)
            {
                table.AddRow(GetValuesAsStrings(item));
            }
            table.Render();
            table.Rows.Clear();
        }

        /// <summary>
        /// Converts the values of an entity to strings and returns them as an array.
        /// </summary>
        /// <param name="entity">The entity to convert the values from.</param>
        protected abstract string[] GetValuesAsStrings(T entity);
        public abstract T ToObject(string[] inputs);
        /// <summary>
        /// Returns the input fields that match the values of the entity type.
        /// </summary>
        public abstract Field[] GetInputFields();
    }
}
