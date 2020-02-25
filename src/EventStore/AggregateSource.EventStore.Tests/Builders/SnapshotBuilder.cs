using AggregateSource.EventStore.Snapshots;

namespace AggregateSource.EventStore.Builders
{
    public class SnapshotBuilder
    {
        readonly object _state;
        readonly long _version;

        public static readonly SnapshotBuilder Default = new SnapshotBuilder();

        SnapshotBuilder() : this(0, new object()) {}

        SnapshotBuilder(long version, object state)
        {
            _state = state;
            _version = version;
        }

        public object State
        {
            get { return _state; }
        }

        public long Version
        {
            get { return _version; }
        }

        public SnapshotBuilder WithState(object value)
        {
            return new SnapshotBuilder(_version, value);
        }

        public SnapshotBuilder WithVersion(long value)
        {
            return new SnapshotBuilder(value, _state);
        }

        public Snapshot Build()
        {
            return new Snapshot(_version, _state);
        }

        public static implicit operator Snapshot(SnapshotBuilder builder)
        {
            return builder.Build();
        }
    }
}