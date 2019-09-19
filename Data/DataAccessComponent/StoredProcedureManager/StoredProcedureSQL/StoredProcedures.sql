Use [BlazorList]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: ToDo_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/18/2019
-- Description:    Insert a new ToDo
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ToDo_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ToDo_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ToDo_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ToDo_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ToDo_Insert >>>'

    End

GO

Create PROCEDURE ToDo_Insert

    -- Add the parameters for the stored procedure here
    @IsDone bit,
    @Title nvarchar(255)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [ToDo]
    ([IsDone],[Title])

    -- Begin Values List
    Values(@IsDone, @Title)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: ToDo_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/18/2019
-- Description:    Update an existing ToDo
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ToDo_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ToDo_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ToDo_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ToDo_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ToDo_Update >>>'

    End

GO

Create PROCEDURE ToDo_Update

    -- Add the parameters for the stored procedure here
    @Id int,
    @IsDone bit,
    @Title nvarchar(255)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [ToDo]

    -- Update Each field
    Set [IsDone] = @IsDone,
    [Title] = @Title

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: ToDo_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/18/2019
-- Description:    Find an existing ToDo
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ToDo_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ToDo_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ToDo_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ToDo_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ToDo_Find >>>'

    End

GO

Create PROCEDURE ToDo_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[IsDone],[Title]

    -- From tableName
    From [ToDo]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: ToDo_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/18/2019
-- Description:    Delete an existing ToDo
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ToDo_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ToDo_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ToDo_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ToDo_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ToDo_Delete >>>'

    End

GO

Create PROCEDURE ToDo_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [ToDo]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: ToDo_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/18/2019
-- Description:    Returns all ToDo objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ToDo_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ToDo_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ToDo_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ToDo_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ToDo_FetchAll >>>'

    End

GO

Create PROCEDURE ToDo_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[IsDone],[Title]

    -- From tableName
    From [ToDo]

END

-- Thank you for using DataTier.Net.

