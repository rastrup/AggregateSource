﻿using System;

namespace AggregateSource
{
    /// <summary>
    /// Mutable class that builds up an <see cref="Aggregate"/>.
    /// </summary>
    public class AggregateBuilder
    {
        private string _identifier;
        private long _expectedVersion;
        private IAggregateRootEntity _root;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateBuilder"/> class.
        /// </summary>
        public AggregateBuilder()
        {
            _identifier = null;
            _expectedVersion = long.MinValue;
            _root = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateBuilder"/> class.
        /// </summary>
        /// <param name="instance">The aggregate instance to copy data from.</param>
        internal AggregateBuilder(Aggregate instance)
        {
            _identifier = instance.Identifier;
            _expectedVersion = instance.ExpectedVersion;
            _root = instance.Root;
        }

        /// <summary>
        /// Gets the aggregate identifier.
        /// </summary>
        /// <value>
        /// The aggregate identifier.
        /// </value>
        public string Identifier
        {
            get { return _identifier; }
        }

        /// <summary>
        /// Gets the aggregate version.
        /// </summary>
        public long ExpectedVersion
        {
            get { return _expectedVersion; }
        }

        /// <summary>
        /// Gets the aggregate root entity.
        /// </summary>
        /// <value>
        /// The aggregate root entity.
        /// </value>
        public IAggregateRootEntity Root
        {
            get { return _root; }
        }

        /// <summary>
        /// Captures the identity of the aggregate.
        /// </summary>
        /// <param name="value">The identifier value.</param>
        /// <returns>An <see cref="AggregateBuilder"/> instance.</returns>
        public AggregateBuilder IdentifiedBy(string value)
        {
            _identifier = value;
            return this;
        }

        /// <summary>
        /// Captures the expected version of the aggregate.
        /// </summary>
        /// <param name="value">The expected version value</param>
        /// <returns>An <see cref="AggregateBuilder"/> instance.</returns>
        public AggregateBuilder ExpectVersion(int value)
        {
            _expectedVersion = value;
            return this;
        }

        /// <summary>
        /// Captures the aggregate root entity of the aggregate.
        /// </summary>
        /// <param name="value">The aggregate root entity value.</param>
        /// <returns>An <see cref="AggregateBuilder"/> instance.</returns>
        public AggregateBuilder WithRoot(IAggregateRootEntity value)
        {
            _root = value;
            return this;
        }

        /// <summary>
        /// Builds the immutable <see cref="Aggregate"/> based on captured information.
        /// </summary>
        /// <returns>An <see cref="Aggregate"/>.</returns>
        public Aggregate Build()
        {
            return new Aggregate(Identifier, ExpectedVersion, Root);
        }
    }
}