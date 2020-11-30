namespace BinaryDataDecoders.IO
{
    public enum ErrorHandling
    {
        /// <summary>
        /// Ignore exception and continue processing
        /// </summary>
        Ignore,
        /// <summary>
        /// Mark as complete with exception
        /// </summary>
        Throw,
        /// <summary>
        /// Mask as complete and ignore exception
        /// </summary>
        Stop
    }
}
