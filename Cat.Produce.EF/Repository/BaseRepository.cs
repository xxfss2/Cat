using System.Linq;

namespace Cat.Produce.EF.Repository
{
    using System.Collections;
    using System.Data.Objects.DataClasses;
    using Jiuzh.CoreBase;
    using Jiuzh.CoreBase.Repository;
    using System.Linq.Expressions;

    public abstract class BaseRepository<TInterface, TEntity> : IRepository<TInterface>
        where TInterface : class
        where TEntity : EntityObject, TInterface
    {
        private readonly IDatabase _database;

        public BaseRepository(IDatabase database)
        {
            Check.Argument.IsNotNull(database, "database");
            _database = database;
        }

        protected BaseRepository(IDatabaseFactory factory)
            : this(factory.Create())
        {

        }

        public IDatabase Database
        {
            get
            {
                return _database as IDatabase;
            }
        }

        protected Database DataContext
        {
            get
            {
                return _database as Database;
            }
        }

        public virtual void Add(TInterface entity)
        {
            Check.Argument.IsNotNull(entity, "entity");
            Database.InsertOnSubmit(entity as TEntity);
        }

        public virtual void Remove(TInterface entity)
        {
            Check.Argument.IsNotNull(entity, "entity");

            Database.DeleteOnSubmit(entity as TEntity);
        }
        public virtual void Update()
        {
            Database.SubmitChanges();
        }

        protected static PageResult<T> BuildPageResult<T>(IEnumerable entities, int total)
        {
            return new PageResult<T>(entities.Cast<T>(), total);
        }

        protected void PageBreakAndSort<T, ST>(ref IQueryable<T> queryable, Expression<System.Func<T, ST>> sortExpression, PageBreakParam pagebreak, SortParam sort) where T : class
        {
            //分页及排序
            if (pagebreak != null)
                pagebreak.DataCount = queryable.Count();
            if (sort != null)
            {
                if (sort.SortRule == SortRules.ESC)
                    queryable = queryable.OrderBy(sort.SortCode);
                else
                    queryable = queryable.OrderByDescending(sort.SortCode);
            }
            if (pagebreak != null && sort == null)
                queryable = queryable.OrderBy(sortExpression);
            if (pagebreak != null)
                queryable = queryable.Skip(pagebreak.PageIndex * pagebreak.PageSize).Take(pagebreak.PageSize);
        }

    }
}
