using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace laby9
{
    internal sealed class WniosekRecord
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }

        // 15 pól z formularza
        public string CityDateTop { get; set; } = "";
        public string AlbumNumber { get; set; } = "";
        public string FullName { get; set; } = "";
        public string SemesterYear { get; set; } = "";
        public string MajorDegree { get; set; } = "";

        public string Subject { get; set; } = "";
        public int Points { get; set; }
        public string ConductedBy { get; set; } = "";

        public string Justification { get; set; } = "";
        public string StudentDateSignature { get; set; } = "";

        public string Decision { get; set; } = "";
        public string Commission1 { get; set; } = "";
        public string Commission2 { get; set; } = "";
        public string Commission3 { get; set; } = "";
        public string BottomDateStampSignature { get; set; } = "";
    }

    internal sealed class WniosekSummary
    {
        public long Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public string FullName { get; init; } = "";
        public string AlbumNumber { get; init; } = "";
    }

    internal sealed class DatabaseManager
    {
        private readonly string _dbPath;
        private readonly string _connectionString;

        public DatabaseManager(string dbPath)
        {
            _dbPath = dbPath;
            _connectionString = $"Data Source={_dbPath};Version=3;";
        }

        public void EnsureCreated()
        {
            var dir = Path.GetDirectoryName(_dbPath);
            if (!string.IsNullOrWhiteSpace(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
CREATE TABLE IF NOT EXISTS Wnioski (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CreatedAt TEXT NOT NULL,

    CityDateTop TEXT,
    AlbumNumber TEXT,
    FullName TEXT,
    SemesterYear TEXT,
    MajorDegree TEXT,

    Subject TEXT,
    Points INTEGER,
    ConductedBy TEXT,

    Justification TEXT,
    StudentDateSignature TEXT,

    Decision TEXT,
    Commission1 TEXT,
    Commission2 TEXT,
    Commission3 TEXT,
    BottomDateStampSignature TEXT
);
";
            cmd.ExecuteNonQuery();
        }

        public long Insert(WniosekRecord record)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
INSERT INTO Wnioski (
    CreatedAt,
    CityDateTop, AlbumNumber, FullName, SemesterYear, MajorDegree,
    Subject, Points, ConductedBy,
    Justification, StudentDateSignature,
    Decision, Commission1, Commission2, Commission3, BottomDateStampSignature
) VALUES (
    @CreatedAt,
    @CityDateTop, @AlbumNumber, @FullName, @SemesterYear, @MajorDegree,
    @Subject, @Points, @ConductedBy,
    @Justification, @StudentDateSignature,
    @Decision, @Commission1, @Commission2, @Commission3, @BottomDateStampSignature
);
SELECT last_insert_rowid();
";

            record.CreatedAt = record.CreatedAt == default ? DateTime.Now : record.CreatedAt;
            cmd.Parameters.AddWithValue("@CreatedAt", record.CreatedAt.ToString("O", CultureInfo.InvariantCulture));

            cmd.Parameters.AddWithValue("@CityDateTop", record.CityDateTop);
            cmd.Parameters.AddWithValue("@AlbumNumber", record.AlbumNumber);
            cmd.Parameters.AddWithValue("@FullName", record.FullName);
            cmd.Parameters.AddWithValue("@SemesterYear", record.SemesterYear);
            cmd.Parameters.AddWithValue("@MajorDegree", record.MajorDegree);

            cmd.Parameters.AddWithValue("@Subject", record.Subject);
            cmd.Parameters.AddWithValue("@Points", record.Points);
            cmd.Parameters.AddWithValue("@ConductedBy", record.ConductedBy);

            cmd.Parameters.AddWithValue("@Justification", record.Justification);
            cmd.Parameters.AddWithValue("@StudentDateSignature", record.StudentDateSignature);

            cmd.Parameters.AddWithValue("@Decision", record.Decision);
            cmd.Parameters.AddWithValue("@Commission1", record.Commission1);
            cmd.Parameters.AddWithValue("@Commission2", record.Commission2);
            cmd.Parameters.AddWithValue("@Commission3", record.Commission3);
            cmd.Parameters.AddWithValue("@BottomDateStampSignature", record.BottomDateStampSignature);

            var result = cmd.ExecuteScalar();
            return Convert.ToInt64(result);
        }

        public List<WniosekSummary> ListSummaries(int limit = 200)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
SELECT Id, CreatedAt, FullName, AlbumNumber
FROM Wnioski
ORDER BY Id DESC
LIMIT @Limit;
";
            cmd.Parameters.AddWithValue("@Limit", limit);

            using var reader = cmd.ExecuteReader();
            var list = new List<WniosekSummary>();

            while (reader.Read())
            {
                var createdAtText = reader.GetString(1);
                _ = DateTime.TryParse(createdAtText, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var createdAt);

                list.Add(new WniosekSummary
                {
                    Id = reader.GetInt64(0),
                    CreatedAt = createdAt,
                    FullName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    AlbumNumber = reader.IsDBNull(3) ? "" : reader.GetString(3)
                });
            }

            return list;
        }

        public WniosekRecord? GetById(long id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
SELECT
    Id, CreatedAt,
    CityDateTop, AlbumNumber, FullName, SemesterYear, MajorDegree,
    Subject, Points, ConductedBy,
    Justification, StudentDateSignature,
    Decision, Commission1, Commission2, Commission3, BottomDateStampSignature
FROM Wnioski
WHERE Id = @Id
LIMIT 1;
";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            var createdAtText = reader.GetString(1);
            _ = DateTime.TryParse(createdAtText, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var createdAt);

            return new WniosekRecord
            {
                Id = reader.GetInt64(0),
                CreatedAt = createdAt,

                CityDateTop = reader.IsDBNull(2) ? "" : reader.GetString(2),
                AlbumNumber = reader.IsDBNull(3) ? "" : reader.GetString(3),
                FullName = reader.IsDBNull(4) ? "" : reader.GetString(4),
                SemesterYear = reader.IsDBNull(5) ? "" : reader.GetString(5),
                MajorDegree = reader.IsDBNull(6) ? "" : reader.GetString(6),

                Subject = reader.IsDBNull(7) ? "" : reader.GetString(7),
                Points = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                ConductedBy = reader.IsDBNull(9) ? "" : reader.GetString(9),

                Justification = reader.IsDBNull(10) ? "" : reader.GetString(10),
                StudentDateSignature = reader.IsDBNull(11) ? "" : reader.GetString(11),

                Decision = reader.IsDBNull(12) ? "" : reader.GetString(12),
                Commission1 = reader.IsDBNull(13) ? "" : reader.GetString(13),
                Commission2 = reader.IsDBNull(14) ? "" : reader.GetString(14),
                Commission3 = reader.IsDBNull(15) ? "" : reader.GetString(15),
                BottomDateStampSignature = reader.IsDBNull(16) ? "" : reader.GetString(16),
            };
        }
    }
}
