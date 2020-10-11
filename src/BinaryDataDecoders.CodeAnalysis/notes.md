# Code Analysis Tools

## Summary

Tools to work with Microsoft.CodeAnalysis and add useful functionality

## SyntaxTree XPath Navigator

Expose SyntaxTrees as XPathNavigator to allow working with exsting XML tooling such as XSLT.

### Notes

Currently only CSharp is supported.  This should also be refactored to to have a better vistor style pattern.
The existing node pointer is difficult to abstract and extend.

