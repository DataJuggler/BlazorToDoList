using System;
using System.Collections.Generic;
using System.Text;
using ObjectLibrary.Enumerations;

namespace ObjectLibrary.Delegates
{

    #region ListChangedCallback(object itemChanged, ListChangeTypeEnum listChangeType);
    /// <summary>
    /// This delegate is used to notify an item that a list has changed
    /// </summary>
    /// <param name="itemChanged"></param>
    /// <param name="listChangeType"></param>
    public delegate void ListChangedCallback(object itemChanged, ListChangeTypeEnum listChangeType);
    #endregion

}
