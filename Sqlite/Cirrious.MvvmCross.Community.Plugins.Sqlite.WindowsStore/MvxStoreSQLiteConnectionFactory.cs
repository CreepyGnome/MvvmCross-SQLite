// MvxStoreSQLiteConnectionFactory.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System.IO;
using Community.SQLite;


namespace Cirrious.MvvmCross.Community.Plugins.Sqlite.WindowsStore
{
    public class MvxStoreSQLiteConnectionFactory
        : ISQLiteConnectionFactory
        , ISQLiteConnectionFactoryEx
    {
        public ISQLiteConnection Create(string address)
        {
            return CreateEx(address);
        }

        public ISQLiteConnection CreateEx(string address, SQLiteConnectionOptions options = null)
        {
            options = options ?? new SQLiteConnectionOptions();
            var path = options.BasePath ?? Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var filePath = Path.Combine(path, address);
            return new SQLiteConnection(filePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, options.StoreDateTimeAsTicks);
        }

        public ISQLiteConnection CreateEx(string databasePath, bool storeDateTimeAsTicks)
        {
            return new SQLiteConnection(databasePath, storeDateTimeAsTicks);
        }

        public ISQLiteConnection CreateEx(string databasePath, int openFlags, bool storeDateTimeAsTicks = true)
        {
            return new SQLiteConnection(databasePath, (SQLiteOpenFlags)openFlags, storeDateTimeAsTicks);
        }
    }
}