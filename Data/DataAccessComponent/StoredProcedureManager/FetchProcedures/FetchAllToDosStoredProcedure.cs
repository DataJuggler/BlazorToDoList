

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;

#endregion


namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllToDosStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ToDo' objects.
    /// </summary>
    public class FetchAllToDosStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllToDosStoredProcedure' object.
        /// </summary>
        public FetchAllToDosStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "ToDo_FetchAll";

                // Set tableName
                this.TableName = "ToDo";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
