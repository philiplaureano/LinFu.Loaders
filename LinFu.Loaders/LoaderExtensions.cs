using LinFu.Loaders.Interfaces;

namespace LinFu.Loaders
{
    public static class LoaderExtensions
    {
        /// <summary>
        /// Builds a new object using the state loaded into the current loader.
        /// </summary>
        /// <param name="loader">The loader that will be used to configure the new target object.</param>
        /// <typeparam name="TTarget">The target type of the target object.</typeparam>
        /// <returns>A configured instance of the target type.</returns>
        public static TTarget Build<TTarget>(this ILoader<TTarget> loader)
            where TTarget : new()
        {
            var target = new TTarget();
            loader.LoadInto(target);

            return target;
        }
    }
}