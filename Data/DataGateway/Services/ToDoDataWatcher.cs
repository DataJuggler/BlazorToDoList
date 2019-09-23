
#region using statements

using DataJuggler.Net.Core.Enumerations;
using DataJuggler.UltimateHelper.Core;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class ToDoDataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// ToDo item, the delegate is notified so the values are saved.
    /// </summary>
    public class ToDoDataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                ToDo toDo = itemChanged as ToDo;

                // If the toDo object exists
                if (NullHelper.Exists(toDo))
                {
                    // perform the saved
                    bool saved = await ToDoService.SaveToDo(ref toDo);
                }
            }
            #endregion

            #region Watch(List<ToDo> toDo)
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="toDos">The list of ToDo objects to set a delegate on.</param>
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

    }
    #endregion

}
