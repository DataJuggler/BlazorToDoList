

#region using statements

using DataJuggler.UltimateHelper.Core;
using ObjectLibrary.BusinessObjects;
using DataJuggler.Net.Core.Enumerations;
using System.Collections.Generic;

#endregion

namespace BlazorToDo.Data.Services
{

    #region class ToDoDataWatcher
    /// <summary>
    /// This class is used to hold the delegates so when changes occur
    /// in a ToDo item, the values are saved.
    /// </summary>
    public class ToDoDataWatcher
    {

        #region Private Variables
        
        #endregion

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
                    bool saved = await ToDoService.SaveToDo(toDo);
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
