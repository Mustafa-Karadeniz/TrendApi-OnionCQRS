using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TrendApi.Domain.Common;

namespace TrendApi.Application.Interface.Repositories;

public interface IReadRepository<T> where T : class, IEntityBase , new()
{
    //GetAllAsync(x=>x.include(x.Brand).theninclude()) şeklinde çalışan bir yapı sağladı. Dha çok Generic olarak çalışan bir yapıdır.
    /* **`Task<T>`**: Bu, asenkron bir işlemi temsil eder. Metodun döneceği veri tipi `T` olacaktır.
       **`GetAllAsync`**: Bu, metodun ismidir. Verileri asenkron bir şekilde almak için kullanılır.
       **`Expression<Func<T, bool>> predicate = null`**: Bu, isteğe bağlı bir koşul belirlemenize olanak tanır. `T` tipi bir nesne alır ve bir `bool` döner. Bu koşul, sadece belirtilen şartları karşılayan verilerin getirilmesini sağlar. Eğer `null` olarak bırakılırsa, tüm veriler getirilir.
       **`Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null`**: Bu parametre, ilişkili verileri yüklemek için kullanılır. `IQueryable<T>` tipinde bir sorgu alır ve bunu `IIncludableQueryable<T, object>` tipinde bir sorguya dönüştürür. İlişkili verilerin (örneğin, bir varlık ile ilişkili diğer varlıklar) yüklenmesini sağlar. `null` olarak bırakılırsa, ilişkili veriler yüklenmez.
       **`Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null`**: Bu parametre, sonuçları sıralamak için kullanılır. `IQueryable<T>` tipinde bir sorgu alır ve `IOrderedQueryable<T>` tipinde sıralı bir sorgu döner. Bu, verilerin sıralı olarak getirilmesini sağlar. Eğer `null` olarak bırakılırsa, varsayılan sıralama kullanılmaz ve veriler sırasız getirilir.
       **`bool enableTracking = false`**: Bu parametre, verilerin EF Core tarafından izlenip izlenmeyeceğini belirler. `enableTracking` `true` ise, EF Core verileri izler ve değişiklikler takip edilir. `false` ise, veriler izlenmez ve bu durum performansı artırabilir, özellikle sadece okuma amaçlı veri çekiyorsanız. Genellikle veri sadece okunuyorsa `false` olarak ayarlanır
       **'int currentPage = 1: Bu parametre, getirilecek sayfanın numarasını belirtir. Sayfalama (paging) yapmak için kullanılır. İlk sayfa varsayılan olarak 1'dir.
       **'int pageSize = 3: Bu, bir sayfada gösterilecek öğe sayısını belirtir. Varsayılan olarak 3 öğe getirilir.*/
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);

    Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false, int currentPage = 1, int pageSize = 3);

    Task<T> GetAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = false);

    IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
}
