/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.utils;

import hr.algebra.models.TravelWarrant;
import java.awt.Color;
import java.io.IOException;
import java.lang.reflect.Field;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.font.PDType1Font;

/**
 *
 * @author pasar
 */
public class PDFMaker {
    
    private static final String PATH = "PDF/Reports/";
    private static final String FILE_PATH = PATH.concat("Report.pdf");

    public static void createPDF(List<TravelWarrant> warrants) {
        try(PDDocument doc = new PDDocument()) {
            warrants.forEach((warrant) -> {//functional operator
                PDPage page = new PDPage();
                doc.addPage(page);
                
                try(PDPageContentStream cs = new PDPageContentStream(doc, page)) {
                    cs.beginText();
                    cs.setFont(PDType1Font.HELVETICA_BOLD,24);
                    cs.setNonStrokingColor(Color.BLUE);//!!!!!!!!!!!!!!!!!!!!!!
                    cs.setLeading(14.0f);
                    
                    cs.newLineAtOffset(25, 700);
                    String title = "Travel warrant".concat(" #").concat(String.valueOf(warrant.getIDTravelWarrant()));
                    cs.showText(title);
                    cs.newLine();
                    cs.newLine();
                    cs.setFont(PDType1Font.HELVETICA, 14);
                    cs.moveTextPositionByAmount(40, 0);
                    
                    for (Field property : warrant.getClass().getDeclaredFields()) {
                        property.setAccessible(true);
                        Object value = property.get(warrant);
                        cs.showText(property.getName().concat(" = ").concat(value.toString()));
                        cs.newLine();
                    }
                    cs.endText();
                } catch (Exception e) {
                }
            });
            createDirectory();
            doc.save(FILE_PATH);
        } catch (Exception e) {
        }
    }

    private static void createDirectory() throws IOException {
        Files.createDirectories(Paths.get(PATH));
    }
    
    
    
}
