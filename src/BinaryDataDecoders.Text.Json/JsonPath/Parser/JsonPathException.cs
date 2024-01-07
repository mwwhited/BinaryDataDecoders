using System;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser;

public class JsonPathException(string message) : Exception(message)
{
}