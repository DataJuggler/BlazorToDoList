

#region using statements

using DataJuggler.UltimateHelper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Delegates;
using ObjectLibrary.Enumerations;
using DataGateway;

#endregion

namespace BlazorToDo.Data.Services
{

    #region class DataWatcher
    /// <summary>
    /// This class is used to hold the delegates so when changes occur
    /// in a ToDo item, the values are saved.
    /// </summary>
    public class DataWatcher
    {

        #region Private Variables
        
        #endregion

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public void ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                ToDo toDo = itemChanged as ToDo;

                // If the toDo object exists
                if (NullHelper.Exists(toDo))
                {
                    // Create an instance of the Gateway
                    Gateway gateway = new Gateway(Connection.Name);

                    // perform the save
                    gateway.SaveToDo(ref toDo);
                }
            }
            #endregion

            #region Watch(List<ToDo> toDos)
            /// <summary>
            /// This method watches the current list as it creates a delegate for each item.
            /// </summary>
            /// <param name="toDos"></param>
            public void Watch(List<ToDo> toDos)
            {
                // If the toDos collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(toDos))
                {
                    // Iterate the collection of ToDo objects
                    foreach (ToDo toDo in toDos)
                    {
                        // Setup the Callback for each item
                        toDo.Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
