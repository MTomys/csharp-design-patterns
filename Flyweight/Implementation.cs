namespace Flyweight
{
    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }

    public class CharacterA : ICharacter
    {
        private char _actualCharacter = 'a';
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily}, {_fontSize}");
        }
    }

    public class CharacterB : ICharacter
    {
        private char _actualCharacter = 'b';
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily}, {_fontSize}");
        }
    }

    public class Paragraph : ICharacter
    {
        private int _location;
        private List<ICharacter> _characters;

        public Paragraph(List<ICharacter> characters, int location)
        {
            _characters = characters;
            _location = location;
        }

        public void Draw(string fontFamily, int fontSize)
        {
            Console.WriteLine($"Drawing paragraph at location {_location}");
            foreach (var character in _characters)
            {
                character.Draw(fontFamily, fontSize);
            }
        }
    }

    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new();

        public ICharacter? GetCharacter(char characterIdentifier)
        {
            if (_characters.ContainsKey(characterIdentifier))
            {
                Console.WriteLine("Character reuse");
                return _characters[characterIdentifier];
            }

            _characters[characterIdentifier] = characterIdentifier switch
            {
                'a' => new CharacterA(),
                'b' => new CharacterB(),
                _ => throw new Exception()
            };

            return _characters[characterIdentifier];
        }

        public ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(characters, location);
        }
    }
}