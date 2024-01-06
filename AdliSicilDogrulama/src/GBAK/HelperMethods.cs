//GBAKFramework 3.0.0
using System;
using System.Linq;
namespace GBAK.Engine
{
    public delegate bool ActionWithResultBoolean<in T>(T obj);
    public static class HelperMethods
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(
        this Type type,
        Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(
                typeof(TAttribute), true
            ).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, long>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, byte[]>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, bool>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, char>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, DateTime>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, decimal>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, double>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, int>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, string>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, Single>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, short>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, byte>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, Guid>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, long?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, bool?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, char?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, DateTime?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, decimal?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, double?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, int?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, Single?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, short?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, byte?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static string GetVariableName(this System.Linq.Expressions.Expression<Func<string, Guid?>> f)
        {
            return ((f.Body as System.Linq.Expressions.MemberExpression).Member.Name);
        }
        public static bool isGuid(string value)
        {
            Guid dx;
            if (!Guid.TryParse(value, out dx))
                return false;
            return true;
        }
        public static Guid ToGuid(object value)
        {
            return new Guid(Convert.ToString(value));
        }
        public static Guid Generate()
        {
            var buffer = Guid.NewGuid().ToByteArray();

            var time = new DateTime(0x76c, 1, 1);
            var now = DateTime.Now;
            var span = new TimeSpan(now.Ticks - time.Ticks);
            var timeOfDay = now.TimeOfDay;

            var bytes = BitConverter.GetBytes(span.Days);
            var array = BitConverter.GetBytes(
                (long)(timeOfDay.TotalMilliseconds / 3.333333));

            Array.Reverse(bytes);
            Array.Reverse(array);
            Array.Copy(bytes, bytes.Length - 2, buffer, buffer.Length - 6, 2);
            Array.Copy(array, array.Length - 4, buffer, buffer.Length - 4, 4);


            return new Guid(buffer);
        }
    }
}
