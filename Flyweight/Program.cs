using Flyweight;

Console.Title = "Flyweight";

var bunchOfCharacters = "abba";

var characterFactory = new CharacterFactory();

var characterObject = characterFactory.GetCharacter(bunchOfCharacters[0]);
characterObject?.Draw("Arial", 12);

characterObject = characterFactory.GetCharacter(bunchOfCharacters[1]);
characterObject?.Draw("Times new roman", 12);

characterObject = characterFactory.GetCharacter(bunchOfCharacters[2]);
characterObject?.Draw("Times new roman", 13);

characterObject = characterFactory.GetCharacter(bunchOfCharacters[3]);
characterObject?.Draw("Comic sans", 14);

var paragraph = characterFactory.CreateParagraph(
    new List<ICharacter> { characterObject }, 1);

paragraph.Draw("Lucinda", 12);