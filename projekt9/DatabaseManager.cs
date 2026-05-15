using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace projekt9;

public sealed class DatabaseManager
{
    private readonly string _connectionString;

    public DatabaseManager(string dbFilePath)
    {
        if (string.IsNullOrWhiteSpace(dbFilePath))
            throw new ArgumentException("DB path cannot be empty.", nameof(dbFilePath));

        var directory = Path.GetDirectoryName(dbFilePath);
        if (!string.IsNullOrWhiteSpace(directory))
            Directory.CreateDirectory(directory);

        _connectionString = $"Data Source={dbFilePath};Version=3;";
    }

    public void Initialize()
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
CREATE TABLE IF NOT EXISTS FormEntries (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CreatedAt TEXT NOT NULL,
    Field1 TEXT,
    Field2 TEXT,
    Field3 TEXT,
    Field4 TEXT,
    Field5 TEXT,
    Field6 TEXT,
    Field7 TEXT,
    Field8 TEXT,
    Field9 TEXT,
    Field10 TEXT,
    Field11 TEXT,
    Field12 TEXT,
    Field13 TEXT,
    Field14 TEXT,
    Field15 TEXT
);";
        command.ExecuteNonQuery();
    }

    public long InsertEntry(IReadOnlyList<string?> fields)
    {
        if (fields is null)
            throw new ArgumentNullException(nameof(fields));
        if (fields.Count != 15)
            throw new ArgumentException("Expected exactly 15 fields.", nameof(fields));

        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
INSERT INTO FormEntries (
    CreatedAt,
    Field1, Field2, Field3, Field4, Field5,
    Field6, Field7, Field8, Field9, Field10,
    Field11, Field12, Field13, Field14, Field15
) VALUES (
    @CreatedAt,
    @Field1, @Field2, @Field3, @Field4, @Field5,
    @Field6, @Field7, @Field8, @Field9, @Field10,
    @Field11, @Field12, @Field13, @Field14, @Field15
);
SELECT last_insert_rowid();";

        command.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
        for (var i = 0; i < 15; i++)
            command.Parameters.AddWithValue($"@Field{i + 1}", fields[i] ?? string.Empty);

        var result = command.ExecuteScalar();
        return Convert.ToInt64(result, CultureInfo.InvariantCulture);
    }

    public List<EntrySummary> GetEntrySummaries()
    {
        var list = new List<EntrySummary>();

        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, CreatedAt FROM FormEntries ORDER BY Id DESC";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var id = reader.GetInt64(0);
            var createdAtRaw = reader.GetString(1);

            DateTime createdAt;
            if (!DateTime.TryParse(createdAtRaw, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out createdAt))
                createdAt = DateTime.MinValue;

            list.Add(new EntrySummary(id, createdAt));
        }

        return list;
    }

    public string?[]? GetEntryFieldsById(long id)
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
SELECT
    Field1, Field2, Field3, Field4, Field5,
    Field6, Field7, Field8, Field9, Field10,
    Field11, Field12, Field13, Field14, Field15
FROM FormEntries
WHERE Id = @Id
LIMIT 1;";
        command.Parameters.AddWithValue("@Id", id);

        using var reader = command.ExecuteReader();
        if (!reader.Read())
            return null;

        var fields = new string?[15];
        for (var i = 0; i < 15; i++)
        {
            fields[i] = reader.IsDBNull(i) ? string.Empty : reader.GetString(i);
        }

        return fields;
    }

    public bool DeleteEntryById(long id)
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM FormEntries WHERE Id = @Id";
        command.Parameters.AddWithValue("@Id", id);

        var rows = command.ExecuteNonQuery();
        return rows > 0;
    }
}

public sealed record EntrySummary(long Id, DateTime CreatedAt)
{
    public string Display
    {
        get
        {
            if (CreatedAt == DateTime.MinValue)
                return $"{Id}";

            var local = CreatedAt.Kind == DateTimeKind.Utc ? CreatedAt.ToLocalTime() : CreatedAt;
            return $"{Id} | {local:yyyy-MM-dd HH:mm:ss}";
        }
    }
}
