namespace Serilog.LevelSwitcher
{
    /// <summary>
    /// Implement this interface to use different key/value store
    /// </summary>
    public interface IKeyValueStore
    {
        /// <summary>
        /// Read a key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// Write a key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set(string key, string value);

    }
}
