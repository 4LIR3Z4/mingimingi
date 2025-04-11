namespace LanguageLearning.Core.Domain.Framework;
public abstract class BaseEntity<TId>
{
    protected BaseEntity(TId id)
    {
        Id = id;
    }
    protected BaseEntity()
    {
        Id = default(TId)!;
    }
    public virtual TId Id { get; private set; }
    public byte[] RowVersion { get; private  set; } = [];


    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj is not BaseEntity<TId> other)
            return false;

        if (Id is null || other.Id is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetNotproxiedType(this) != GetNotproxiedType(other))
            return false;

        if (Id.Equals(default) || other.Id.Equals(default))
            return false;

        return Id.Equals(other.Id);
    }

    public static bool operator ==(BaseEntity<TId> a, BaseEntity<TId> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(BaseEntity<TId> a, BaseEntity<TId> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetNotproxiedType(this).ToString() + Id).GetHashCode();
    }

    internal static Type GetNotproxiedType(object obj)
    {
        const string EFCoreProxyPrefix = "Castle.Proxies.";

        Type type = obj.GetType();
        string typeString = type.ToString();

        if (typeString.Contains(EFCoreProxyPrefix))
            return type.BaseType ?? type;

        return type;
    }
}
