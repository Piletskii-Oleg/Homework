using NUnit.Framework;

namespace BWTransform.Tests
{
    public class Tests
    {
        [TestCase("Раскольников не привык к толпе и, как уже сказано, бежал всякого общества, особенно в последнее время. Но теперь его вдруг что-то потянуло к людям. Что-то совершалось в нем как бы новое, и вместе с тем ощутилась какая-то жажда людей. Он так устал от целого месяца этой сосредоточенной тоски своей и мрачного возбуждения, что хотя одну минуту хотелось ему вздохнуть в другом мире, хоть бы в каком бы то ни было, и, несмотря на всю грязь обстановки, он с удовольствием оставался теперь в распивочной.", ExpectedResult = "Раскольников не привык к толпе и, как уже сказано, бежал всякого общества, особенно в последнее время. Но теперь его вдруг что-то потянуло к людям. Что-то совершалось в нем как бы новое, и вместе с тем ощутилась какая-то жажда людей. Он так устал от целого месяца этой сосредоточенной тоски своей и мрачного возбуждения, что хотя одну минуту хотелось ему вздохнуть в другом мире, хоть бы в каком бы то ни было, и, несмотря на всю грязь обстановки, он с удовольствием оставался теперь в распивочной.")]
        [TestCase("kr525u8ruwefJKDER5784RWUIEFJFKeUr3298pruo);ieadejoRU8293OEIFALJwr4;oie", ExpectedResult = "kr525u8ruwefJKDER5784RWUIEFJFKeUr3298pruo);ieadejoRU8293OEIFALJwr4;oie")]
        [TestCase("Simple text! Nothing more.", ExpectedResult = "Simple text! Nothing more.")]
        public string TransformWorks(string originalLine)
        {
            (string line, int lineNumber) = BWTransform.DirectBWT(originalLine);
            return BWTransform.ReverseBWT(line, lineNumber);
        }
    }
}