// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Microsoft.EntityFrameworkCore.Metadata
{
    /// <summary>
    ///     Extension methods for <see cref="IRelationalModel" />.
    /// </summary>
    public static class DatabaseModelExtensions
    {
        /// <summary>
        ///     <para>
        ///         Creates a human-readable representation of the given metadata.
        ///     </para>
        ///     <para>
        ///         Warning: Do not rely on the format of the returned string.
        ///         It is designed for debugging only and may change arbitrarily between releases.
        ///     </para>
        /// </summary>
        /// <param name="model"> The metadata item. </param>
        /// <param name="options"> Options for generating the string. </param>
        /// <param name="indent"> The number of indent spaces to use before each new line. </param>
        /// <returns> A human-readable representation. </returns>
        public static string ToDebugString(
            [NotNull] this IRelationalModel model,
            MetadataDebugStringOptions options,
            int indent = 0)
        {
            var builder = new StringBuilder();
            var indentString = new string(' ', indent);

            builder.Append(indentString).Append("DatabaseModel: ");

            foreach (var table in model.Tables)
            {
                builder.AppendLine().Append(table.ToDebugString(options, indent + 2));
            }

            foreach (var view in model.Views)
            {
                builder.AppendLine().Append(view.ToDebugString(options, indent + 2));
            }

            if ((options & MetadataDebugStringOptions.IncludeAnnotations) != 0)
            {
                builder.Append(model.AnnotationsToDebugString(indent));
            }

            return builder.ToString();
        }
    }
}
