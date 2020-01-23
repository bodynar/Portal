namespace Portal.Cqrs.Query
{
    public interface IQueryProcessor
    {
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}