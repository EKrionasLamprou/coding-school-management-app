using System.Collections.Generic;
using Pages.Tables;
using SCS.Entities;

namespace SCS.Controllers
{
    abstract class RelationshipController<T> where T : Entity
    {
        protected Table table;
        protected List<T> collection;

        public void ShowTable()
        {
            foreach (var entity in collection)
            {
                GetMainRow(entity);
                FillSubrows(entity);
            }
            table.Render();
            table.Rows.Clear();
        }

        protected abstract void FillSubrows(T entity);

        protected virtual void GetMainRow(T entity) =>
            table.AddRow(new string[] { entity.ToString(), "" });
    }
}
