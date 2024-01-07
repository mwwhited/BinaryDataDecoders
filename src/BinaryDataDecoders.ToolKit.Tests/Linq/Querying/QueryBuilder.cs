using System;
using System.Linq.Expressions;

namespace BinaryDataDecoders.ToolKit.Tests.Linq.Search;

public class QueryBuilder
{
    /*
operations:
    EqualTo ; eq ; =
    NotEqualTo ; neq ; ne ; != ; <>
    WithIn ; in
    NotWithIn ; nin
    Contains ; has
    NotContains ; nhas
    LessThan ; lt ; <
    LessThanOrEqualTo ; lte ; <=
    GreaterThan ; gt ; >
    GreaterThanEqualTo ; gte ; >=
    Filter
    Not ; !
    And ; &
    Or ; |
    IsNull 
    NotIsNull
     */

    /*{
    "Term" : "}
     */
    public Expression Builder(Expression parameter, string operationKey, Expression value)
    {
        throw new NotImplementedException();
    }
}

public interface IFilterOperationBuilder
{
    string[] OperationKeys { get; }
    Expression Build(Expression parameter, Expression value);
}


