

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;

#endregion


namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteToDoStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'ToDo' object.
    /// </summary>
    public class DeleteToDoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteToDoStoredProcedure' object.
        /// </summary>
        public DeleteToDoStoredProcedure()
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
                this.ProcedureName = "ToDo_Delete";

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
