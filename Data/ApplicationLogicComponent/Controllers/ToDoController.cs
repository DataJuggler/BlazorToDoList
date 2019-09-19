

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class ToDoController
    /// <summary>
    /// This class controls a(n) 'ToDo' object.
    /// </summary>
    public class ToDoController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ToDoController' object.
        /// </summary>
        public ToDoController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateToDoParameter
            /// <summary>
            /// This method creates the parameter for a 'ToDo' data operation.
            /// </summary>
            /// <param name='todo'>The 'ToDo' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateToDoParameter(ToDo toDo)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = toDo;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ToDo tempToDo)
            /// <summary>
            /// Deletes a 'ToDo' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'ToDo_Delete'.
            /// </summary>
            /// <param name='todo'>The 'ToDo' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(ToDo tempToDo)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteToDo";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify temptoDo exists before attemptintg to delete
                    if(tempToDo != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteToDoMethod = this.AppController.DataBridge.DataOperations.ToDoMethods.DeleteToDo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateToDoParameter(tempToDo);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteToDoMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(ToDo tempToDo)
            /// <summary>
            /// This method fetches a collection of 'ToDo' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ToDo_FetchAll'.</summary>
            /// <param name='tempToDo'>A temporary ToDo for passing values.</param>
            /// <returns>A collection of 'ToDo' objects.</returns>
            public List<ToDo> FetchAll(ToDo tempToDo)
            {
                // Initial value
                List<ToDo> toDoList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ToDoMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateToDoParameter(tempToDo);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ToDo> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        toDoList = (List<ToDo>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return toDoList;
            }
            #endregion

            #region Find(ToDo tempToDo)
            /// <summary>
            /// Finds a 'ToDo' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ToDo_Find'</param>
            /// </summary>
            /// <param name='tempToDo'>A temporary ToDo for passing values.</param>
            /// <returns>A 'ToDo' object if found else a null 'ToDo'.</returns>
            public ToDo Find(ToDo tempToDo)
            {
                // Initial values
                ToDo toDo = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempToDo != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ToDoMethods.FindToDo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateToDoParameter(tempToDo);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ToDo != null))
                        {
                            // Get ReturnObject
                            toDo = (ToDo) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return toDo;
            }
            #endregion

            #region Insert(ToDo toDo)
            /// <summary>
            /// Insert a 'ToDo' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ToDo_Insert'.</param>
            /// </summary>
            /// <param name='toDo'>The 'ToDo' object to insert.</param>
            /// <returns>The id (int) of the new  'ToDo' object that was inserted.</returns>
            public int Insert(ToDo toDo)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ToDoexists
                    if(toDo != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ToDoMethods.InsertToDo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateToDoParameter(toDo);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref ToDo toDo)
            /// <summary>
            /// Saves a 'ToDo' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='toDo'>The 'ToDo' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref ToDo toDo)
            {
                // Initial value
                bool saved = false;

                // If the toDo exists.
                if(toDo != null)
                {
                    // Is this a new ToDo
                    if(toDo.IsNew)
                    {
                        // Insert new ToDo
                        int newIdentity = this.Insert(toDo);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            toDo.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ToDo
                        saved = this.Update(toDo);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ToDo toDo)
            /// <summary>
            /// This method Updates a 'ToDo' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ToDo_Update'.</param>
            /// </summary>
            /// <param name='toDo'>The 'ToDo' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(ToDo toDo)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(toDo != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ToDoMethods.UpdateToDo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateToDoParameter(toDo);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
