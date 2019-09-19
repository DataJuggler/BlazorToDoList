

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class ToDoMethods
    /// <summary>
    /// This class contains methods for modifying a 'ToDo' object.
    /// </summary>
    public class ToDoMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ToDoMethods' object.
        /// </summary>
        public ToDoMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteToDo(ToDo)
            /// <summary>
            /// This method deletes a 'ToDo' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ToDo' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteToDo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteToDoStoredProcedure deleteToDoProc = null;

                    // verify the first parameters is a(n) 'ToDo'.
                    if (parameters[0].ObjectValue as ToDo != null)
                    {
                        // Create ToDo
                        ToDo toDo = (ToDo) parameters[0].ObjectValue;

                        // verify toDo exists
                        if(toDo != null)
                        {
                            // Now create deleteToDoProc from ToDoWriter
                            // The DataWriter converts the 'ToDo'
                            // to the SqlParameter[] array needed to delete a 'ToDo'.
                            deleteToDoProc = ToDoWriter.CreateDeleteToDoStoredProcedure(toDo);
                        }
                    }

                    // Verify deleteToDoProc exists
                    if(deleteToDoProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ToDoManager.DeleteToDo(deleteToDoProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ToDo' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ToDo' to delete.
            /// <returns>A PolymorphicObject object with all  'ToDos' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ToDo> toDoListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllToDosStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ToDoParameter
                    // Declare Parameter
                    ToDo paramToDo = null;

                    // verify the first parameters is a(n) 'ToDo'.
                    if (parameters[0].ObjectValue as ToDo != null)
                    {
                        // Get ToDoParameter
                        paramToDo = (ToDo) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllToDosProc from ToDoWriter
                    fetchAllProc = ToDoWriter.CreateFetchAllToDosStoredProcedure(paramToDo);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    toDoListCollection = this.DataManager.ToDoManager.FetchAllToDos(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(toDoListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = toDoListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindToDo(ToDo)
            /// <summary>
            /// This method finds a 'ToDo' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ToDo' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindToDo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ToDo toDo = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindToDoStoredProcedure findToDoProc = null;

                    // verify the first parameters is a 'ToDo'.
                    if (parameters[0].ObjectValue as ToDo != null)
                    {
                        // Get ToDoParameter
                        ToDo paramToDo = (ToDo) parameters[0].ObjectValue;

                        // verify paramToDo exists
                        if(paramToDo != null)
                        {
                            // Now create findToDoProc from ToDoWriter
                            // The DataWriter converts the 'ToDo'
                            // to the SqlParameter[] array needed to find a 'ToDo'.
                            findToDoProc = ToDoWriter.CreateFindToDoStoredProcedure(paramToDo);
                        }

                        // Verify findToDoProc exists
                        if(findToDoProc != null)
                        {
                            // Execute Find Stored Procedure
                            toDo = this.DataManager.ToDoManager.FindToDo(findToDoProc, dataConnector);

                            // if dataObject exists
                            if(toDo != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = toDo;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertToDo (ToDo)
            /// <summary>
            /// This method inserts a 'ToDo' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ToDo' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertToDo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ToDo toDo = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertToDoStoredProcedure insertToDoProc = null;

                    // verify the first parameters is a(n) 'ToDo'.
                    if (parameters[0].ObjectValue as ToDo != null)
                    {
                        // Create ToDo Parameter
                        toDo = (ToDo) parameters[0].ObjectValue;

                        // verify toDo exists
                        if(toDo != null)
                        {
                            // Now create insertToDoProc from ToDoWriter
                            // The DataWriter converts the 'ToDo'
                            // to the SqlParameter[] array needed to insert a 'ToDo'.
                            insertToDoProc = ToDoWriter.CreateInsertToDoStoredProcedure(toDo);
                        }

                        // Verify insertToDoProc exists
                        if(insertToDoProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ToDoManager.InsertToDo(insertToDoProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateToDo (ToDo)
            /// <summary>
            /// This method updates a 'ToDo' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ToDo' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateToDo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ToDo toDo = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateToDoStoredProcedure updateToDoProc = null;

                    // verify the first parameters is a(n) 'ToDo'.
                    if (parameters[0].ObjectValue as ToDo != null)
                    {
                        // Create ToDo Parameter
                        toDo = (ToDo) parameters[0].ObjectValue;

                        // verify toDo exists
                        if(toDo != null)
                        {
                            // Now create updateToDoProc from ToDoWriter
                            // The DataWriter converts the 'ToDo'
                            // to the SqlParameter[] array needed to update a 'ToDo'.
                            updateToDoProc = ToDoWriter.CreateUpdateToDoStoredProcedure(toDo);
                        }

                        // Verify updateToDoProc exists
                        if(updateToDoProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ToDoManager.UpdateToDo(updateToDoProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
