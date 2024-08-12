using System.Linq.Expressions;

namespace WordCraft.Data.Utilities.Mapper
{
    public class ModelPropertyMapper<T>
    {
        public static Expression<Func<T, object>> MapStringToProperty(string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "model");

            MemberExpression property = Expression.Property(parameter, propertyName);

            UnaryExpression convert = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(convert, parameter);
        }
    }
}
