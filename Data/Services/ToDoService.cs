

#region using statements

using DataJuggler.UltimateHelper.Core;
using DataGateway;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;

#endregion

namespace BlazorToDo.Data.Services
{

    #region class ToDoService
    /// <summary>
    /// This is the Service class for managing ToDo objects.
    /// </summary>
    public class ToDoService
    {
        #region Methods
            
            #region CreateToDo(string title)
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
            #endregion
            
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

            #region SaveToDo(toDo)
            /// <summary>
            /// This method is used to delete a ToDo
            /// </summary>
            /// <returns></returns>
            public static Task<bool> SaveToDo(ToDo toDo)
            {
                // initial value
                bool saved = false;
                
                // if the toDo object exists
                if (NullHelper.Exists(toDo))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    saved = gateway.SaveToDo(ref toDo);
                }
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
