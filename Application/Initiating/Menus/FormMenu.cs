using System;
using SCS.View.Menus;
using SCS.Controllers;
using SCS.Entities;
using Printer;
using Input.Fields;
using System.Linq;
using Input;

namespace SCS.Initiating.Menus
{
    class FormMenu<T> : IInitiating
        where T : Entity
    {
        Controller<T> ctrl;
        MenuType menu;

        public FormMenu(Controller<T> ctrl, MenuType menu)
        {
            this.ctrl = ctrl;
            this.menu = menu;
        }

        public void Initiate()
        {
            InitiateAdd();
            InitiateUpdate();
            InitiateDelete();
        }

        private void InitiateAdd()
        {
            Action show = () =>
            {
                Field[] fields = ctrl.GetInputFields();
                string[] inputs = fields.Select(x => x.GetInput()).ToArray();
                T obj = ctrl.ToObject(inputs);

                ctrl.Add(obj);
                Navigator.GoTo(menu);
            };
            Collection.list[menu + 1] = new Menu(show);
        }

        private void InitiateUpdate()
        {
            Action show = () =>
            {
                Field[] fields;
                string[] inputs;
                T obj;
                int id;

                ctrl.ShowTable();
                Output.Print(lineBreaks: 2);
                
                id = AskNumber.GetInput(0, ctrl.Collection.Count + 1, "Type the id of the row you want to edit (enter 0 to cancel):");
                if (id > 0)
                {
                    fields = ctrl.GetInputFields();
                    inputs = fields.Select(x => x.GetInput()).ToArray();
                    obj = ctrl.ToObject(inputs);
                    ctrl.Update(obj, --id);
                }
                Navigator.GoTo(menu);
            };
            Collection.list[menu + 2] = new Menu(show);
        }

        private void InitiateDelete()
        {
            Action show = () =>
            {
                int id;

                ctrl.ShowTable();
                Output.Print(lineBreaks: 2);
                id = AskNumber.GetInput(0, ctrl.Collection.Count + 1, "Type the id of the row you want to remove (enter 0 to cancel):");
                if (id > 0) ctrl.Delete(--id);
                Navigator.GoTo(menu);
            };
            Collection.list[menu + 3] = new Menu(show);
        }
    }
}
