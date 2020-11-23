CREATE SERVICE [local://Message/Service]
    AUTHORIZATION [dbo]
    ON QUEUE [dbo].[MessageQueue]
    ([DEFAULT]);

