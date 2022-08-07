using System.Diagnostics.Contracts;
using LanguageExt;
using LanguageExt.Effects.Traits;
using static LanguageExt.Prelude;

namespace Sample;

public static class Service
{
    [Pure]
    public static Eff<RT, Service> Access<RT, Service>() where RT : struct, Has<Service> =>
        EffMaybe<RT, Service>(rt => rt.Get());

    [Pure]
    public static Eff<RT, T> Access<RT, Service, T>(Func<Service, T> f) where RT : struct, Has<Service> =>
        Access<RT, Service>().Map(f);

    [Pure]
    public static Eff<RT, T> Access<RT, Service, T>(Func<Service, Eff<RT, T>> f) where RT : struct, Has<Service> =>
        Access<RT, Service>().Bind(f);

    [Pure]
    public static Aff<RT, T> Access<RT, Service, T>(Func<Service, Aff<RT, T>> f) where RT : struct, Has<Service>, HasCancel<RT> =>
        Access<RT, Service>().Bind(f);

    [Pure]
    public static Eff<RT, T> AccessAndDispose<RT, Service, T>(Func<Service, Eff<RT, T>> f) where RT : struct, Has<Service> where Service : IDisposable =>
        use(Access<RT, Service>(), f);

    [Pure]
    public static Aff<RT, T> AccessAndDispose<RT, Service, T>(Func<Service, Aff<RT, T>> f) where RT : struct, Has<Service>, HasCancel<RT> where Service : IDisposable =>
        use(Access<RT, Service>(), f);
}
