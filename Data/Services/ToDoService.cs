

using DataJuggler.UltimateHelper.Core;
using DataGateway;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BlazorToDo.Data.Services
{
    public class ToDoService
    {
    
        /// <summary>
        /// This method is used to load the Site 
        /// </summary>
        /// <returns></returns>
        public static Task<List<ToDo>> GetToDoList()
        {
            // initial value
            List<ToDo> list = null;

            // Create a new instance of a 'Gateway' object, and set the connectionName
            Gateway gateway = new Gateway(Connection.Name);

            // load the sites
            list = gateway.LoadToDos();

            // return the list
            return Task.FromResult(list);
        }

        /// <summary>
        /// This method is used to load the Site 
        /// </summary>
        /// <returns></returns>
        public static Task<bool> CreateToDo(string title)
        {
            // initial value
            bool saved = false;

            // Create a new instance of a 'Gateway' object, and set the connectionName
            Gateway gateway = new Gateway(Connection.Name);

            // Create a new ToDo item
            ObjectLibrary.BusinessObjects.ToDo toDo = new ToDo();

            // Set the Title
            toDo.Title = title;

            // load the sites
            saved = gateway.SaveToDo(ref toDo);

            // return the value of saved
            return Task.FromResult(saved);
        }

        /// <summary>
        /// This method is used to delete a ToDo
        /// </summary>
        /// <returns></returns>
        public static Task<bool> RemoveToDo(ToDo toDo)
        {
            // initial value
            bool deleted = false;

            // if the toDo object exists
            if (NullHelper.Exists(toDo))
            {
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);

                // load the sites
                deleted = gateway.DeleteToDo(toDo.Id);
            }

            // return the value of saved
            return Task.FromResult(deleted);
        }
    }
}
