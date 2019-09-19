

#region using statements

using System;
using ObjectLibrary.Enumerations;
using ObjectLibrary.Delegates;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class ToDo
    public partial class ToDo
    {

        #region Private Variables
        private int id;
        private bool isDone;
        private string title;
        private bool delete;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region bool IsDone
            public bool IsDone
            {
                get
                {
                    return isDone;
                }
                set
                {
                    // local
                    bool hasChanges = (isDone != value);

                    // set the value
                    isDone = value;

                    // if the Callback exists and changes exist
                    if ((HasCallback) && (hasChanges))
                    {
                        // Set the Callback
                        Callback(this, ListChangeTypeEnum.ItemChanged);    
                    }
                }
            }
            #endregion

            #region string Title
            public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    // local
                    bool hasChanges = (Title != value);

                    // set the value
                    title = value;

                    // if the Callback exists
                    if ((HasCallback) && (hasChanges))
                    {
                        // Set the Callback
                        Callback(this, ListChangeTypeEnum.ItemChanged);    
                    }
                }
            }
            #endregion

            #region bool Delete
            public bool Delete
            {
                get
                {
                    return delete;
                }
                set
                {
                    delete = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
