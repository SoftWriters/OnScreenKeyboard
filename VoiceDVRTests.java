import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;
import java.util.*;
import java.lang.reflect.*;

public class VoiceDVRTests {
	
	@BeforeClass
	public static void beforeClass() {
		voicedvr = new VoiceDVR("test1");
	}

	// Testing is the string is only "a"
	@Test
	public void lookForA(){
		Method method = voicedvr.class.getDeclaredMethod("translate", String.class);
		method.setAccessible(true);
		List<String> result = (List<String>) method.invoke(voicedvr, "a");
		assertEquals(result[0],"#");
		assertEquals(1, result.size());
	}
}
