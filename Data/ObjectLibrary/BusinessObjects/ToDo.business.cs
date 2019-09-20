

#region using statements

using System;
using DataJuggler.Net.Core.Delegates;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class ToDo
    [Serializable]
    public partial class ToDo
    {

        #region Private Variables
        private ItemChangedCallback callback;
        #endregion

        #region Constructor
        public ToDo()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ToDo Clone()
            {
                // Create New Object
                ToDo newToDo = (ToDo) this.MemberwiseClone();

                // Return Cloned Object
                return newToDo;
            }
            #endregion

        #endregion

        #region Properties

            #region Callback
            /// <summary>
            /// This property gets or sets the value for 'Callback'.
            /// </summary>
            public ItemChangedCallback Callback
            {
                get { return callback; }
                set { callback = value; }
            }
            #endregion
            
            #region HasCallback
            /// <summary>
            /// This property returns true if this object has a 'Callback'.
            /// </summary>
            public bool HasCallback
            {
                get
                {
                    // initial value
                    bool hasCallback = (this.Callback != null);
                    
                    // return value
                    return hasCallback;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
