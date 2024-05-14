using System;

namespace FuDever.Application.Shared.Attributes;

/// <summary>
///     Used to set the order of feature middleware.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
internal sealed class FeatureMiddlewareOrderAttribute : Attribute
{
    internal int Value { get; }

    internal FeatureMiddlewareOrderAttribute(int value)
    {
        Value = value;
    }
}
