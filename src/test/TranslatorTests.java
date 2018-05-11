package test;

import static org.junit.Assert.assertEquals;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.OutputStream;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import utils.Translator;

public class TranslatorTests {
  
  OutputStream stream;
  
  
  @Before
  public void initialize() {
      try {
        stream = new FileOutputStream("");
      } catch (FileNotFoundException e) {
      }
  }

  @After
  public void cleanup() {
    try{
      if(stream != null) stream.close();  
    } catch(Exception e){
       
    }
  }
  
  @Test
  public void test_translator_getKeyboardInstructionStringBaseline() {
    
    String translated = null;
    try {
      translated = Translator.getKeyboardInstructionString("IT Crowd");
    } catch (Exception e) {
    }
    
    String expected = "D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#";
    assertEquals(expected,translated);
  }
  
  @Test
  public void test_translator_verifySpecialCharacterHandle() {
    
    String formatted = Translator.getFormattedTitle("~!@#$%1^&*()A<>?:2{}}|+");
    assertEquals("1A2",formatted);
    
  }
  
  
}
