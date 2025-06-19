interface Document {
    void open();
    void save();
}


class WordDocument implements Document {
    public void open() { System.out.println("Word document opened."); }
    public void save() { System.out.println("Word document saved."); }
}


class PdfDocument implements Document {
    public void open() { System.out.println("PDF document opened."); }
    public void save() { System.out.println("PDF document saved."); }
}


class ExcelDocument implements Document {
    public void open() { System.out.println("Excel document opened."); }
    public void save() { System.out.println("Excel document saved."); }
}


abstract class DocumentFactory {
    abstract Document createDocument();
}

class WordDocumentFactory extends DocumentFactory {
    public Document createDocument() { return new WordDocument(); }
}


class PdfDocumentFactory extends DocumentFactory {
    public Document createDocument() { return new PdfDocument(); }
}


class ExcelDocumentFactory extends DocumentFactory {
    public Document createDocument() { return new ExcelDocument(); }
}


public class FactoryMethodPatternExample {
    public static void main(String[] args) {
        
        DocumentFactory wordFactory = new WordDocumentFactory();
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        DocumentFactory excelFactory = new ExcelDocumentFactory();

       
        Document wordDoc = wordFactory.createDocument();
        Document pdfDoc = pdfFactory.createDocument();
        Document excelDoc = excelFactory.createDocument();

       
        wordDoc.open();
        wordDoc.save();

        pdfDoc.open();
        pdfDoc.save();

        excelDoc.open();
        excelDoc.save();
    }
}
