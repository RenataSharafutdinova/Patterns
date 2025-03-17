class Document
{}
class PDF: Document
{}
class Word: Document
{}
class HTML : Document
{}
abstract class Creator
{
    public abstract Document FactoryMethod();
}

class CreatorPDF: Creator
{
    public override Document FactoryMethod()
    {
        Console.WriteLine("Document PDF is created");
        return new PDF();
    }
}
class CreatorWord : Creator
{
    public override Document FactoryMethod()
    {
        Console.WriteLine("Document Word is created");
        return new Word();
    }
}
class CreatorHTML : Creator
{
    public override Document FactoryMethod()
    {
        Console.WriteLine("Document HTML is created");
        return new HTML();
    }
}
//class Program
//{
//    static void Main(string[] args)
//    {
//        Creator creatPDF = new CreatorPDF();
//        Creator creatWord = new CreatorWord();
//        Creator creatHTML = new CreatorHTML();

//        Document documPDF = creatPDF.FactoryMethod();
//        Document documWord = creatWord.FactoryMethod();
//        Document docuHTML = creatHTML.FactoryMethod();
//    }
//}
