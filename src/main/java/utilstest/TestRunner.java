package utilstest;

import org.junit.runner.JUnitCore;
import org.junit.runner.Result;

public class TestRunner {
  public static void main(String[] args) {
    System.out.println("Executing tests...");
    Result result = JUnitCore.runClasses(TranslatorTests.class);
    result.getFailures().forEach(x -> System.out.println(x));
    System.out.println("Test execution complete!");
  }

}
