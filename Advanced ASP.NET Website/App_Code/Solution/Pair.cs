using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

[Serializable]
public class Pair<TFirst, TSecond> : IEquatable<Pair<TFirst, TSecond>>, IEqualityComparer<Pair<TFirst, TSecond>>
{
    public TFirst First;
    public TSecond Second;

    public Pair()
    {
    }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }
    public override int GetHashCode()
    {
        return (First.GetHashCode() + "|" + Second.GetHashCode()).GetHashCode();
    }
    #region IEqualityComparer<Pair<TFirst,TSecond>> Members

    bool IEqualityComparer<Pair<TFirst, TSecond>>.Equals(Pair<TFirst, TSecond> x, Pair<TFirst, TSecond> y)
    {
        return x.GetHashCode() == y.GetHashCode();
    }

    int IEqualityComparer<Pair<TFirst, TSecond>>.GetHashCode(Pair<TFirst, TSecond> obj)
    {
        return obj.GetHashCode();
    }

    #endregion

    #region IEquatable<Pair<TFirst,TSecond>> Members

    bool IEquatable<Pair<TFirst, TSecond>>.Equals(Pair<TFirst, TSecond> other)
    {
        return GetHashCode() == other.GetHashCode();
    }

    #endregion
}