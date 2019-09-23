

#region using statements

using ApplicationLogicComponent.Connection;
using DataJuggler.UltimateHelper.Core;
using DataGateway;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace DataGateway.Services
{

    #region class ToDoService
    /// <summary>
    /// This is the Service class for managing ToDo objects.
    /// </summary>
    public class ToDoService
    {

        #region Methods
            
            #region GetToDoList()
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
            #endregion
            
            #region RemoveToDo(ToDo toDo)
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
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region SaveToDo(ref ToDo toDo)
            /// <summary>
            /// This method is used to create ToDo objects
            /// </summary>
            /// <param name="toDo">Pass in an object of type ToDo to save</param>
            /// <returns></returns>
            public static Task<bool> SaveToDo(ref ToDo toDo)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveToDo(ref toDo);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
