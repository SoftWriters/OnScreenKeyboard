import org.junit.runner.JUnitCore;
import org.junit.runner.Result;
import org.junit.runner.notification.Failure;

public class VoiceDVRTestRunner {
  public static void main(String[] args) {
    Result result = JUnitCore.runClasses(VoiceDVRTest.class);
    for (Failure failure : result.getFailures()) {
      System.out.println(failure.toString());
    }
  }
}
