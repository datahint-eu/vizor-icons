using System.IO;
using System.Text;

namespace Vizor.Icons.Generators.Extensions;

public static class FileExtensions
{
    // this function renames following names
    //   2-fa.svg       --> TwoFa
    //   books-off.svg  --> BooksOff
    public static string GetIconName(this string filename)
    {
        var strippedName = Path.GetFileNameWithoutExtension(filename);

        var chunks = strippedName.Split(new char[] { '-', '_', ' ' });
        chunks[0] = ReplaceNumbersAtStart(chunks[0]);
        for (int i = 0; i < chunks.Length; ++i)
        {
            chunks[i] = char.ToUpper(chunks[i][0]) + chunks[i].Substring(1);
        }

        return string.Concat(chunks);
    }

    private static readonly string[] numbers = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

    // this function renames 2fa to TwoFa
    private static string ReplaceNumbersAtStart(string str)
    {
        var sb = new StringBuilder();

        bool replace = true;
        bool toUpper = true;
        foreach (char c in str)
        {
            if (replace && char.IsDigit(c))
            {
                int index = int.Parse(c.ToString());
                sb.Append(numbers[index]);
            }
            else
            {
                replace = false;
                if (toUpper)
                {
                    toUpper = false;
                    sb.Append(char.ToUpper(c));
                }
                else
                {
                    sb.Append(c);
                }

            }
        }

        return sb.ToString();
    }
}
