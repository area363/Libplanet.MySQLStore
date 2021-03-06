using Libplanet.Store;
using Libplanet.Store.Trie;
using Libplanet.Tests.Store;

namespace Libplanet.MySQLStore.Tests
{
    public class MySQLStoreFixture : StoreFixture
    {
        public MySQLStoreFixture()
        {
            Options = new MySQLStoreOptions(
                "libplanet.mysql-test",
                "127.0.0.1",
                3306,
                "root",
                "root");

            var store = new MySQLStore(Options, blockCacheSize: 2, txCacheSize: 2);
            Store = store;
            StateStore = LoadTrieStateStore(Options);
        }

        public MySQLStoreOptions Options { get; }

        public IStateStore LoadTrieStateStore(MySQLStoreOptions Options)
        {
            IKeyValueStore stateKeyValueStore =
                new MySQLKeyValueStore(Options, "State");
            IKeyValueStore stateHashKeyValueStore =
                new MySQLKeyValueStore(Options, "State_Hash");
            return new TrieStateStore(stateKeyValueStore, stateHashKeyValueStore);
        }

        public override void Dispose()
        {
            // Do NoThing
        }
    }
}
