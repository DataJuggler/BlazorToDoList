

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class ToDoWriterBase
    /// <summary>
    /// This class is used for converting a 'ToDo' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ToDoWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ToDo toDo)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='toDo'>The 'ToDo' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ToDo toDo)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (toDo != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", toDo.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteToDoStoredProcedure(ToDo toDo)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteToDo'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ToDo_Delete'.
            /// </summary>
            /// <param name="toDo">The 'ToDo' to Delete.</param>
            /// <returns>An instance of a 'DeleteToDoStoredProcedure' object.</returns>
            public static DeleteToDoStoredProcedure CreateDeleteToDoStoredProcedure(ToDo toDo)
            {
                // Initial Value
                DeleteToDoStoredProcedure deleteToDoStoredProcedure = new DeleteToDoStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteToDoStoredProcedure.Parameters = CreatePrimaryKeyParameter(toDo);

                // return value
                return deleteToDoStoredProcedure;
            }
            #endregion

            #region CreateFindToDoStoredProcedure(ToDo toDo)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindToDoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ToDo_Find'.
            /// </summary>
            /// <param name="toDo">The 'ToDo' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindToDoStoredProcedure CreateFindToDoStoredProcedure(ToDo toDo)
            {
                // Initial Value
                FindToDoStoredProcedure findToDoStoredProcedure = null;

                // verify toDo exists
                if(toDo != null)
                {
                    // Instanciate findToDoStoredProcedure
                    findToDoStoredProcedure = new FindToDoStoredProcedure();

                    // Now create parameters for this procedure
                    findToDoStoredProcedure.Parameters = CreatePrimaryKeyParameter(toDo);
                }

                // return value
                return findToDoStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ToDo toDo)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new toDo.
            /// </summary>
            /// <param name="toDo">The 'ToDo' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ToDo toDo)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify toDoexists
                if(toDo != null)
                {
                    // Create [IsDone] parameter
                    param = new SqlParameter("@IsDone", toDo.IsDone);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Title] parameter
                    param = new SqlParameter("@Title", toDo.Title);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertToDoStoredProcedure(ToDo toDo)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertToDoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ToDo_Insert'.
            /// </summary>
            /// <param name="toDo"The 'ToDo' object to insert</param>
            /// <returns>An instance of a 'InsertToDoStoredProcedure' object.</returns>
            public static InsertToDoStoredProcedure CreateInsertToDoStoredProcedure(ToDo toDo)
            {
                // Initial Value
                InsertToDoStoredProcedure insertToDoStoredProcedure = null;

                // verify toDo exists
                if(toDo != null)
                {
                    // Instanciate insertToDoStoredProcedure
                    insertToDoStoredProcedure = new InsertToDoStoredProcedure();

                    // Now create parameters for this procedure
                    insertToDoStoredProcedure.Parameters = CreateInsertParameters(toDo);
                }

                // return value
                return insertToDoStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ToDo toDo)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing toDo.
            /// </summary>
            /// <param name="toDo">The 'ToDo' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ToDo toDo)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify toDoexists
                if(toDo != null)
                {
                    // Create parameter for [IsDone]
                    param = new SqlParameter("@IsDone", toDo.IsDone);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Title]
                    param = new SqlParameter("@Title", toDo.Title);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", toDo.Id);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateToDoStoredProcedure(ToDo toDo)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateToDoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ToDo_Update'.
            /// </summary>
            /// <param name="toDo"The 'ToDo' object to update</param>
            /// <returns>An instance of a 'UpdateToDoStoredProcedure</returns>
            public static UpdateToDoStoredProcedure CreateUpdateToDoStoredProcedure(ToDo toDo)
            {
                // Initial Value
                UpdateToDoStoredProcedure updateToDoStoredProcedure = null;

                // verify toDo exists
                if(toDo != null)
                {
                    // Instanciate updateToDoStoredProcedure
                    updateToDoStoredProcedure = new UpdateToDoStoredProcedure();

                    // Now create parameters for this procedure
                    updateToDoStoredProcedure.Parameters = CreateUpdateParameters(toDo);
                }

                // return value
                return updateToDoStoredProcedure;
            }
            #endregion

            #region CreateFetchAllToDosStoredProcedure(ToDo toDo)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllToDosStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ToDo_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllToDosStoredProcedure' object.</returns>
            public static FetchAllToDosStoredProcedure CreateFetchAllToDosStoredProcedure(ToDo toDo)
            {
                // Initial value
                FetchAllToDosStoredProcedure fetchAllToDosStoredProcedure = new FetchAllToDosStoredProcedure();

                // return value
                return fetchAllToDosStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
