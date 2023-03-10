using SimpleBase;

namespace NumberBadger;

/// <summary>
/// Represents a badger table definition
/// </summary>
public static class Badger
{
    /// <summary>
    /// Encodes a GUID into a badge with an optional prefix
    /// </summary>
    /// <param name="value">The guid to encode</param>
    /// <param name="prefix">A prefix to prepend to the badge</param>
    /// <returns>The encoded badger string</returns>
    public static string CreateBadge(Guid value, string? prefix)
    {
        var encodedString = Base58.Bitcoin.Encode(value.ToByteArray());
        return $"{prefix}{encodedString}";
    }
    
    /// <summary>
    /// Attempt to decode a badger string into a GUID
    /// </summary>
    /// <param name="badge">The badger string to attempt to decode</param>
    /// <param name="expectedPrefix">The prefix of this table; if null, the raw string will be decoded</param>
    /// <returns></returns>
    public static BadgerResult<Guid> ParseGuid(string badge, string? expectedPrefix)
    {
        var codeString = badge;
        
        // If we expect a prefix, make sure it exists
        if (expectedPrefix != null)
        {
            if (!badge.StartsWith(expectedPrefix))
            {
                return new BadgerResult<Guid>()
                {
                    Message = $"The ID '{badge}' does not begin with the correct prefix '{expectedPrefix}'.",
                    Success = false
                };
            }

            // Remove the prefix from the badge
            codeString = badge[expectedPrefix.Length..];
        }
        
        // Convert the code portion into raw bytes
        var data = new byte[16];
        var success = false;
        int numBytesWritten = 0;
        try
        {
            success = Base58.Bitcoin.TryDecode(codeString, data, out numBytesWritten);
        }
        // Bummer! SimpleBase throws exceptions rather than just returning false
        catch
        {
            success = false;
        }

        // Detect non success
        if (!success) {
            return new BadgerResult<Guid>()
            {
                Message = $"The ID '{badge}' is not a valid identity code.",
                Success = false
            };

        }

        // Did we not get exactly 16 bytes?
        if (numBytesWritten != 16)
        {
            return new BadgerResult<Guid>()
            {
                Message = $"The ID '{badge}' is incomplete. Did you forget a few characters?",
                Success = false
            };
        }
        
        // Looks like it parsed!
        return new BadgerResult<Guid>()
        {
            Success = true,
            Value = new Guid(data)
        };
    }
}