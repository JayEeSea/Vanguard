using System.Globalization;
using Vanguard.Web.Models;

namespace Vanguard.Web.Services
{
    public class UniverseDateService : IUniverseDateService
    {
        private readonly IFormatProvider _formatProvider;

        public UniverseDateService(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public string GetInCharacterDate(Universe universe)
        {
            DateTime now = DateTime.UtcNow;

            // Apply in-universe time offset (e.g. +385 years for Star Trek)
            if (universe.UsesOffset && universe.OffsetYears.HasValue)
            {
                now = now.AddYears(universe.OffsetYears.Value);
            }

            string result;

            // === Offset-based date (e.g. Star Trek) ===
            if (universe.UsesOffset && universe.OffsetYears.HasValue)
            {
                var inCharacterDate = now;
                var format = string.IsNullOrWhiteSpace(universe.DisplayFormat)
                    ? "ddd dd MMMM yyyy"
                    : universe.DisplayFormat;

                result = inCharacterDate.ToString(format, _formatProvider);
            }
            // === BBY/ABY-based date (e.g. Star Wars) ===
            else if (universe.UsesBBYABY && universe.BBYABYAnchorDate.HasValue)
            {
                var anchor = universe.BBYABYAnchorDate.Value;
                int yearDiff = now.Year - anchor.Year;

                if (now < anchor.AddYears(yearDiff))
                    yearDiff--;

                string era = yearDiff >= 0 ? "ABY" : "BBY";
                int displayYear = Math.Abs(yearDiff);

                result = $"{displayYear} {era}";
            }
            // === Fallback to current Earth date ===
            else
            {
                result = now.ToString(universe.DisplayFormat ?? "dd MMMM yyyy", _formatProvider);
            }

            // Stardate (if enabled)
            if (universe.EnableStardate && universe.StardateBaseDate.HasValue)
            {
                var baseDate = universe.StardateBaseDate.Value;

                // This now uses the in-universe adjusted `now`
                double yearsSinceBase = (now - baseDate).TotalDays / 365.25;
                double stardate = yearsSinceBase * 1000;

                result += $" (Stardate {stardate:0.0})";
            }

            return result;
        }
    }
}