

#region using statements

using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class ToDoReader
    /// <summary>
    /// This class loads a single 'ToDo' object or a list of type <ToDo>.
    /// </summary>
    public class ToDoReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ToDo' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ToDo' DataObject.</returns>
            public static ToDo Load(DataRow dataRow)
            {
                // Initial Value
                ToDo toDo = new ToDo();

                // Create field Integers
                int idfield = 0;
                int isDonefield = 1;
                int titlefield = 2;

                try
                {
                    // Load Each field
                    toDo.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    toDo.IsDone = DataHelper.ParseBoolean(dataRow.ItemArray[isDonefield], false);
                    toDo.Title = DataHelper.ParseString(dataRow.ItemArray[titlefield]);
                }
                catch
                {
                }

                // return value
                return toDo;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ToDo' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ToDo Collection.</returns>
            public static List<ToDo> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ToDo> toDos = new List<ToDo>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ToDo' from rows
                        ToDo toDo = Load(row);

                        // Add this object to collection
                        toDos.Add(toDo);
                    }
                }
                catch
                {
                }

                // return value
                return toDos;
            }
            #endregion

        #endregion

    }
    #endregion

}
