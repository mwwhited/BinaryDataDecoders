using System;
using System.IO;
using System.Reflection;

namespace BinaryDataDecoders.ToolKit.Reflection
{
    // http://blog.codinghorror.com/determining-build-date-the-hard-way/
    // http://stackoverflow.com/questions/2050396/getting-the-date-of-a-net-assembly
    public  class ApplicationInformation
    {
        /// <summary>
        /// Gets the executing assembly.
        /// </summary>
        /// <value>The executing assembly.</value>
        public  Assembly ExecutingAssembly
        {
            get { return executingAssembly ?? (executingAssembly = Assembly.GetExecutingAssembly()); }
        }
        private  Assembly executingAssembly;

        /// <summary>
        /// Gets the executing assembly version.
        /// </summary>
        /// <value>The executing assembly version.</value>
        public  Version ExecutingAssemblyVersion
        {
            get { return executingAssemblyVersion ?? (executingAssemblyVersion = ExecutingAssembly.GetName().Version); }
        }
        private  Version executingAssemblyVersion;

        /// <summary>
        /// Gets the compile date of the currently executing assembly.
        /// </summary>
        /// <value>The compile date.</value>
        public  DateTime CompileDate
        {
            get { return (compileDate ?? (compileDate = RetrieveLinkerTimestamp(ExecutingAssembly.Location))).Value; }
        }
        private  DateTime? compileDate;

        /// <summary>
        /// Retrieves the linker timestamp.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// <remarks>http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html</remarks>
        private  DateTime RetrieveLinkerTimestamp(string filePath)
        {
            const int peHeaderOffset = 60;
            const int linkerTimestampOffset = 8;
            var b = new byte[2048];
            using (var s = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                s.Read(b, 0, 2048);
            }
            var dt = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(BitConverter.ToInt32(b, BitConverter.ToInt32(b, peHeaderOffset) + linkerTimestampOffset));
            return dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
        }
    }
}
