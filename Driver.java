public class Driver {
	public static void main(String args[]) {
		VoiceDVR translator = new VoiceDVR(args[0]);
		translator.Translate(args[1]);
	}
}
