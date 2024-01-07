﻿using System;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO;

/// <summary>
/// Delegate declaration for Pipeline Exceptions
/// </summary>
/// <param name="sender">object that caused the exception</param>
/// <param name="exception">exception received by noted object</param>
/// <returns>continuation option</returns>
public delegate Task<ErrorHandling> OnException(object sender, Exception exception);
