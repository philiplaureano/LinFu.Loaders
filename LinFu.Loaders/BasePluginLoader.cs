using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LinFu.Loaders.Interfaces;

namespace LinFu.Loaders
{
    /// <summary>
    ///     Implements the basic functionality of a plugin loader.
    /// </summary>
    /// <typeparam name="TTarget">The target type being configured.</typeparam>
    /// <typeparam name="TAttribute">The attribute type that will be used to mark a type as a plugin.</typeparam>
    public abstract class BasePluginLoader<TTarget, TAttribute> : IActionLoader<ILoader<TTarget>, Type>
        where TAttribute : Attribute
    {
        /// <summary>
        ///     Determines if the plugin loader can load the <paramref name="inputType" />.
        /// </summary>
        /// <param name="inputType">The target type that might contain the target <typeparamref name="TAttribute" /> instance.</param>
        /// <returns><c>true</c> if the type can be loaded; otherwise, it returns <c>false</c>.</returns>
        public virtual bool CanLoad(Type inputType)
        {
            try
            {
                var attributes = inputType.GetCustomAttributes(typeof(TAttribute), true)
                    .Cast<TAttribute>();

                // The type must have a default constructor
                var defaultConstructor = inputType.GetConstructor(Type.EmptyTypes);
                if (defaultConstructor == null)
                    return false;

                // The target must implement the ILoaderPlugin<TTarget> interface
                // and be marked with the custom attribute
                return attributes.Any();
            }
            catch (TypeInitializationException)
            {
                // Ignore the error
                return false;
            }
            catch (FileNotFoundException)
            {
                // Ignore the error
                return false;
            }
        }

        /// <summary>
        ///     Generates a set of <see cref="Action{TTarget}" /> instances
        ///     using the given <paramref name="input" />.
        /// </summary>
        /// <param name="input">The input that will be used to configure the target.</param>
        /// <returns>A set of <see cref="Action{TTarget}" /> instances. This cannot be <c>null</c>.</returns>
        public abstract IEnumerable<Action<ILoader<TTarget>>> Load(Type input);
    }
}