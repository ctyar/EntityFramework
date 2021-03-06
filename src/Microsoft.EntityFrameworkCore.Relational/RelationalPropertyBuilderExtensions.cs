// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Utilities;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    public static class RelationalPropertyBuilderExtensions
    {
        public static PropertyBuilder HasColumnName(
            [NotNull] this PropertyBuilder propertyBuilder,
            [CanBeNull] string name)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));
            Check.NullButNotEmpty(name, nameof(name));

            propertyBuilder.GetInfrastructure<InternalPropertyBuilder>().Relational(ConfigurationSource.Explicit).HasColumnName(name);

            return propertyBuilder;
        }

        public static PropertyBuilder<TProperty> HasColumnName<TProperty>(
            [NotNull] this PropertyBuilder<TProperty> propertyBuilder,
            [CanBeNull] string name)
            => (PropertyBuilder<TProperty>)HasColumnName((PropertyBuilder)propertyBuilder, name);

        public static PropertyBuilder HasColumnType(
            [NotNull] this PropertyBuilder propertyBuilder,
            [CanBeNull] string typeName)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));
            Check.NullButNotEmpty(typeName, nameof(typeName));

            propertyBuilder.GetInfrastructure<InternalPropertyBuilder>().Relational(ConfigurationSource.Explicit).HasColumnType(typeName);

            return propertyBuilder;
        }

        public static PropertyBuilder<TProperty> HasColumnType<TProperty>(
            [NotNull] this PropertyBuilder<TProperty> propertyBuilder,
            [CanBeNull] string typeName)
            => (PropertyBuilder<TProperty>)HasColumnType((PropertyBuilder)propertyBuilder, typeName);

        public static PropertyBuilder HasDefaultValueSql(
            [NotNull] this PropertyBuilder propertyBuilder,
            [CanBeNull] string sql)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));
            Check.NullButNotEmpty(sql, nameof(sql));

            var property = (Property)propertyBuilder.Metadata;
            if (ConfigurationSource.Convention.Overrides(property.GetValueGeneratedConfigurationSource()))
            {
                property.SetValueGenerated(ValueGenerated.OnAdd, ConfigurationSource.Convention);
            }

            propertyBuilder.GetInfrastructure<InternalPropertyBuilder>().Relational(ConfigurationSource.Explicit).HasDefaultValueSql(sql);

            return propertyBuilder;
        }

        public static PropertyBuilder<TProperty> HasDefaultValueSql<TProperty>(
            [NotNull] this PropertyBuilder<TProperty> propertyBuilder,
            [CanBeNull] string sql)
            => (PropertyBuilder<TProperty>)HasDefaultValueSql((PropertyBuilder)propertyBuilder, sql);

        public static PropertyBuilder HasComputedColumnSql(
            [NotNull] this PropertyBuilder propertyBuilder,
            [CanBeNull] string sql)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));
            Check.NullButNotEmpty(sql, nameof(sql));

            var property = (Property)propertyBuilder.Metadata;
            if (ConfigurationSource.Convention.Overrides(property.GetValueGeneratedConfigurationSource()))
            {
                property.SetValueGenerated(ValueGenerated.OnAddOrUpdate, ConfigurationSource.Convention);
            }

            propertyBuilder.GetInfrastructure<InternalPropertyBuilder>().Relational(ConfigurationSource.Explicit).HasComputedValueSql(sql);

            return propertyBuilder;
        }

        public static PropertyBuilder<TProperty> HasComputedColumnSql<TProperty>(
            [NotNull] this PropertyBuilder<TProperty> propertyBuilder,
            [CanBeNull] string sql)
            => (PropertyBuilder<TProperty>)HasComputedColumnSql((PropertyBuilder)propertyBuilder, sql);

        public static PropertyBuilder HasDefaultValue(
            [NotNull] this PropertyBuilder propertyBuilder,
            [CanBeNull] object value)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));

            var property = (Property)propertyBuilder.Metadata;
            if (ConfigurationSource.Convention.Overrides(property.GetValueGeneratedConfigurationSource()))
            {
                property.SetValueGenerated(ValueGenerated.OnAdd, ConfigurationSource.Convention);
            }

            propertyBuilder.GetInfrastructure<InternalPropertyBuilder>().Relational(ConfigurationSource.Explicit).HasDefaultValue(value);

            return propertyBuilder;
        }

        public static PropertyBuilder<TProperty> HasDefaultValue<TProperty>(
            [NotNull] this PropertyBuilder<TProperty> propertyBuilder,
            [CanBeNull] object value)
            => (PropertyBuilder<TProperty>)HasDefaultValue((PropertyBuilder)propertyBuilder, value);
    }
}
