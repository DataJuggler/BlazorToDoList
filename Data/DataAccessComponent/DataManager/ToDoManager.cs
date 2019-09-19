

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class ToDoManager
    /// <summary>
    /// This class is used to manage a 'ToDo' object.
    /// </summary>
    public class ToDoManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ToDoManager' object.
        /// </summary>
        public ToDoManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteToDo()
            /// <summary>
            /// This method deletes a 'ToDo' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteToDo(DeleteToDoStoredProcedure deleteToDoProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteToDoProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllToDos()
            /// <summary>
            /// This method fetches a  'List<ToDo>' object.
            /// This method uses the 'ToDos_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ToDo>'</returns>
            /// </summary>
            public List<ToDo> FetchAllToDos(FetchAllToDosStoredProcedure fetchAllToDosProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ToDo> toDoCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allToDosDataSet = this.DataHelper.LoadDataSet(fetchAllToDosProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allToDosDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allToDosDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            toDoCollection = ToDoReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return toDoCollection;
            }
            #endregion

            #region FindToDo()
            /// <summary>
            /// This method finds a  'ToDo' object.
            /// This method uses the 'ToDo_Find' procedure.
            /// </summary>
            /// <returns>A 'ToDo' object.</returns>
            /// </summary>
            public ToDo FindToDo(FindToDoStoredProcedure findToDoProc, DataConnector databaseConnector)
            {
                // Initial Value
                ToDo toDo = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet toDoDataSet = this.DataHelper.LoadDataSet(findToDoProc, databaseConnector);

                    // Verify DataSet Exists
                    if(toDoDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(toDoDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ToDo
                            toDo = ToDoReader.Load(row);
                        }
                    }
                }

                // return value
                return toDo;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertToDo()
            /// <summary>
            /// This method inserts a 'ToDo' object.
            /// This method uses the 'ToDo_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertToDo(InsertToDoStoredProcedure insertToDoProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertToDoProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateToDo()
            /// <summary>
            /// This method updates a 'ToDo'.
            /// This method uses the 'ToDo_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateToDo(UpdateToDoStoredProcedure updateToDoProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateToDoProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
