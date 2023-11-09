using System;

using Pacco.Services.Customers.Core.Exceptions;

namespace Pacco.Services.Customers.Core.Entities;

public class AggregateId : IEquatable<AggregateId>
{
    public Guid Value { get; }

    public AggregateId()
    {
        Value = Guid.NewGuid();
    }

    public AggregateId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidAggregateIdException();
        }

        Value = value;
    }

    public bool Equals(AggregateId other)
    {
        if (other is null) return false;
        return ReferenceEquals(this, other) || Value.Equals(other.Value);
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((AggregateId)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static implicit operator Guid(AggregateId id)
        => id.Value;

    public static implicit operator AggregateId(Guid id) => new(id);

    public override string ToString() => Value.ToString();
}
