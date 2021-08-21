﻿using System.Collections.Generic;
using System.IO;
using LinFu.Loaders.Interfaces;

namespace LinFu.Loaders
{
    /// <summary>
    ///     A class that lists the contents of a given directory.
    /// </summary>
    internal class DefaultDirectoryLister : IDirectoryListing
    {
        /// <summary>
        ///     Returns a list of files that match the <paramref name="searchPattern" />
        ///     from the given directory <paramref name="path" />.
        /// </summary>
        /// <param name="path">The target directory to search.</param>
        /// <param name="searchPattern">The search string to match against the names of the files in the <paramref name="path" />.</param>
        /// <returns>The list of files that match the <paramref name="path" /> and <paramref name="searchPattern" /></returns>
        public IEnumerable<string> GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern);
        }
    }
}