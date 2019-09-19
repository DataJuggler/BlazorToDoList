

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum ListChangeTypeEnum : int
    /// <summary>
    /// This enum contains choices that describe what type of a change occurred.
    /// </summary>
    public enum ListChangeTypeEnum : int
    {
        ItemRemoved = -1,
        Unknown = 0,
        ItemAdded = 1,
        ItemChanged = 2
    }
    #endregion

}
