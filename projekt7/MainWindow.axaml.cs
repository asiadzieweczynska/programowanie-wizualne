using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt7;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnCountClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var raw = InputTextBox.Text ?? string.Empty;
        var normalized = NormalizeDna(raw, out var invalidChar, out var invalidIndex);

        if (invalidChar is not null)
        {
            ResultsListBox.ItemsSource = Array.Empty<string>();
            StatusTextBlock.Text = $"Błąd: niedozwolony znak '{invalidChar}' na pozycji {invalidIndex + 1}. Dozwolone są tylko A, C, G, T (spacje i nowe linie są ignorowane).";
            return;
        }

        if (normalized.Length < 4)
        {
            ResultsListBox.ItemsSource = Array.Empty<string>();
            StatusTextBlock.Text = "Za krótka sekwencja: potrzeba co najmniej 4 nukleotydów.";
            return;
        }

        var counts = CountKmers(normalized, 4);

        var lines = counts
            .OrderByDescending(kv => kv.Value)
            .ThenBy(kv => kv.Key, StringComparer.Ordinal)
            .Select(kv => $"{kv.Key}: {kv.Value}")
            .ToArray();

        ResultsListBox.ItemsSource = lines;
        StatusTextBlock.Text = $"Długość po normalizacji: {normalized.Length}. Liczba 4-merów: {normalized.Length - 3}. Unikalne 4-mery: {counts.Count}.";
    }

    private static Dictionary<string, int> CountKmers(string dna, int k)
    {
        var result = new Dictionary<string, int>(StringComparer.Ordinal);
        for (var i = 0; i <= dna.Length - k; i++)
        {
            var kmer = dna.Substring(i, k);
            if (result.TryGetValue(kmer, out var current))
                result[kmer] = current + 1;
            else
                result[kmer] = 1;
        }

        return result;
    }

    private static string NormalizeDna(string input, out char? invalidChar, out int invalidIndex)
    {
        invalidChar = null;
        invalidIndex = -1;

        var sb = new StringBuilder(input.Length);
        var normalizedIndex = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (char.IsWhiteSpace(c))
                continue;

            c = char.ToUpperInvariant(c);
            if (c is 'A' or 'C' or 'G' or 'T')
            {
                sb.Append(c);
                normalizedIndex++;
                continue;
            }

            invalidChar = input[i];
            invalidIndex = i;
            return string.Empty;
        }

        return sb.ToString();
    }
}